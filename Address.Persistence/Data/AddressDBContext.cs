using Address.Persistence.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Address.Persistence.Data
{
    public class AddressDBContext : DbContext
    {
        private string connectionString;

        public AddressDBContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Model.Address> Addresses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=W81-LSANCHEZ\SQLEXPRESS;Initial Catalog=AddressTest;Integrated Security=True");
            optionsBuilder.UseSqlServer(connectionString);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Address>(entity =>
        //    //{
        //    //    entity.HasOne(d => d.CountryId).WithOne(x => x.CountryCode)
        //    //        .HasForeignKey(d => d.);
        //    //});
        //}
    }
}
