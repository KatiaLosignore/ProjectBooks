using System.Text.Json.Serialization;

namespace ProjectBooks.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string City { get; set; }


        // Creo la relazione 1:N con la classe Book

        [JsonIgnore]
        public List<Book>? Books { get; set; }


        public Author() { }
    }
}
