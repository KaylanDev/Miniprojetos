using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_SEM_SER_CRUD_.Data
{
    internal class AplicationDbContext : DbContext
    {

        public DbSet<Dados> Motos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-OLG03HC;Initial Catalog=MotosProject;Integrated Security=True;Trust Server Certificate=True");
        }

    }
}
