﻿using Microsoft.AspNetCore.Mvc;
using SampleForm.Models;


namespace SampleForm.Controllers
{
    public class BooksController : Controller
    {
        //public string Index()
        //{
        //    return "This is the book index.";
        //}
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            Book book = new Book()
            {
                Id = 1,
                Title = "Learning ASP.NET Core 2.0",
                Helpers = "Who help to Authour",
                Genre = "Programming & Software Development",    
                Price = 45,
                PublishDate = new System.DateTime(2012, 04, 23),
                Authors = new List<string>
    { "Jason De Oliveira", "Michel Bruchet" }
            };
            return View(book);
        }
    }
}
