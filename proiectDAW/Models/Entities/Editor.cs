namespace proiectDAW.Models.Entities
{
    public class Editor
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PublishingHouse { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }  // navigation property
    }
}
