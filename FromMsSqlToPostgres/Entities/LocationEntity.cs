using System;
using System.Collections.Generic;

namespace CoffeApp.Data.Entities
{
    public class LocationEntity : IdentifiableEntity<Guid>
    {
        public string Name { get; set; }

        public List<OrderEntity> Orders { get; set; }
    }
}