using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeApi.Application.Features.Products.Queries.GetAllProducts;

namespace TradeApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await mediator.Send(new GetAllProductsQueryRequest());

            return Ok(response);
        }
    }
}
