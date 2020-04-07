using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace nyVYapp.Models
{
    public class Kunde
    {
        [Key]
        public int KId { get; set; }
        public string Navn { get; set; }
        public string Epost { get; set; }
        public string Telefonnr { get; set; }

        public virtual List<Bestilling> Bestillinger { get; set; }
    }
    public class Bestilling
    {
        [Key]
        public int BId { get; set; }
        public string ReiseFra { get; set; }

        public string ReiseTil { get; set; }

        public string Dato { get; set; }

        public string Tid { get; set; }

        public string Reisende { get; set; }
        public int Antall { get; set; }
        public int KId { get; set; }

        public virtual Kunde Kunde { get; set; }
    }

    public class KundeContext : DbContext
    {
        public KundeContext() : base("name=Billet")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Bestilling> Bestillinger { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}