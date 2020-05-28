using System.ComponentModel.DataAnnotations.Schema;

namespace MonoToMicroLegacy.Core.Data.Models
{
    [Table("unicorns_basket")]
    public class UnicornBasket : BaseModel
    {
        [Column("uuid")]
        public string Uuid {get; set; }
        [Column("unicornUuid")]
        public string UnicornUuid {get; set; }
    }
}