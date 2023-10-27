using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio11Ado
{
    public class Context : DbContext
    {
        public DbSet<Estudiante> Estudiante { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NFDMETJ; Database= Progra2;Trusted_Connection=SSPI;MultipleActiveResultSets=true;Trust Server Certificate=true;");
        }
    }
    }
