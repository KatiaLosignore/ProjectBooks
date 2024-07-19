using ProjectBooks.Entities;

namespace ProjectBooks.Service
{
    public interface IAuthorservice
    {
        public List<Author> GetAllAuthors();

        public Author GetByIdAuthor(int id);

        public void AddAuthor(Author author);

        public void UpdateAuthor(Author updateAuthor);

        public void DeleteAuthor(int id);
    }
}
