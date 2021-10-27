using System.Collections.Generic;

namespace test_graph.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IList<Review>? Reviews { get; set; }
    }
}
