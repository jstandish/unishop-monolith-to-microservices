using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace MonoToMicroLambda.Models
{
    [Serializable]
    [DataContract]

    public class Unicorn : BaseModel
    {
        [DataMember]
        public string Uuid { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public double? Price { get; set; }
        [DataMember]
        public string Image { get; set; }
    }
}