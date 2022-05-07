using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkProject
{
    internal class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=SchoolDb; Trusted_Connection=True");
        }
    }
}
