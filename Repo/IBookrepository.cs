
using ProjectBooks.Entities;

namespace ProjectBooks.Repo
{
    public interface IBookrepository
    {
        public List<Book> GetAll();

        public Book GetById(int id);

        public List<Book> GetBooksByTitle(string title);

        public void AddBook(Book book);

        public void UpdateBook(Book updateBook);

        public void Delete(int id);

    }
}
