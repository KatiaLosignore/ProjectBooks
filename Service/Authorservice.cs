using ProjectBooks.Entities;
using ProjectBooks.Repo;

namespace ProjectBooks.Service
{
    public class Authorservice : IAuthorservice
    {

        private readonly IAuthorrepository _dbRepo;

        public Authorservice(IAuthorrepository dbRepo)
        {
            this._dbRepo = dbRepo;
        }

        public List<Author> GetAllAuthors()
        {
            List<Author> authors = _dbRepo.GetAllAuthors();

            return authors;
        }

        public Author GetByIdAuthor(int id)
        {
            Author author = _dbRepo.GetByIdAuthor(id);

            return author;
        }

        public void AddAuthor(Author author)
        {
            _dbRepo.AddAuthor(author);
        }

        public void UpdateAuthor(Author updateAuthor)
        {
            _dbRepo.UpdateAuthor(updateAuthor);
        }

        public void DeleteAuthor(int id)
        {
            _dbRepo.DeleteAuthor(id);
        }

        

        
    }
}
