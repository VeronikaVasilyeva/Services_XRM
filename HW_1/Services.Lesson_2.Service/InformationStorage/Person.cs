using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Services.Lesson_2.Service
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
    }
}