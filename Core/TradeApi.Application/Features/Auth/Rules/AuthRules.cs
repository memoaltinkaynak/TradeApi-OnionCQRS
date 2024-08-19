using TradeApi.Application.Bases;
using TradeApi.Application.Features.Auth.Exceptions;
using TradeApi.Domain.Entities.Auth;

namespace TradeApi.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null) throw new UserAlreadyExistException();
            return Task.CompletedTask;
        }
        public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
        {
            if (user is null || !checkPassword) throw new EmailOrPasswordShouldNotBeInvalid();
            return Task.CompletedTask;
            
        }
    }
}
