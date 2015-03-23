using System;
using System.Collections.Generic;

namespace StoreCatalog.Models
{
    public class Book
    {
        public int ArticleNumber { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public double AverageRating { get; set; }
        public List<Author> Authors { get; set; }
        public string Format { get; set; }
        public string Language { get; set; }
        public double Price { get; set; }
    }
}