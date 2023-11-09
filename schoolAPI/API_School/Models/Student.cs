using System.Text.Json.Serialization;

namespace API_School.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ClassroomId { get; set; }
        [JsonIgnore]
        public Classroom Classroom { get; set; }
    }
}
