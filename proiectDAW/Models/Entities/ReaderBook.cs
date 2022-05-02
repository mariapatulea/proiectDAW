namespace proiectDAW.Models.Entities
{
    public class ReaderBook
    {
        public int ReaderId { get; set; }
        public Reader Reader { get; set; }  // navigation property
        public int BookId { get; set; }
        public Book Book { get; set; }  // navigation property
    }
}
