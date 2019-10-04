using FoodCatalog.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FoodsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query) => await _mediator.Send(query);
    }
}
