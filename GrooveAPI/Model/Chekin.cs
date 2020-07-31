using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrooveAPI.Model
{
    public class Chekin
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Establishment Establishment { get; set; }
        public DateTime DateChekin { get; set; }
        public DateTime DateCheckout { get; set; }
    }
}
