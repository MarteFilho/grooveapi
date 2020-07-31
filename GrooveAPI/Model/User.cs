using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrooveAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Birthday { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Phone { get; set; }
        public string Genre { get; set; }
        public List<Establishment> Establishment { get; set; }
        public CovidTest CovidTest { get; set; }

    }
}
