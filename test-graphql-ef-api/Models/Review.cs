using System.Text.Json.Serialization;

namespace test_graph.Models
{
    public class Review
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Movie Movie { get; set; } = null!;
        public int MovieId { get; set; }
        public string Reviewer { get; set; } = null!;
        public int Stars { get; set; }
    }
}