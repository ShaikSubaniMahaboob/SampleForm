﻿using System.ComponentModel.DataAnnotations;

namespace SampleForm.Models
{
    public class Book
    {
        public int Id { get; set; }
        //[Display(Name = "Book Title")]
        //[Required]
        //[StringLength(maximumLength: 20, ErrorMessage = "The Title length should be between 2 and 20.", MinimumLength = 2)]
        public string Title { get; set; }
        public string Genre { get; set; }
        public List<string> Authors { get; set; }
        public string Helpers { get; set; }
        //[DataType(DataType.Currency)]
        //[Range(1, 100)]
        public decimal Price { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
