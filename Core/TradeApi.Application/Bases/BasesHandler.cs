using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TradeApi.Application.Interfaces.AutoMapper;
using TradeApi.Application.Interfaces.UnitOfWorks;

namespace TradeApi.Application.Bases
{
    public class BasesHandler
    {
        public readonly IMapper mapper;
        public readonly IUnitOfWork unitOfWork;
        public readonly IHttpContextAccessor httpContextAccessor;
        public readonly Guid userId;

        public BasesHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            userId = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
//using Microsoft.AspNetCore.Http;
//using System.Security.Claims;
//using TradeApi.Application.Interfaces.AutoMapper;
//using TradeApi.Application.Interfaces.UnitOfWorks;

//namespace TradeApi.Application.Bases
//{
//    public class BasesHandler
//    {
//        public readonly IMapper mapper;
//        public readonly IUnitOfWork unitOfWork;
//        public readonly IHttpContextAccessor httpContextAccessor;
//        public readonly Guid userId;

//        public BasesHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
//        {
//            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
//            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
//            this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

//            // Null kontrolleri ekleyin
//            var userIdValue = httpContextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

//            if (!string.IsNullOrEmpty(userIdValue))
//            {
//                userId = Guid.Parse(userIdValue);
//            }
//            else
//            {
//                // Handle null case, örneğin özel bir istisna fırlatın veya default bir değer atayın
//                throw new ArgumentNullException(nameof(userId), "User ID cannot be null or empty.");
//            }
//        }
//    }
//}
