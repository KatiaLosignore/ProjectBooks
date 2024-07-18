using ProjectBooks.Entities;
using ProjectBooks.Repo;

namespace ProjectBooks.Service
{
    public class Categoryservice : ICategoryservice
    {

        private readonly ICategoryrepository dbRepo;

        public Categoryservice(ICategoryrepository dbRepo)
        {
            this.dbRepo = dbRepo;
        }


        public List<Category> GetAllCategories()
        {
            List<Category> categories = dbRepo.GetAllCategories();

            return categories;
        }

        public Category GetByIdCategory(int id)
        {
            Category category = dbRepo.GetByIdCategory(id);

            return category;
        }

        public void AddCategory(Category category)
        {
            dbRepo.AddCategory(category);

        }

        public void UpdateCategory(Category updateCategory)
        {
            dbRepo.UpdateCategory(updateCategory);
        }

        public void DeleteCategory(int id)
        {
            dbRepo.DeleteCategory(id);
        }


    }



        
       

        
}
