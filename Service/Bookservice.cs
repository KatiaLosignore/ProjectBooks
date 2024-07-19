using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProjectBooks.Data;
using ProjectBooks.Entities;
using ProjectBooks.Repo;

namespace ProjectBooks.Service
{
    public class Bookservice : IBookservice
    {
        private readonly IBookrepository _dbRepo;


        public Bookservice(IBookrepository dbRepo)
        {
            this._dbRepo = dbRepo;
        }


        public List<Book> GetAll()
        {
            List<Book> books = _dbRepo.GetAll();

            return books;
        }

        public Book GetById(int id)
        {
            Book book = _dbRepo.GetById(id);

            return book;
        }

        public List<Book> GetBooksByTitle(string title)
        {
            List<Book> books = _dbRepo.GetBooksByTitle(title);

            return books;
        }

        public void AddBook(Book book)
        {
            _dbRepo.AddBook(book);

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

            _dbRepo.UpdateBook(upadteBook);
        }


        public void Delete(int id)
        {
            _dbRepo.Delete(id);

        }

        
    }
}
