using TradeApi.Application.Bases;

namespace TradeApi.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Kullanıcı veya şifre hatalı!") { }        
    }
}
