using Microsoft.EntityFrameworkCore;
using ProjectBooks.Data;
using ProjectBooks.Entities;

namespace ProjectBooks.Repo
{
    public class Authorrepository : IAuthorrepository
    {

        private readonly DataContext _dbContext;

        public Authorrepository(DataContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public List<Author> GetAllAuthors()
        {
            List<Author> authors = _dbContext.Authors.ToList();

            return authors;
        }

        public Author GetByIdAuthor(int id)
        {
            Author? author = _dbContext.Authors.Where(a => a.Id == id).FirstOrDefault();

            if (author != null)
            {
                return author;
            }
            else
            {
                throw new Exception("L'Autore non è stato trovato!");
            }
        }

        public void AddAuthor(Author author)
        {
            _dbContext.Authors.Add(author);

            _dbContext.SaveChanges();
        }

        public void UpdateAuthor(Author updateAuthor)
        {
            _dbContext.Authors.Update(updateAuthor);

            _dbContext.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            Author? author = _dbContext.Authors.Where(a => a.Id == id).FirstOrDefault();

            if (author != null)
            {

                _dbContext.Authors.Remove(author);

                _dbContext.SaveChanges();

            }
        }

    }
       


}
