using ProjectBooks.Entities;
using ProjectBooks.Repo;

namespace ProjectBooks.Service
{
    public class Categoryservice : ICategoryservice
    {

        private readonly ICategoryrepository _dbRepo;

        public Categoryservice(ICategoryrepository dbRepo)
        {
            this._dbRepo = dbRepo;
        }


        public List<Category> GetAllCategories()
        {
            List<Category> categories = _dbRepo.GetAllCategories();

            return categories;
        }

        public Category GetByIdCategory(int id)
        {
            Category category = _dbRepo.GetByIdCategory(id);

            return category;
        }

        public void AddCategory(Category category)
        {
            _dbRepo.AddCategory(category);

        }

        public void UpdateCategory(Category updateCategory)
        {
            _dbRepo.UpdateCategory(updateCategory);
        }

        public void DeleteCategory(int id)
        {
            _dbRepo.DeleteCategory(id);
        }


    }



        
       

        
}
