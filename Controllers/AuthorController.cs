using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectBooks.Entities;
using ProjectBooks.Service;

namespace ProjectBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        // uso la  Dependency Injection

        private readonly IAuthorservice _dbService;

        public AuthorController(IAuthorservice dbService)
        {
            this._dbService = dbService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            List<Author> authors = _dbService.GetAllAuthors();

            return Ok(authors);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            Author author = _dbService.GetByIdAuthor(id);

            if (author != null)
            {
                return Ok(author);
            }
            else
            {
                return NotFound();
            }

        }


        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] Author newAuthor)
        {
            if (newAuthor == null)
            {
                return BadRequest("Il campo non può essere nullo!");
            }

            if (string.IsNullOrEmpty(newAuthor.Name) || string.IsNullOrEmpty(newAuthor.Surname) || string.IsNullOrEmpty(newAuthor.Address) || string.IsNullOrEmpty(newAuthor.City))
            {
                return BadRequest("Attenzione, inserisci un Nome, Cognome, Indirizzo e Città corretti.");
            }

            _dbService.AddAuthor(newAuthor);

            return Ok("Autore creato correttamente!");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] Author updateAuthor)
        {
            if (updateAuthor == null)
            {
                return BadRequest("Il campo non può essere nullo!");
            }

            if (string.IsNullOrEmpty(updateAuthor.Name) || string.IsNullOrEmpty(updateAuthor.Surname) || string.IsNullOrEmpty(updateAuthor.Address) || string.IsNullOrEmpty(updateAuthor.City))
            {
                return BadRequest("Attenzione, inserisci un Nome, Cognome, Indirizzo e Città corretti.");
            }

            var existingAuthor = _dbService.GetByIdAuthor(id);

            if (existingAuthor == null)
            {
                return BadRequest("L'Autore non è stato trovato!");
            }

            existingAuthor.Name = updateAuthor.Name;
            existingAuthor.Surname = updateAuthor.Surname;
            existingAuthor.Address = updateAuthor.Address;
            existingAuthor.City = updateAuthor.City;


            _dbService.UpdateAuthor(existingAuthor);

            return Ok("Autore aggiornato correttamente!");
        }


        [HttpDelete("{id}")]
        public async void DeleteBook(int id)
        {

            _dbService.DeleteAuthor(id);

        }




    }
}
