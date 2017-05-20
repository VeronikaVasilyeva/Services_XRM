using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Services.Lesson_6.Controllers;

namespace Services.Lesson_6.Models
{
    public class BookModel
    {
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Author { get; set; }

        public int Year { get; set; }

        public BookType Type { get; set; }

    }

    public enum BookType
    {
        Journal,
        Textbook,
        Fiction
    }

}
