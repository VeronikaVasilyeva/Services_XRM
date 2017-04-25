using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace Services.Lesson_2.Service
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
    }
}