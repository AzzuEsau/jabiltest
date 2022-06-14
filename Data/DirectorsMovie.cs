using System;

namespace api.Data
{
    public class DirectorsMovie
    {
        public DirectorsMovie() {}

        public int Id { get; set; }
        public int FKmovie { get; set; }
        public int FKdirector { get; set; }
        public DateTime Update { get; set; }
    }
}
