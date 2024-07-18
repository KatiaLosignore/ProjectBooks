namespace ProjectBooks.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; }


        // Creo la relazione 1:N con la classe Category
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }


        public Book()
        {

        }


    }
}
