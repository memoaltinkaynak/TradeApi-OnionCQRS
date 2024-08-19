using TradeApi.Application.Bases;

namespace TradeApi.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalid : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalid() : base("Kullanıcı veya şifre hatalı!") { }
    }
}
