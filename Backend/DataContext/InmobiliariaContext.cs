using Microsoft.EntityFrameworkCore;
using Services.Enums;
using Services.Models;

namespace Backend.DataContext
{
    public class InmobiliariaContext : DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        public InmobiliariaContext(DbContextOptions<InmobiliariaContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
                var connectionString = configuration.GetConnectionString("mysqlRemoto");
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Relaciones explícitas con el patrón NombreId
            modelBuilder.Entity<Property>()
                .HasOne(p => p.Owner)
                .WithMany()
                .HasForeignKey(p => p.OwnerId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Property)
                .WithMany()
                .HasForeignKey(t => t.PropertyId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Client)
                .WithMany()
                .HasForeignKey(t => t.ClientId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Employee)
                .WithMany()
                .HasForeignKey(t => t.EmployeeId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Transaction)
                .WithMany()
                .HasForeignKey(p => p.TransactionId);
            #endregion

            #region Datos semillas de 10 Clients
            // Seeds
            modelBuilder.Entity<Client>().HasData(
                new Client { ClientId = 1, FirstName = "Juan", LastName = "Perez", Document = "12345678", Phone = "555-1234", Email = "juanperez@hotmail.com", IsDeleted = false },
                new Client { ClientId = 2, FirstName = "Maria", LastName = "Gomez", Document = "87654321", Phone = "555-5678", Email = "mariagomez@hotmail.com", IsDeleted = false },
                new Client { ClientId = 3, FirstName = "Carlos", LastName = "Lopez", Document = "11223344", Phone = "555-8765", Email = "carloslopez@hotmail.com", IsDeleted = false },
                new Client { ClientId = 4, FirstName = "Ana", LastName = "Martinez", Document = "44332211", Phone = "555-4321", Email = "anamartinez@hotmail.com", IsDeleted = false },
                new Client { ClientId = 5, FirstName = "Luis", LastName = "Rodriguez", Document = "55667788", Phone = "555-6789", Email = "luisrodri@hotmail.com", IsDeleted = false },
                new Client { ClientId = 6, FirstName = "Sofia", LastName = "Fernandez", Document = "88776655", Phone = "555-9876", Email = "soffer@hotmail.com", IsDeleted = false },
                new Client { ClientId = 7, FirstName = "Diego", LastName = "Sanchez", Document = "99887766", Phone = "555-5432", Email = "diegosanchez@hotmail.com", IsDeleted = false },
                new Client { ClientId = 8, FirstName = "Laura", LastName = "Ramirez", Document = "66778899", Phone = "555-2109", Email = "lauraramirez@hotmail.com", IsDeleted = false },
                new Client { ClientId = 9, FirstName = "Jorge", LastName = "Torres", Document = "33445566", Phone = "555-6543", Email = "jorgetorres@hotmail.com", IsDeleted = false },
                new Client { ClientId = 10, FirstName = "Elena", LastName = "Vargas", Document = "22113344", Phone = "555-3210", Email = "elena@hotmail.com", IsDeleted = false }
            );
            #endregion

            #region Datos semillas de  Employees y Transactions
            // Seed de Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FirstName = "Pedro", LastName = "Alvarez", Document = "12345678", Phone = "555-1111", Email = "pedro.alvarez@test.com", Role = EmployeeRoleEnum.Admin, IsDeleted = false },
                new Employee { EmployeeId = 2, FirstName = "Marta", LastName = "Blanco", Document = "87654321", Phone = "555-2222", Email = "marta.blanco@test.com", Role = EmployeeRoleEnum.Agent, IsDeleted = false },
                new Employee { EmployeeId = 3, FirstName = "Javier", LastName = "Cruz", Document = "11223344", Phone = "555-3333", Email = "javier.cruz@test.com", Role = EmployeeRoleEnum.Agent, IsDeleted = false },
                new Employee { EmployeeId = 4, FirstName = "Lucia", LastName = "Duarte", Document = "44332211", Phone = "555-4444", Email = "lucia.duarte@test.com", Role = EmployeeRoleEnum.Manager, IsDeleted = false },
                new Employee { EmployeeId = 5, FirstName = "Alberto", LastName = "Espinoza", Document = "55667788", Phone = "555-5555", Email = "alberto.espinoza@test.com", Role = EmployeeRoleEnum.Agent, IsDeleted = false }
            );
            #endregion

