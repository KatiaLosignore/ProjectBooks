using Microsoft.EntityFrameworkCore;
using ProjectBooks.Data;
using ProjectBooks.Entities;

namespace ProjectBooks.Repo
{
    public class Categoryrepository : ICategoryrepository
    {

        private readonly DataContext dbContext;

        public Categoryrepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<Category> GetAllCategories()
        {
            List<Category> categories = dbContext.Categories.ToList();

            return categories;
        }

        public Category GetByIdCategory(int id)
        {
            Category? category = dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();

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
            dbContext.Categories.Add(category);

            dbContext.SaveChanges();
        }

        public void UpdateCategory(Category updateCategory)
        {
            dbContext.Categories.Update(updateCategory);

            dbContext.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category? category = dbContext.Categories.Where(c => c.Id == id).FirstOrDefault();

            if (category != null)
            {

                dbContext.Categories.Remove(category);

                dbContext.SaveChanges();

            }
        }

       

      

      
    }
}
