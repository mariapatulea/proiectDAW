using proiectDAW.Models.Entities;
using System.Collections.Generic;

namespace proiectDAW.Models.DTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Editor Editor { get; set; }  // navigation property
        public ICollection<Book> PublishedBooks { get; set; }

        public AuthorDTO(Author author)
        {
            this.Id = author.Id;
            this.LastName = author.LastName;
            this.FirstName = author.FirstName;
            this.Editor = author.Editor;
            this.PublishedBooks = new List<Book>();
        }
    }
}
