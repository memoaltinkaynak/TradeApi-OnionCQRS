using TradeApi.Application.Bases;

namespace TradeApi.Application.Features.Auth.Exceptions
{
    public class UserAlreadyExistException : BaseException
    {
        public UserAlreadyExistException() : base("Böyle bir kullanıcı zaten var!") { }
    }
}
