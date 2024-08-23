using Microsoft.AspNetCore.Identity;

namespace TradeApi.Domain.Entities.Auth
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpryTime { get; set; }
    }
}
