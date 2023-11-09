using System.Text.Json.Serialization;

namespace API_School.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Student>? Students { get; set; }
    }
}
