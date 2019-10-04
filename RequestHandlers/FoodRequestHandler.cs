using FoodCatalog.Services;
using GraphQL;
using GraphQL.Types;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodCatalog.RequestHandlers
{
    public class FoodRequestHandler : IRequestHandler<GraphQLQuery, IActionResult>
    {
        private readonly FoodService _foodService;

        public FoodRequestHandler(FoodService foodService) { _foodService = foodService; }
        public async Task<IActionResult> Handle(GraphQLQuery request, CancellationToken cancellationToken)
        {
            Schema schema = new Schema()
            {
                Query = new CustomQuery(_foodService)
            };
            ExecutionResult result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = request.Query;
            }).ConfigureAwait(false);

            return result.Errors?.Count > 0 ? new BadRequestResult() : (IActionResult)new OkObjectResult(result);
        }
    }
}
