using GraphQL.Types;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FoodCatalog.Services
{
    public class AttributeBase
    {
        [JsonPropertyName("qty")]
        public string Qty { get; set; }
        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }
    public class FoodRequest : IRequest<ObjectResult>
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("base_qty")]
        public int BaseQty { get; set; }
        [JsonPropertyName("base_unit")]
        public string BaseUnit { get; set; }
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
        [JsonPropertyName("attributes")]
        public Attributes Attributes { get; set; }
    }

    public class Attributes
    {
        public AttributeBase Humidity { get; set; }
        public AttributeBase Protein { get; set; }
        public AttributeBase Lipid { get; set; }
        public AttributeBase Cholesterol { get; set; }
        public AttributeBase Carbohydrate { get; set; }
        public AttributeBase Fiber { get; set; }
        [JsonPropertyName("ashes")]
        public AttributeBase Ashes { get; set; }
        [JsonPropertyName("calcium")]
        public AttributeBase Calcium { get; set; }
        [JsonPropertyName("magnesium")]
        public AttributeBase Magnesium { get; set; }
        public AttributeBase Phosphorus { get; set; }
        public AttributeBase Iron { get; set; }
        public AttributeBase Sodium { get; set; }
        public AttributeBase Potassium { get; set; }
        public AttributeBase Copper { get; set; }
        public AttributeBase Zinc { get; set; }
        public AttributeBase Retinol { get; set; }
        public AttributeBase Thiamine { get; set; }
        public AttributeBase Riboflavin { get; set; }
        public AttributeBase Pyridoxine { get; set; }
        public AttributeBase Niacin { get; set; }
        public Energy Energy { get; set; }
        public FattyAcids FattyAcids { get; set; }
        public AttributeBase Manganese { get; set; }
    }

    public class Energy
    {
        public string KCal { get; set; }
        public string KJ { get; set; }
    }

    public class FattyAcids
    {
        public AttributeBase Saturated { get; set; }
        public AttributeBase Monounsaturated { get; set; }
        public AttributeBase Polyunsaturated { get; set; }
        public AttributeBase _140 { get; set; }
        public AttributeBase _160 { get; set; }
        public AttributeBase _180 { get; set; }
        public AttributeBase _200 { get; set; }
        public AttributeBase _220 { get; set; }
        public AttributeBase _240 { get; set; }
        public AttributeBase _181 { get; set; }
        public AttributeBase _201 { get; set; }
        public AttributeBase _182n6 { get; set; }
        public AttributeBase _183n3 { get; set; }
        public AttributeBase _225 { get; set; }
    }
}