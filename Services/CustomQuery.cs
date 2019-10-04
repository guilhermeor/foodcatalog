
using GraphQL.Types;

namespace FoodCatalog.Services
{
    public class CustomQuery : ObjectGraphType
    {
        private readonly FoodService _foodService;
        public CustomQuery(FoodService foodService)
        {
            _foodService = foodService;

            FieldAsync<ListGraphType<FoodType>>(
                "foods",
                resolve: async context => { return await _foodService.Get(); });
        }
    }
}
