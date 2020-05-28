using System.ComponentModel.DataAnnotations.Schema;

namespace MonoToMicroLegacy.Core.Data.Models
{
    [Table("unicorn_user")]
    public class UnicornUser : BaseModel
    {
        [Column("uuid")]
        public string Uuid {get; set; }
        [Column("email")]
        public string Email {get; set; }
        [Column("first_name")]
        public string FirstName {get; set; }
        [Column("last_name")]
        public string LastName {get; set; }
    }
}