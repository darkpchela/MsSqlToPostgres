using System;
using System.Collections.Generic;
using CoffeApp.Domain.Enums;

namespace CoffeApp.Data.Entities
{
    public class OrderEntity : IdentifiableEntity<Guid>
    {
        public int TotalItemsCount { get; set; }

        public DateTime CreatedAt { get; set; }

        public Status? Status { get; set; }

        public Guid? UserId { get; set; }

        public Guid? LocationId { get; set; }

        public UserEntity User { get; set; }

        public LocationEntity Location { get; set; }

        public List<OrderItemEntity> OrderItems { get; set; }
    }
}