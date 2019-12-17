namespace TransportCompanyApp
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TransportCompanyContext : DbContext
    {
        public TransportCompanyContext()
            : base("name=TransportCompanyContext")
        {
        }
        public DbSet<Delievery> Delieveries { get; set; }
    }
}