using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSqlToPostgress
{
    public class TransferContext : IDisposable
    {
        public DbContext Source { get; }

        public DbContext Destination { get; }

        public List<IEntityType> TransferedEntities { get; private set; }

        public List<IEntityType> NotTransferedEntities { get; private set; }

        public TransferContext(
            DbContext source,
            DbContext destination)
        {
            Source = source;
            Destination = destination;
            NotTransferedEntities = source.Model.GetEntityTypes().ToList();
            TransferedEntities = new List<IEntityType>();
        }

        public void Transfer()
        {
            while (NotTransferedEntities.Count > 0)
            {
                var transferedEntities = TransferEntityWithRelations(NotTransferedEntities.First());
                NotTransferedEntities = NotTransferedEntities.Except(transferedEntities).ToList();
                TransferedEntities.AddRange(transferedEntities);
            }
        }

        private List<IEntityType> TransferEntityWithRelations(IEntityType entityType)
        {
            var entityForeignKeys = entityType.GetForeignKeys();
            var transferedEntities = new List<IEntityType>();

            foreach (var key in entityForeignKeys)
            {
                if (NotTransferedEntities.Contains(key.PrincipalEntityType))
                {
                    transferedEntities.AddRange(TransferEntityWithRelations(key.PrincipalEntityType));
                }
            }

            TransferSetByEntityType(entityType);
            transferedEntities.Add(entityType);

            return transferedEntities;
        }

        private IEnumerable<object> GetSetByClrEntityType(DbContext dbContext, IEntityType entityType)
        {
            var set = dbContext
                .GetType()
                .GetMethods()
                .First(mi => mi.Name == nameof(dbContext.Set) && mi.IsGenericMethod)
                .MakeGenericMethod(entityType.ClrType)
                .Invoke(dbContext, null);

            return set as IEnumerable<object>;
        }

        private void TransferSetByEntityType(IEntityType entityType)
        {
            var sourceDbSet = GetSetByClrEntityType(Source, entityType);
            var targetDbSet = GetSetByClrEntityType(Destination, entityType);

            targetDbSet
                .GetType()
                .GetMethod(
                    nameof(DbSet<object>.AddRange),
                    new[] { (typeof(IEnumerable<>)).MakeGenericType(entityType.ClrType) })
                .Invoke(targetDbSet, new[] { sourceDbSet });

            Destination.SaveChanges();
        }

        public void Dispose()
        {
            Source.Dispose();
            Destination.Dispose();
        }
    }
}
