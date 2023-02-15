using Microsoft.EntityFrameworkCore;
using NLayerEF.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TeamworkSystem.DataAccessLayer.Configurations;

namespace NLayerEF.DAL.Data
{
    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test;Trusted_Connection=True;");
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }
    }
}
