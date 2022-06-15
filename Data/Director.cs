using System;

namespace api.Data
{
    public class Director
    {
        public Director() {}

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Update { get; set; }
        public bool Enabled { get; set; }
    }
}
