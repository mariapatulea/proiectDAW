using proiectDAW.Models.Entities;
using System.Collections.Generic;

namespace proiectDAW.Models.DTOs
{
    public class EditorDTO
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PublishingHouse { get; set; }
        // public Author Author { get; set; }

        public EditorDTO(Editor editor)
        {
            this.Id = editor.Id;
            this.LastName = editor.LastName;
            this.FirstName = editor.FirstName;
            this.PublishingHouse = editor.PublishingHouse;
        }
    }
}
