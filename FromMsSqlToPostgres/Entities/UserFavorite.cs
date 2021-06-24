using System;

namespace CoffeApp.Data.Entities
{
    public class UserFavoriteEntity : IdentifiableEntity<Guid>
    {
        public Guid UserId { get; set; }

        public Guid MenuItemId { get; set; }

        public UserEntity User { get; set; }

        public MenuItemEntity MenuItem { get; set; }
    }
}