            #region Datos semillas de 10 Owners 
            modelBuilder.Entity<Owner>().HasData(
                new Owner { OwnerId = 1, FirstName = "Ricardo", LastName = "Mendoza", Document = "10111222", Phone = "555-6001", Email = "ricardo.mendoza@test.com", Address = "Av. Libertad 123", IsDeleted = false },
                new Owner { OwnerId = 2, FirstName = "Claudia", LastName = "Ortiz", Document = "20212223", Phone = "555-6002", Email = "claudia.ortiz@test.com", Address = "Calle San Martín 456", IsDeleted = false },
                new Owner { OwnerId = 3, FirstName = "Fernando", LastName = "Silva", Document = "30313233", Phone = "555-6003", Email = "fernando.silva@test.com", Address = "Bv. Belgrano 789", IsDeleted = false },
                new Owner { OwnerId = 4, FirstName = "Gabriela", LastName = "Moreno", Document = "40414243", Phone = "555-6004", Email = "gabriela.moreno@test.com", Address = "Ruta 8 Km 12", IsDeleted = false },
                new Owner { OwnerId = 5, FirstName = "Hernan", LastName = "Castro", Document = "50515253", Phone = "555-6005", Email = "hernan.castro@test.com", Address = "Pasaje Mitre 321", IsDeleted = false },
                new Owner { OwnerId = 6, FirstName = "Mariana", LastName = "Acosta", Document = "60616263", Phone = "555-6006", Email = "mariana.acosta@test.com", Address = "Av. Rivadavia 654", IsDeleted = false },
                new Owner { OwnerId = 7, FirstName = "Jorge", LastName = "Suarez", Document = "70717273", Phone = "555-6007", Email = "jorge.suarez@test.com", Address = "Calle Italia 432", IsDeleted = false },
                new Owner { OwnerId = 8, FirstName = "Patricia", LastName = "Vega", Document = "80818283", Phone = "555-6008", Email = "patricia.vega@test.com", Address = "San Juan 876", IsDeleted = false },
                new Owner { OwnerId = 9, FirstName = "Diego", LastName = "Romero", Document = "90919293", Phone = "555-6009", Email = "diego.romero@test.com", Address = "Mitre 147", IsDeleted = false },
                new Owner { OwnerId = 10, FirstName = "Silvia", LastName = "Herrera", Document = "10011002", Phone = "555-6010", Email = "silvia.herrera@test.com", Address = "Dorrego 258", IsDeleted = false }
            );
            #endregion

            #region Datos semillas de 10 Properties

