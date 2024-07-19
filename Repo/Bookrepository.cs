using Microsoft.EntityFrameworkCore;
using ProjectBooks.Data;
using ProjectBooks.Entities;

namespace ProjectBooks.Repo
{
    public class Bookrepository : IBookrepository
    {

        private readonly DataContext _dbContext;


        public Bookrepository(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<Book> GetAll()
        {
            List<Book> books = _dbContext.Books.Include(book => book.Category).ToList();

            return books;
        }

        public Book GetById(int id)
        {
            Book? book = _dbContext.Books.Where(b => b.Id == id).Include(book => book.Category).FirstOrDefault();

            if (book != null)
            {
                return book;
            }
            else
            {
                throw new Exception("Il Libro non è stato trovato!");
            }
            
        }

        public List<Book> GetBooksByTitle(string title)
        {
            List<Book> foundedBooks = _dbContext.Books.Where(book => book.Title.ToLower().Contains(title.ToLower())).Include(book => book.Category).ToList();

            return foundedBooks;
        }



        public void AddBook(Book book)
        {
            _dbContext.Books.Add(book);

            _dbContext.SaveChanges();
        }


        //public void UpdateBook(Book updateBook)
        //{
        //    dbContext.Books.Update(updateBook);

        //    dbContext.SaveChanges();
        //}

        public void UpdateBook(Book updateBook)
        {
            var existingBook = _dbContext.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == updateBook.Id);
            if (existingBook != null)
            {
                existingBook.Title = updateBook.Title;
                existingBook.Description = updateBook.Description;
                existingBook.Year = updateBook.Year;

                if (existingBook.Category == null)
                {
                    existingBook.Category = new Category { Name = updateBook.Category.Name };
                }
                else
                {
                    existingBook.Category.Name = updateBook.Category.Name;
                }

                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Book? book = _dbContext.Books.Where(b => b.Id == id).FirstOrDefault();

            if (book != null)
            {

                 _dbContext.Books.Remove(book);

                 _dbContext.SaveChanges();

            }
        }
    }
















    //Include(photo => photo.Categories)
}
