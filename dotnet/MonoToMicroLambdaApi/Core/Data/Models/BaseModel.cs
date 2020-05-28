using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Amazon.DynamoDBv2.DataModel;

namespace MonoToMicroLambda.Core.Data.Models
{
    public class BaseModel
    {
        public long? Id { get; set; }
        
        public DateTime? CreationDate { get; set; }
        
        public DateTime? LastModifiedDate { get; set; }
        
        public long? CreatedByUserId { get; set; }

        public long? LastModifiedByUserId { get; set; }
        
        public byte? Active { get; set; }
    }
}