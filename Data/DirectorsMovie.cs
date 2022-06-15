using System;

namespace api.Data
{
    public class DirectorsMovie
    {
        public DirectorsMovie() {}

        public int Id { get; set; }
        public Movie FKmovie { get; set; }
        public Director FKdirector { get; set; }
        public DateTime Update { get; set; }
    }
}
