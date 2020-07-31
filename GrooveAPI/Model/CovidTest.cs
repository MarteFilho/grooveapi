using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrooveAPI.Model
{
    public class CovidTest
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime TestDate { get; set; }
        public bool Infected { get; set; }
    }
}
