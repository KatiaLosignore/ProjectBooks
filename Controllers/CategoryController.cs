using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectBooks.Entities;
using ProjectBooks.Service;

namespace ProjectBooks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // uso la  Dependency Injection

        private readonly ICategoryservice _dbService;

        public CategoryController(ICategoryservice dbService)
        {
            this._dbService = dbService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            List<Category> categories = _dbService.GetAllCategories();

            return Ok(categories);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            Category category = _dbService.GetByIdCategory(id);

            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] Category newCategory)
        {
            if (newCategory == null)
            {
                return BadRequest("Il campo non può essere nullo!");
            }

            if (string.IsNullOrEmpty(newCategory.Name))
            {
                return BadRequest("Attenzione, inserisci un nome Categoria.");
            }

            _dbService.AddCategory(newCategory);

            return Ok("Categoria creata correttamente!");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category updateCategory)
        {
            if (updateCategory == null)
            {
                return BadRequest("Il campo non può essere nullo!");
            }

            if (string.IsNullOrEmpty(updateCategory.Name))
            {
                return BadRequest("Attenzione, inserisci un nome Categoria.");
            }

            var existingCategory = _dbService.GetByIdCategory(id);

            if (existingCategory == null)
            {
                return BadRequest("La Categoria non è stata trovata!");
            }

            existingCategory.Name = updateCategory.Name;


            _dbService.UpdateCategory(existingCategory);

            return Ok("Categoria aggiornata correttamente!");
        }


        [HttpDelete("{id}")]
        public async void DeleteBook(int id)
        {

            _dbService.DeleteCategory(id);

        }



    }
}
