using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectBooks.Data;
using ProjectBooks.Entities;
using ProjectBooks.Service;

namespace ProjectBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // uso la  Dependency Injection

        private readonly IBookservice _dbService;

        public BookController(IBookservice dbService)
        {
            this._dbService = dbService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

           List<Book> books = _dbService.GetAll();

           return Ok(books);
        
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            Book book = _dbService.GetById(id);

            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }


        }


        [HttpGet("search/{search}")]
        public async Task<IActionResult> SearchBook(string? search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return BadRequest("Attenzione inserire un titolo!");
            }

            List<Book> foundBooks = _dbService.GetBooksByTitle(search);

            // !foundBooks.Any() restituisce true se la lista foundBooks è vuota e false se contiene uno o più elementi
            if (foundBooks == null || !foundBooks.Any())
            {
                return NotFound("Nessun Libro trovato.");
            }

            return Ok(foundBooks);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book newBook)
        {
            if (newBook == null)
            {
                return BadRequest("Il campo non può essere nullo!");
            }

            if (string.IsNullOrEmpty(newBook.Title) || string.IsNullOrEmpty(newBook.Description) || newBook.Year <= 0)
            {
                return BadRequest("Attenzione, inserisci un Titolo, Descrizione e Anno corretti.");
            }

            _dbService.AddBook(newBook);

            return Ok("Libro creato correttamente!");
        }




        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book updateBook)
        {
            if (updateBook == null)
            {
                return BadRequest("Il campo non può essere nullo!");
            }

            if (string.IsNullOrEmpty(updateBook.Title) || string.IsNullOrEmpty(updateBook.Description) || updateBook.Year <= 0)
            {
                return BadRequest("Attenzione, inserisci un Titolo, Descrizione e Anno corretti.");
            }

            var existingBook = _dbService.GetById(id);
            if (existingBook == null)
            {
                return BadRequest("Il libro non è stato trovato!");
            }

            existingBook.Title = updateBook.Title;
            existingBook.Description = updateBook.Description;
            existingBook.Year = updateBook.Year;
            existingBook.CategoryId = updateBook.CategoryId;

            // Controlli per l'UPDATE Category
            if (updateBook.Category == null || string.IsNullOrWhiteSpace(updateBook.Category.Name))
            {
                return BadRequest("Il nome della categoria non può essere nullo o vuoto.");
            }

            if (existingBook.Category == null)
            {
                existingBook.Category = new Category { Name = updateBook.Category.Name };
            }
            else
            {
                existingBook.Category.Name = updateBook.Category.Name;
            }

            // Controlli per l'UPDATE Author
            if (updateBook.Author == null || string.IsNullOrWhiteSpace(updateBook.Author.Name) ||
                string.IsNullOrWhiteSpace(updateBook.Author.Surname) ||
                string.IsNullOrWhiteSpace(updateBook.Author.Address) ||
                string.IsNullOrWhiteSpace(updateBook.Author.City))
            {
                return BadRequest("Tutti i campi dell'autore sono obbligatori.");
            }

            if (existingBook.Author == null)
            {
                existingBook.Author = new Author
                {
                    Name = updateBook.Author.Name,
                    Surname = updateBook.Author.Surname,
                    Address = updateBook.Author.Address,
                    City = updateBook.Author.City
                };
            }
            else
            {
                existingBook.Author.Name = updateBook.Author.Name;
                existingBook.Author.Surname = updateBook.Author.Surname;
                existingBook.Author.Address = updateBook.Author.Address;
                existingBook.Author.City = updateBook.Author.City;
            }

            // Blocco try catch per intercettare eventuali errori di update
            try
            {
                _dbService.UpdateBook(existingBook);
                return Ok("Libro aggiornato correttamente!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Si è verificato un errore durante l'aggiornamento del libro.");
            }
        }


        [HttpDelete("{id}")]
        public async void DeleteBook(int id)
        {
 
            _dbService.Delete(id);
           
        }
        
    }

}





        


 
