using ProjectBooks.Entities;

namespace ProjectBooks.Service
{
    public interface ICategoryservice
    {
        public List<Category> GetAllCategories();

        public Category GetByIdCategory(int id);


        public void AddCategory(Category category);

        public void UpdateCategory(Category updateCategory);

        public void DeleteCategory(int id);
    }
}
