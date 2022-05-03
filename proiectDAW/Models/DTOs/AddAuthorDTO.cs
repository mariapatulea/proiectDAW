using proiectDAW.Models.Entities;

namespace proiectDAW.Models.DTOs
{
    public class AddAuthorDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Editor Editor { get; set; }
    }
}
