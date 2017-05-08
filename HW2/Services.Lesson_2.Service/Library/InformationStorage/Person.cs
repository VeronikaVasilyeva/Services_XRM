using System.Runtime.Serialization;

namespace Services.Lesson_3.Service.Library.InformationStorage
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}