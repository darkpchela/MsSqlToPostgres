using System;
using CoffeApp.Domain.Enums;

namespace CoffeApp.Data.Entities
{
    public class OrderItemEntity : IdentifiableEntity<Guid>
    {
        public int Count { get; set; }

        public Guid OrderId { get; set; }

        public Guid MenuItemId { get; set; }

        public CupSize? CupSize { get; set; }

        public Temperature? Temperature { get; set; }

        public Creamer? Creamer { get; set; }

        public OrderEntity Order { get; set; }

        public MenuItemEntity MenuItem { get; set; }
    }
}