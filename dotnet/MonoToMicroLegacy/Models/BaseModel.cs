using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MonoToMicroLegacy.Models
{
    [Serializable]
    [DataContract]
    public class BaseModel : IDisposable
    {
        [DataMember]
        public long? Id { get; set; }
        [DataMember]
        public DateTime? CreationDate { get; set; }
        [DataMember]
        public DateTime? LastModifiedDate { get; set; }
        [DataMember]
        public long? CreatedByUserId { get; set; }
        [DataMember]
        public long? LastModifiedByUserId { get; set; }
        [DataMember]
        public bool? Active { get; set; }

        public override string ToString()
        {
            return 	$"{Id} {CreationDate} {LastModifiedDate} {CreatedByUserId} {LastModifiedByUserId} {Active}";
        }

        public void Dispose() { }
    }
}