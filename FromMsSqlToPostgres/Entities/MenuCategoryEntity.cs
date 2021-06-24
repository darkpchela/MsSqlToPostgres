using System;
using System.Collections.Generic;

namespace CoffeApp.Data.Entities
{
    public class MenuCategoryEntity : IdentifiableEntity<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<MenuItemEntity> MenuItems { get; set; }
    }
}