using System;
using System.Runtime.Serialization;

namespace MonoToMicroLegacy.Models
{
    [Serializable]
    [DataContract]
    public class User : BaseModel
    {
        [DataMember]
        public string Uuid { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
}