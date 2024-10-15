using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP02.Models;

namespace TP02.Data
{

    public class TP02DbContext : DbContext
    {
        public TP02DbContext(DbContextOptions<TP02DbContext> options)
        : base(options)
        {
        }

        public DbSet<Container> Containers { get; set; }
        public DbSet<BillOfLading> BillOfLadings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tp02.db");
        }
    }

}