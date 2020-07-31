using GrooveAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrooveAPI.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Chekin> Chekin { get; set; }
        public DbSet<Establishment> Establishment { get; set; }
        public DbSet<CovidTest> CovidTest { get; set; }
    }
}
