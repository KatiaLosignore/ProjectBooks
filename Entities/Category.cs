using System.Text.Json.Serialization;

namespace ProjectBooks.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }


        // Creo la relazione 1:N con la classe Book

        [JsonIgnore]
        public List<Book>? Books { get; set; }

      


        public Category()
        {

        }
    }
}
