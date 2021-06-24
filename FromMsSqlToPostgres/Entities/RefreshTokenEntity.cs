using System;

namespace CoffeApp.Data.Entities
{
    public class RefreshTokenEntity : IdentifiableEntity<Guid>
    {
        public string EncodedValue { get; set; }

        public bool IsRevoked { get; set; }

        public bool IsUsed { get; set; }

        public DateTime ExpiryDate { get; set; }

        public Guid UserId { get; set; }

        public UserEntity User { get; set; }
    }
}
