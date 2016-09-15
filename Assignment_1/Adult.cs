using System.Runtime.Serialization;

namespace Assignment_1
{
    [DataContract]
    public class Adult : Person
    {
        [DataMember]
        public string phone1 { get; set; }
        [DataMember]
        public string phone2 { get; set; }
    }
}
