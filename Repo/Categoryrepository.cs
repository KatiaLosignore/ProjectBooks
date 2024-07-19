using Microsoft.EntityFrameworkCore;
using ProjectBooks.Data;
using ProjectBooks.Entities;

namespace ProjectBooks.Repo
{
    public class Categoryrepository : ICategoryrepository
    {

        private readonly DataContext _dbContext;

        public Categoryrepository(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public List<Category> GetAllCategories()
        {
            List<Category> categories = _dbContext.Categories.ToList();

            return categories;
        }

        public Category GetByIdCategory(int id)
        {
            Category? category = _dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();

            if (category != null)
            {
                return category;
            }
            else
            {
                throw new Exception("La categoria non è stata trovata!");
            }
        }

        public void AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);

            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Category updateCategory)
        {
            _dbContext.Categories.Update(updateCategory);

            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category? category = _dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();

            if (category != null)
            {

                _dbContext.Categories.Remove(category);

                _dbContext.SaveChanges();

            }
        }

       

      

      
    }
}
