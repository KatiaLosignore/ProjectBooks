using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProjectBooks.Data;
using ProjectBooks.Entities;
using ProjectBooks.Repo;

namespace ProjectBooks.Service
{
    public class Bookservice : IBookservice
    {
        private readonly IBookrepository dbRepo;


        public Bookservice(IBookrepository dbRepo)
        {
            this.dbRepo = dbRepo;
        }


        public List<Book> GetAll()
        {
            List<Book> books = dbRepo.GetAll();

            return books;
        }

        public Book GetById(int id)
        {
            Book book = dbRepo.GetById(id);

            return book;
        }

        public List<Book> GetBooksByTitle(string title)
        {
            List<Book> books = dbRepo.GetBooksByTitle(title);

            return books;
        }

        public void AddBook(Book book)
        {
            dbRepo.AddBook(book);

        }

        //public void UpdateBook(Book upadteBook)
        //{
        //    dbRepo.UpdateBook(upadteBook);
        //}

        public void UpdateBook(Book upadteBook)
        {
            // Assicurati che la categoria non sia NULL e abbia un nome valido prima di aggiornare il libro
            if (upadteBook.Category == null || string.IsNullOrWhiteSpace(upadteBook.Category.Name))
            {
                throw new ArgumentException("Il nome della categoria non può essere nullo o vuoto.");
            }

            dbRepo.UpdateBook(upadteBook);
        }


        public void Delete(int id)
        {
            dbRepo.Delete(id);

        }

        
    }
}
