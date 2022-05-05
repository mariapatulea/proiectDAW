using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiectDAW.Models.DTOs;
using proiectDAW.Models.Entities;
using proiectDAW.Repositories;
using System.Threading.Tasks;

namespace proiectDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;  // dependency injection
        public BookController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookDTO bookDTO)
        {
            Book newBook = new Book();
            Author author = await _repository.Author.GetByIdAsync(1);
            newBook.Title = bookDTO.Title;
            newBook.Author = author;
            newBook.IsHardcover = bookDTO.IsHardcover;
            newBook.NumarPagini = bookDTO.NumarPagini;
            // author.PublishedBooks.Add(newBook);

            _repository.Book.Create(newBook);

            await _repository.Book.SaveAsync();
            // _repository.Author.Update(author);
            // await _repository.Author.SaveAsync();

            return Ok(new BookDTO(newBook));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookWithAuthor(int id)
        {
            var book = await _repository.Book.GetBookByIdWithAuthor(id);
            if (book == null)
            {
                return BadRequest();
            }
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById(int id)
        {
            var book = await _repository.Book.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound("Book does not exist!");
            }
            _repository.Book.Delete(book);
            await _repository.Book.SaveAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPages(int id, [FromBody] int numberOfPages)
        {
            var bookWithUpdatedPages = await _repository.Book.UpdateBookPages(id, numberOfPages);
            if (bookWithUpdatedPages == null)
            {
                return BadRequest("Error");
            }
            _repository.Book.Update(bookWithUpdatedPages);
            await _repository.Book.SaveAsync();
            return NoContent();
        }
    }
}
