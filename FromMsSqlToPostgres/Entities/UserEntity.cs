using System;
using System.Collections.Generic;

namespace CoffeApp.Data.Entities
{
    public class UserEntity : IdentifiableEntity<Guid>
    {
        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public List<OrderEntity> Orders { get; set; }

        public List<RefreshTokenEntity> RefreshTokens { get; set; }

        public List<UserFavoriteEntity> UserFavorites { get; set; }
    }
}