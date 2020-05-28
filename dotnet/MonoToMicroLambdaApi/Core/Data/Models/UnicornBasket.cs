using System.ComponentModel.DataAnnotations.Schema;
using Amazon.DynamoDBv2.DataModel;

namespace MonoToMicroLambda.Core.Data.Models
{
    [DynamoDBTable("unishop_baskets_table")]
    public class UnicornBasket
    {
        [DynamoDBHashKey("uuid")]
        public string Uuid {get; set; }
        [DynamoDBRangeKey("unicornuuid")]
        public string UnicornUuid {get; set; }
    }
}