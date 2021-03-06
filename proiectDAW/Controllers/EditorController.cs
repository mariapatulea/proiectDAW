using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiectDAW.Models.DTOs;
using proiectDAW.Models.Entities;
using proiectDAW.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;  // dependency injection
        public EditorController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEditorById(int id)
        {
            var editor = await _repository.Editor.GetEditorByIdWithAuthor(id);  // nu imi ia si autorul
            if (editor == null)
            {
                return NotFound("Editor with this Id doesn't exist!");
            }
            var editorToReturn = new EditorDTO(editor);
            return Ok(editorToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditor(AddEditorDTO editor)
        {
            Editor newEditor = new Editor();
            newEditor.PublishingHouse = editor.PublishingHouse;
            newEditor.FirstName = editor.FirstName;
            newEditor.LastName = editor.LastName;
            newEditor.Author = new Author()
            {
                    LastName = "Hazelwood",
                    FirstName = "Ali",
                    Id = newEditor.Id,
                    Editor = newEditor,
                    PublishedBooks = new List<Book>()
            };

            _repository.Editor.Create(newEditor);

            await _repository.Editor.SaveAsync();

            _repository.Author.Create(newEditor.Author);
            await _repository.Author.SaveAsync();

            return Ok(new EditorDTO(newEditor));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditorById(int id)
        {
            var editor = await _repository.Editor.GetByIdAsync(id);
            if (editor == null)
            {
                return NotFound("Editor does not exist!");
            }
            _repository.Editor.Delete(editor);
            await _repository.Editor.SaveAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEditorPublishingHouse(int id, [FromBody] string newPublishingHouse)
        {
            var editorWithUpdatedPublishingHouse = await _repository.Editor.UpdateEditorPublishingHouse(id, newPublishingHouse);
            if (editorWithUpdatedPublishingHouse == null)
            {
                return BadRequest("Error");
            }
            _repository.Editor.Update(editorWithUpdatedPublishingHouse);
            await _repository.Editor.SaveAsync();
            return NoContent();
        }
    }
}
