using proiectDAW.Models.Entities;

namespace proiectDAW.Models.DTOs
{
    public class AddBookDTO
    {
        public string Title { get; set; }
        // public Author Author { get; set; }
        public int NumarPagini { get; set; }
        public bool IsHardcover { get; set; }
    }
}
