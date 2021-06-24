using System;
using System.Collections.Generic;

namespace CoffeApp.Data.Entities
{
    public class MenuItemEntity : IdentifiableEntity<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Guid? MenuCategoryId { get; set; }

        public MenuCategoryEntity MenuCategory { get; set; }

        public List<OrderItemEntity> OrderItems { get; set; }

        public List<UserFavoriteEntity> UserFavorites { get; set; }
    }
}