﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Services.Lesson_6.Controllers;

namespace Services.Lesson_6.Models
{
    public class PersonModel
    {
        //[MyValidation]
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
