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
        public DbSet<Recipient> Recipients { get; set; }
        public DbSet<Sender> Senders { get; set; }
    }
}