using Microsoft.EntityFrameworkCore;
using ProjectBooks.Data;
using ProjectBooks.Entities;

namespace ProjectBooks.Repo
{
    public class Bookrepository : IBookrepository
    {

        private readonly DataContext dbContext;


        public Bookrepository(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Book> GetAll()
        {
            List<Book> books = dbContext.Books.Include(book => book.Category).ToList();

            return books;
        }

        public Book GetById(int id)
        {
            Book? book = dbContext.Books.Where(b => b.Id == id).Include(book => book.Category).FirstOrDefault();

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
            List<Book> foundedBooks = dbContext.Books.Where(book => book.Title.ToLower().Contains(title.ToLower())).Include(book => book.Category).ToList();

            return foundedBooks;
        }



        public void AddBook(Book book)
        {
            dbContext.Books.Add(book);

            dbContext.SaveChanges();
        }


        //public void UpdateBook(Book updateBook)
        //{
        //    dbContext.Books.Update(updateBook);

        //    dbContext.SaveChanges();
        //}

        public void UpdateBook(Book updateBook)
        {
            var existingBook = dbContext.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == updateBook.Id);
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

                dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Book? book = dbContext.Books.Where(b => b.Id == id).FirstOrDefault();

            if (book != null)
            {

                 dbContext.Books.Remove(book);

                 dbContext.SaveChanges();

            }
        }
    }
















    //Include(photo => photo.Categories)
}
