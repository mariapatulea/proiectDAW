using System.ComponentModel.DataAnnotations.Schema;

namespace proiectDAW.Models.Entities
{
    public class Editor
    {
        [ForeignKey("Author")]
        public int Id { get; set; }  // este atat PK cat si FK
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PublishingHouse { get; set; }
        public Author Author { get; set; }  // navigation property
    }
}
