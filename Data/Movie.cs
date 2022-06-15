using System;

namespace api.Data
{
    public class Movie
    {
        public Movie() {}

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Classification FKclassification { get; set; }
        public DateTime Update { get; set; }
    }
}