using System.Collections.Generic;

namespace proiectDAW.Models.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public int NumarPagini { get; set; }
        public bool IsHardcover { get; set; }
        public ICollection<ReaderBook> ReaderBooks { get; set; }
    }
}
