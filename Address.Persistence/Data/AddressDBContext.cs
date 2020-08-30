using Address.Persistence.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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
            //optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.UseNpgsql(connectionString, builder =>
            {
                builder.RemoteCertificateValidationCallback((s, c, ch, sslPolicyErrors) =>
                {
                    if (sslPolicyErrors == SslPolicyErrors.None)
                    {
                        return true;
                    }
                    return false;
                });

                builder.ProvideClientCertificatesCallback(clientCerts =>
                {
                    X509Certificate2 retVal = null;
                    X509Store certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                    certStore.Open(OpenFlags.ReadOnly);

                    X509Certificate2Collection certCollection = certStore.Certificates.Find(X509FindType.FindByThumbprint, Environment.GetEnvironmentVariable("Thumbprint_address_app"), false);

                    if (certCollection.Count > 0)
                    {
                        retVal = certCollection[0];
                    }

                    certStore.Close();
                    //var clientCertPath = "c:\\cert\\localhost.cer";
                    //var cert = new X509Certificate2(clientCertPath);
                    //clientCerts.Add(cert);
                });
            });
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
