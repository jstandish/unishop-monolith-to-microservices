using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MonoToMicroLegacy.Core.Data.Models
{
    [Table("unicorns")]
    public class Unicorn  : BaseModel
    {
        [Column("uuid")]
        public string Uuid { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("description")]
        public string Description { get; set; }
        
        [Column("price")]
        public decimal? Price { get; set; }
        
        [Column("image")]
        public string Image { get; set; }
    }

}