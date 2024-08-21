using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeApi.Application.Bases;
using TradeApi.Application.Interfaces.AutoMapper;
using TradeApi.Application.Interfaces.UnitOfWorks;
using TradeApi.Domain.Entities.Auth;

namespace TradeApi.Application.Features.Auth.Command.RevokeAll
{
    public class RevokeAllCommandHandler : BasesHandler, IRequestHandler<RevokeAllCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;

        public RevokeAllCommandHandler(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
        {
            List<User> users = await userManager.Users.ToListAsync(cancellationToken);

            foreach(User user in users)
            {
                user.RefreshToken = null;
                await userManager.UpdateAsync(user);
            }

            return Unit.Value;
        }
    }
}
