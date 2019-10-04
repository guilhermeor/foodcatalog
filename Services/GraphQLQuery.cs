using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FoodCatalog.Services
{
    public class GraphQLQuery : IRequest<IActionResult>
    {
        public string Query { get; set; }
    }
}
