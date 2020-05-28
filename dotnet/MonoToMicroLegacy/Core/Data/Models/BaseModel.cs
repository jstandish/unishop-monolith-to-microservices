using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MonoToMicroLegacy.Core.Data.Models
{
    public class BaseModel
    {
        [Column("id")]
        public long? Id { get; set; }
        
        [Column("creation_date")]
        public DateTime? CreationDate { get; set; }
        
        [Column("last_modified_date")]
        public DateTime? LastModifiedDate { get; set; }
        
        [Column("created_by_user_id")]
        public long? CreatedByUserId { get; set; }
        
        [Column("last_modified_by_user_id")]
        public long? LastModifiedByUserId { get; set; }
        
        [Column("active")]
        public byte? Active { get; set; }
    }
}