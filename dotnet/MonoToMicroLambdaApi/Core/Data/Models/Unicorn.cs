using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Amazon.DynamoDBv2.DataModel;

namespace MonoToMicroLambda.Core.Data.Models
{
    [DynamoDBTable("ProductCatalog")]

    public class Unicorn  : BaseModel
    {
        [DynamoDBHashKey("uuid")]
        public string Uuid { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public decimal? Price { get; set; }
        
        public string Image { get; set; }
    }

}