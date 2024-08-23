using MediatR;
using Microsoft.AspNetCore.Http;
using TradeApi.Application.Bases;
using TradeApi.Application.Interfaces.AutoMapper;
using TradeApi.Application.Interfaces.UnitOfWorks;
using TradeApi.Domain.Entities;

namespace TradeApi.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandHandler : BasesHandler, IRequestHandler<DeleteProductCommandRequest, Unit>
    {
        public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }


        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
            product.IsDeleted = true;

            await unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