            modelBuilder.Entity<Property>().HasData(
                new Property { PropertyId = 1, Address = "Calle 123", City = "San Justo", Province = "Santa Fe", Type = PropertyTypeEnum.House, Room = 4, Price = 75000m, Status = PropertyStatusEnum.Available, OwnerId = 1 },
                new Property { PropertyId = 2, Address = "Av. Libertador 456", City = "Buenos Aires", Province = "Buenos Aires", Type = PropertyTypeEnum.Apartment, Room = 3, Price = 120000m, Status = PropertyStatusEnum.Reserved, OwnerId = 2 },
                new Property { PropertyId = 3, Address = "Ruta 9 KM 102", City = "Rosario", Province = "Santa Fe", Type = PropertyTypeEnum.Land, Room = 0, Price = 50000m, Status = PropertyStatusEnum.Available, OwnerId = 3 },
                new Property { PropertyId = 4, Address = "Calle San Martín 789", City = "Mendoza", Province = "Mendoza", Type = PropertyTypeEnum.Local, Room = 2, Price = 95000m, Status = PropertyStatusEnum.Sold, OwnerId = 4 },
                new Property { PropertyId = 5, Address = "Los Álamos 101", City = "Córdoba", Province = "Córdoba", Type = PropertyTypeEnum.House, Room = 5, Price = 135000m, Status = PropertyStatusEnum.Available, OwnerId = 5 },
                new Property { PropertyId = 6, Address = "Mitre 202", City = "Santa Fe", Province = "Santa Fe", Type = PropertyTypeEnum.Apartment, Room = 2, Price = 80000m, Status = PropertyStatusEnum.Rented, OwnerId = 6 },
                new Property { PropertyId = 7, Address = "Belgrano 303", City = "Mar del Plata", Province = "Buenos Aires", Type = PropertyTypeEnum.Local, Room = 1, Price = 60000m, Status = PropertyStatusEnum.Available, OwnerId = 7 },
                new Property { PropertyId = 8, Address = "Camino Rural S/N", City = "San Luis", Province = "San Luis", Type = PropertyTypeEnum.Land, Room = 0, Price = 40000m, Status = PropertyStatusEnum.Reserved, OwnerId = 8 },
                new Property { PropertyId = 9, Address = "Av. Rivadavia 404", City = "Buenos Aires", Province = "Buenos Aires", Type = PropertyTypeEnum.Apartment, Room = 4, Price = 110000m, Status = PropertyStatusEnum.Sold, OwnerId = 9 },
                new Property { PropertyId = 10, Address = "Italia 505", City = "Neuquén", Province = "Neuquén", Type = PropertyTypeEnum.House, Room = 3, Price = 90000m, Status = PropertyStatusEnum.Available, OwnerId = 10 }
            );
            #endregion

