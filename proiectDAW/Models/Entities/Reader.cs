using System.Collections.Generic;

namespace proiectDAW.Models.Entities
{
    public class Reader
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public ICollection<ReaderBook> ReaderBooks { get; set; }
    }
}
