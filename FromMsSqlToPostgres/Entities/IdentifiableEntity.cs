using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeApp.Data.Entities
{
    public abstract class IdentifiableEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
