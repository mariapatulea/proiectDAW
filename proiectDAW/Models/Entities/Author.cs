using System.Collections.Generic;

namespace proiectDAW.Models.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Editor Editor { get; set; }  // navigation property
        public ICollection<Book> PublishedBooks { get; set; }
    }
}
