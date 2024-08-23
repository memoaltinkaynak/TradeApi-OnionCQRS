using MediatR;
using Microsoft.AspNetCore.Http;
using TradeApi.Application.Bases;
using TradeApi.Application.Features.Products.Rules;
using TradeApi.Application.Interfaces.AutoMapper;
using TradeApi.Application.Interfaces.UnitOfWorks;
using TradeApi.Domain.Entities;

namespace TradeApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProducutCommandHandler : BasesHandler, IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly ProductRules productRules;

        public CreateProducutCommandHandler(ProductRules productRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.productRules = productRules;
        }
        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            await productRules.ProductTitleMustNotBeSame(products, request.Title);

            Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount);


            await unitOfWork.GetWriteRepository<Product>().AddAsync(product);
            if (await unitOfWork.SaveAsync() > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                    await unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                    {
                        ProductId = product.Id,
                        CategoryId = categoryId
                    });

                await unitOfWork.SaveAsync();
            }

            return Unit.Value;
        }
    }
}
