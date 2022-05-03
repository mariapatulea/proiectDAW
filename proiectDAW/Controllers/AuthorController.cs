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
    public class AuthorController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;  // dependency injection
        public AuthorController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthorsWithEditor()
        {
            var authors = await _repository.Author.GetAllAuthorsWithEditor();
            var authorsToReturn = new List<AuthorDTO>();
            foreach (var author in authors)
            {
                authorsToReturn.Add(new AuthorDTO(author));
            }

            return Ok(authorsToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AddAuthorDTO authorDTO)
        {
            Author newAuthor = new Author();
            newAuthor.Editor = authorDTO.Editor;
            newAuthor.FirstName = authorDTO.FirstName;
            newAuthor.LastName = authorDTO.LastName;

            _repository.Author.Create(newAuthor);

            await _repository.Author.SaveAsync();

            return Ok(new AuthorDTO(newAuthor));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorById(int id)
        {
            var author = await _repository.Author.GetByIdAsync(id);
            if (author == null)
            {
                return NotFound("Author does not exist!");
            }
            _repository.Author.Delete(author);
            await _repository.Author.SaveAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAuthorLastName(int id, [FromBody] string newLastName)
        {
            var authorWithUpdatedName = await _repository.Author.UpdateAuthorLastName(id, newLastName);
            if (authorWithUpdatedName == null)
            {
                return BadRequest("Error");
            }
            _repository.Author.Update(authorWithUpdatedName);
            await _repository.Author.SaveAsync();
            return NoContent();
        }
    }
}
