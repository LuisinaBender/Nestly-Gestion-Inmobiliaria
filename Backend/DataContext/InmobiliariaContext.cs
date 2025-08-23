using Microsoft.EntityFrameworkCore;
using Services.Models;

namespace Backend.DataContext
{
    public class InmobiliariaContext :DbContext
    {
        public virtual DbSet<Client>Clients { get; set; }
        public virtual DbSet<Property>Properties { get; set; }
        public virtual DbSet<Contract>Contracts { get; set; }
        public virtual DbSet<Employee>Employees { get; set; }
        public virtual DbSet<Owner>Owners { get; set; }
        public virtual DbSet<PaymentMethod>PaymentMethods { get; set; }


        public InmobiliariaContext(DbContextOptions<InmobiliariaContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            }
        }
    }
}
