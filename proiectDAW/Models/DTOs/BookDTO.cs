using proiectDAW.Models.Entities;
using System.Collections.Generic;

namespace proiectDAW.Models.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // public Author Author { get; set; }
        public int NumarPagini { get; set; }
        public bool IsHardcover { get; set; }
        public ICollection<ReaderBook> ReaderBooks { get; set; }

        public BookDTO(Book book)
        {
            // this.Author = book.Author;
            this.NumarPagini = book.NumarPagini;
            this.ReaderBooks = new List<ReaderBook>();
            this.Id = book.Id;
            this.Title = book.Title;
            this.IsHardcover = book.IsHardcover;
        }
    }
}
