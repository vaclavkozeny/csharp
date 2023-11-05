using System.Text.Json.Serialization;

namespace Books.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [JsonIgnore]
        public ICollection<Book>? Books { get; set; }

    }
}
