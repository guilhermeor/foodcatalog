using GraphQL.Types;

namespace FoodCatalog.Services
{
    public class FoodType : ObjectGraphType<FoodRequest>
    {
        public FoodType()
        {
            Name = "FoodRequest";
            Field(x => x.Id);
            Field(x => x.Description);
            Field(x => x.BaseQty);
            Field(x => x.CategoryId);
            Field(x => x.BaseUnit);
            //Field(x => x.Attributes);
        }
    }
}
