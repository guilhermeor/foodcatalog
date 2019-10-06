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
            Field(
    name: "Attributes",
    type: typeof(AttributesType),
    resolve: context => context.Source.Attributes
);
            //Field(
            //    name: "Positions",
            //    type: typeof(PositionType),
            //    resolve: context => context.Source.Positions
            //);
        }
    }
    public class AttributesType : ObjectGraphType<Attributes>
    {
        public AttributesType()
        {
            Field(x => x.Ashes, type: typeof(AttributesBaseType));
            Field(x => x.Calcium, type: typeof(AttributesBaseType));
            Field(x => x.Carbohydrate, type: typeof(AttributesBaseType));
            Field(x => x.Cholesterol, type: typeof(AttributesBaseType));
            Field(x => x.Copper, type: typeof(AttributesBaseType));
        }
    }

    public class AttributesBaseType : ObjectGraphType<AttributeBase>
    {
        public AttributesBaseType()
        {
            Field(x => x.Qty);
            Field(x => x.Unit);
        }
    }
}
