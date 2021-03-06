﻿using System.Runtime.Serialization;

namespace Services.Lesson_3.Service.Library.BookStorage
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Author { get; set; }

        [DataMember]
        public int Year { get; set; }

        [DataMember]
        public BookType Type { get; set; }
    }

    [DataContract]
    public enum BookType
    {
        [EnumMember(Value = "Journal")] Journal,

        [EnumMember(Value = "Textbook")] Textbook,

        [EnumMember(Value = "Fiction")] Fiction
    }
}