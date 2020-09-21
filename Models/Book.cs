using System;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