            #region Datos semillas de 10 Transactions
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { TransactionId = 1, PropertyId = 1, ClientId = 1, EmployeeId = 1, Type = TransactionsTypeEnum.Rent, StartDate = new DateTime(2025, 01, 01), EndDate = new DateTime(2025, 06, 30), Amount = 1500m, Status = TransactionsStatusEnum.Active, IsDeleted = false },
                new Transaction { TransactionId = 2, PropertyId = 2, ClientId = 2, EmployeeId = 2, Type = TransactionsTypeEnum.Sale, StartDate = new DateTime(2025, 02, 01), EndDate = new DateTime(2025, 02, 28), Amount = 120000m, Status = TransactionsStatusEnum.Finished, IsDeleted = false },
                new Transaction { TransactionId = 3, PropertyId = 3, ClientId = 3, EmployeeId = 3, Type = TransactionsTypeEnum.Rent, StartDate = new DateTime(2025, 03, 05), EndDate = new DateTime(2025, 09, 04), Amount = 500m, Status = TransactionsStatusEnum.Active, IsDeleted = false },
                new Transaction { TransactionId = 4, PropertyId = 4, ClientId = 4, EmployeeId = 4, Type = TransactionsTypeEnum.Sale, StartDate = new DateTime(2025, 01, 15), EndDate = new DateTime(2025, 02, 15), Amount = 95000m, Status = TransactionsStatusEnum.Finished, IsDeleted = false },
                new Transaction { TransactionId = 5, PropertyId = 5, ClientId = 5, EmployeeId = 5, Type = TransactionsTypeEnum.Rent, StartDate = new DateTime(2025, 04, 01), EndDate = new DateTime(2025, 09, 30), Amount = 1350m, Status = TransactionsStatusEnum.Active, IsDeleted = false },
                new Transaction { TransactionId = 6, PropertyId = 6, ClientId = 6, EmployeeId = 1, Type = TransactionsTypeEnum.Sale, StartDate = new DateTime(2025, 05, 01), EndDate = new DateTime(2025, 05, 31), Amount = 80000m, Status = TransactionsStatusEnum.Finished, IsDeleted = false },
                new Transaction { TransactionId = 7, PropertyId = 7, ClientId = 7, EmployeeId = 2, Type = TransactionsTypeEnum.Rent, StartDate = new DateTime(2025, 06, 01), EndDate = new DateTime(2025, 11, 30), Amount = 600m, Status = TransactionsStatusEnum.Active, IsDeleted = false },
                new Transaction { TransactionId = 8, PropertyId = 8, ClientId = 8, EmployeeId = 3, Type = TransactionsTypeEnum.Sale, StartDate = new DateTime(2025, 07, 01), EndDate = new DateTime(2025, 07, 31), Amount = 40000m, Status = TransactionsStatusEnum.Cancelled, IsDeleted = false },
                new Transaction { TransactionId = 9, PropertyId = 9, ClientId = 9, EmployeeId = 4, Type = TransactionsTypeEnum.Rent, StartDate = new DateTime(2025, 08, 01), EndDate = new DateTime(2026, 01, 31), Amount = 1100m, Status = TransactionsStatusEnum.Active, IsDeleted = false },
                new Transaction { TransactionId = 10, PropertyId = 10, ClientId = 10, EmployeeId = 5, Type = TransactionsTypeEnum.Sale, StartDate = new DateTime(2025, 09, 01), EndDate = new DateTime(2025, 09, 30), Amount = 90000m, Status = TransactionsStatusEnum.Finished, IsDeleted = false }
            );
            #endregion

            #region Datos semillas de 10 Payments
            modelBuilder.Entity<Payment>().HasData(
                new Payment { PaymentId = 1, TransactionId = 1, PaymentDate = new DateTime(2025, 01, 02), Amount = 1500m, PaymentMethod = PaymentMethodEnum.Cash, Note = "Pago inicial en efectivo", IsDeleted = false },
                new Payment { PaymentId = 2, TransactionId = 2, PaymentDate = new DateTime(2025, 02, 02), Amount = 120000m, PaymentMethod = PaymentMethodEnum.CreditCard, Note = "Pago con tarjeta", IsDeleted = false },
                new Payment { PaymentId = 3, TransactionId = 3, PaymentDate = new DateTime(2025, 03, 06), Amount = 500m, PaymentMethod = PaymentMethodEnum.BankTransfer, Note = "Transferencia bancaria", IsDeleted = false },
                new Payment { PaymentId = 4, TransactionId = 4, PaymentDate = new DateTime(2025, 01, 16), Amount = 95000m, PaymentMethod = PaymentMethodEnum.CreditCard, Note = "Pago con Mastercard", IsDeleted = false },
                new Payment { PaymentId = 5, TransactionId = 5, PaymentDate = new DateTime(2025, 04, 02), Amount = 1350m, PaymentMethod = PaymentMethodEnum.Cash, Note = "Pago en mostrador", IsDeleted = false },
                new Payment { PaymentId = 6, TransactionId = 6, PaymentDate = new DateTime(2025, 05, 02), Amount = 80000m, PaymentMethod = PaymentMethodEnum.BankTransfer, Note = "Transferencia online", IsDeleted = false },
                new Payment { PaymentId = 7, TransactionId = 7, PaymentDate = new DateTime(2025, 06, 02), Amount = 600m, PaymentMethod = PaymentMethodEnum.Cash, Note = "Pago parcial en efectivo", IsDeleted = false },
                new Payment { PaymentId = 8, TransactionId = 8, PaymentDate = new DateTime(2025, 07, 02), Amount = 40000m, PaymentMethod = PaymentMethodEnum.CreditCard, Note = "Pago cancelado con tarjeta", IsDeleted = false },
                new Payment { PaymentId = 9, TransactionId = 9, PaymentDate = new DateTime(2025, 08, 02), Amount = 1100m, PaymentMethod = PaymentMethodEnum.BankTransfer, Note = "Transferencia programada", IsDeleted = false },
                new Payment { PaymentId = 10, TransactionId = 10, PaymentDate = new DateTime(2025, 09, 02), Amount = 90000m, PaymentMethod = PaymentMethodEnum.CreditCard, Note = "Pago final con tarjeta", IsDeleted = false }
            );
            #endregion

            #region Query filters para soft delete
            modelBuilder.Entity<Client>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Employee>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Owner>().HasQueryFilter(o => !o.IsDeleted);
            modelBuilder.Entity<Property>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Transaction>().HasQueryFilter(t => !t.IsDeleted);
            modelBuilder.Entity<Payment>().HasQueryFilter(p => !p.IsDeleted);
            #endregion
        }
    }
}