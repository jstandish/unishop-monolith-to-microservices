using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MonoToMicroLambda.Models
{
    [Serializable]
    [DataContract]
    public class UnicornBasket
    {
        [DataMember]
        public string Uuid {get; set; }
        [DataMember]
        public List<string> Unicorns { get; set; }
    }

    [Serializable]
    [DataContract]
    public class UnicornBasketUnicorns
    {
        
        [DataMember]
        public string Uuid {get; set; }
    }
    
    [Serializable]
    [DataContract]
    public class UnicornBasketGet
    {
        [DataMember]
        public string Uuid {get; set; }
        [DataMember]
        public List<Unicorn> Unicorns { get; set; }
    }
}