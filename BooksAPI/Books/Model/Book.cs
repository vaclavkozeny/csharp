using System.Text.Json.Serialization;

namespace Books.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Name { get; set; }
        public int Pages { get; set; }
        public int AuthorId { get; set; }
        [JsonIgnore]
        public Author? Author { get; set; }
    }
}
