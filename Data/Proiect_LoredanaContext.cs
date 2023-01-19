using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Loredana.Models;

namespace Proiect_Loredana.Data
{
    public class Proiect_LoredanaContext : DbContext
    {
        public Proiect_LoredanaContext (DbContextOptions<Proiect_LoredanaContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Loredana.Models.Game> Game { get; set; } = default!;

       

        public DbSet<Proiect_Loredana.Models.Author> Author { get; set; }

        public DbSet<Proiect_Loredana.Models.Category> Category { get; set; }
        public DbSet<Proiect_Loredana.Models.Client> Client { get; set; }
        public DbSet<Proiect_Loredana.Models.Acquisition> Acquisition { get; set; }
    }
}
