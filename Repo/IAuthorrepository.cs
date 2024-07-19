using ProjectBooks.Entities;

namespace ProjectBooks.Repo
{
    public interface IAuthorrepository
    {
        public List<Author> GetAllAuthors();

        public Author GetByIdAuthor(int id);

        public void AddAuthor(Author author);

        public void UpdateAuthor(Author updateAuthor);

        public void DeleteAuthor(int id);
    }
}
