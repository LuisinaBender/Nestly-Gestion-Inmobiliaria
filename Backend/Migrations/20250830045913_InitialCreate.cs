using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Document = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Document = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Document = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Province = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Room = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OwnerId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Properties_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Owners_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "Owners",
                        principalColumn: "OwnerId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ClientId1 = table.Column<int>(type: "int", nullable: true),
                    EmployeeId1 = table.Column<int>(type: "int", nullable: true),
                    PropertyId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Clients_ClientId1",
                        column: x => x.ClientId1,
                        principalTable: "Clients",
                        principalColumn: "ClientId");
                    table.ForeignKey(
                        name: "FK_Transactions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Transactions_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Properties_PropertyId1",
                        column: x => x.PropertyId1,
                        principalTable: "Properties",
                        principalColumn: "PropertyId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Document", "Email", "FirstName", "IsDeleted", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "12345678", "juanperez@hotmail.com", "Juan", false, "Perez", "555-1234" },
                    { 2, "87654321", "mariagomez@hotmail.com", "Maria", false, "Gomez", "555-5678" },
                    { 3, "11223344", "carloslopez@hotmail.com", "Carlos", false, "Lopez", "555-8765" },
                    { 4, "44332211", "anamartinez@hotmail.com", "Ana", false, "Martinez", "555-4321" },
                    { 5, "55667788", "luisrodri@hotmail.com", "Luis", false, "Rodriguez", "555-6789" },
                    { 6, "88776655", "soffer@hotmail.com", "Sofia", false, "Fernandez", "555-9876" },
                    { 7, "99887766", "diegosanchez@hotmail.com", "Diego", false, "Sanchez", "555-5432" },
                    { 8, "66778899", "lauraramirez@hotmail.com", "Laura", false, "Ramirez", "555-2109" },
                    { 9, "33445566", "jorgetorres@hotmail.com", "Jorge", false, "Torres", "555-6543" },
                    { 10, "22113344", "elena@hotmail.com", "Elena", false, "Vargas", "555-3210" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Document", "Email", "FirstName", "IsDeleted", "LastName", "Phone", "Role" },
                values: new object[,]
                {
                    { 1, "12345678", "pedro.alvarez@test.com", "Pedro", false, "Alvarez", "555-1111", 1 },
                    { 2, "87654321", "marta.blanco@test.com", "Marta", false, "Blanco", "555-2222", 0 },
                    { 3, "11223344", "javier.cruz@test.com", "Javier", false, "Cruz", "555-3333", 0 },
                    { 4, "44332211", "lucia.duarte@test.com", "Lucia", false, "Duarte", "555-4444", 2 },
                    { 5, "55667788", "alberto.espinoza@test.com", "Alberto", false, "Espinoza", "555-5555", 0 }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "Address", "Document", "Email", "FirstName", "IsDeleted", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Av. Libertad 123", "10111222", "ricardo.mendoza@test.com", "Ricardo", false, "Mendoza", "555-6001" },
                    { 2, "Calle San Martín 456", "20212223", "claudia.ortiz@test.com", "Claudia", false, "Ortiz", "555-6002" },
                    { 3, "Bv. Belgrano 789", "30313233", "fernando.silva@test.com", "Fernando", false, "Silva", "555-6003" },
                    { 4, "Ruta 8 Km 12", "40414243", "gabriela.moreno@test.com", "Gabriela", false, "Moreno", "555-6004" },
                    { 5, "Pasaje Mitre 321", "50515253", "hernan.castro@test.com", "Hernan", false, "Castro", "555-6005" },
                    { 6, "Av. Rivadavia 654", "60616263", "mariana.acosta@test.com", "Mariana", false, "Acosta", "555-6006" },
                    { 7, "Calle Italia 432", "70717273", "jorge.suarez@test.com", "Jorge", false, "Suarez", "555-6007" },
                    { 8, "San Juan 876", "80818283", "patricia.vega@test.com", "Patricia", false, "Vega", "555-6008" },
                    { 9, "Mitre 147", "90919293", "diego.romero@test.com", "Diego", false, "Romero", "555-6009" },
                    { 10, "Dorrego 258", "10011002", "silvia.herrera@test.com", "Silvia", false, "Herrera", "555-6010" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "PropertyId", "Address", "City", "IsDeleted", "OwnerId", "OwnerId1", "Price", "Province", "Room", "Status", "Type" },
                values: new object[,]
                {
                    { 1, "Calle 123", "San Justo", false, 1, null, 75000m, "Santa Fe", 4, 0, 0 },
                    { 2, "Av. Libertador 456", "Buenos Aires", false, 2, null, 120000m, "Buenos Aires", 3, 1, 1 },
                    { 3, "Ruta 9 KM 102", "Rosario", false, 3, null, 50000m, "Santa Fe", 0, 0, 2 },
                    { 4, "Calle San Martín 789", "Mendoza", false, 4, null, 95000m, "Mendoza", 2, 3, 3 },
                    { 5, "Los Álamos 101", "Córdoba", false, 5, null, 135000m, "Córdoba", 5, 0, 0 },
                    { 6, "Mitre 202", "Santa Fe", false, 6, null, 80000m, "Santa Fe", 2, 2, 1 },
                    { 7, "Belgrano 303", "Mar del Plata", false, 7, null, 60000m, "Buenos Aires", 1, 0, 3 },
                    { 8, "Camino Rural S/N", "San Luis", false, 8, null, 40000m, "San Luis", 0, 1, 2 },
                    { 9, "Av. Rivadavia 404", "Buenos Aires", false, 9, null, 110000m, "Buenos Aires", 4, 3, 1 },
                    { 10, "Italia 505", "Neuquén", false, 10, null, 90000m, "Neuquén", 3, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "ClientId", "ClientId1", "EmployeeId", "EmployeeId1", "EndDate", "IsDeleted", "PropertyId", "PropertyId1", "StartDate", "Status", "Type" },
                values: new object[,]
                {
                    { 1, 1500m, 1, null, 1, null, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 2, 120000m, 2, null, 2, null, new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, null, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 3, 500m, 3, null, 3, null, new DateTime(2025, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, null, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 4, 95000m, 4, null, 4, null, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, null, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 5, 1350m, 5, null, 5, null, new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, null, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 6, 80000m, 6, null, 1, null, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6, null, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 7, 600m, 7, null, 2, null, new DateTime(2025, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 7, null, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 8, 40000m, 8, null, 3, null, new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 8, null, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 9, 1100m, 9, null, 4, null, new DateTime(2026, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 9, null, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0 },
                    { 10, 90000m, 10, null, 5, null, new DateTime(2025, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 10, null, new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "PaymentId", "Amount", "IsDeleted", "Note", "PaymentDate", "PaymentMethod", "TransactionId" },
                values: new object[,]
                {
                    { 1, 1500m, false, "Pago inicial en efectivo", new DateTime(2025, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1 },
                    { 2, 120000m, false, "Pago con tarjeta", new DateTime(2025, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, 500m, false, "Transferencia bancaria", new DateTime(2025, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 4, 95000m, false, "Pago con Mastercard", new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 5, 1350m, false, "Pago en mostrador", new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 5 },
                    { 6, 80000m, false, "Transferencia online", new DateTime(2025, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6 },
                    { 7, 600m, false, "Pago parcial en efectivo", new DateTime(2025, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 7 },
                    { 8, 40000m, false, "Pago cancelado con tarjeta", new DateTime(2025, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8 },
                    { 9, 1100m, false, "Transferencia programada", new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9 },
                    { 10, 90000m, false, "Pago final con tarjeta", new DateTime(2025, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TransactionId",
                table: "Payments",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerId",
                table: "Properties",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OwnerId1",
                table: "Properties",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientId",
                table: "Transactions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientId1",
                table: "Transactions",
                column: "ClientId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmployeeId",
                table: "Transactions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_EmployeeId1",
                table: "Transactions",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PropertyId",
                table: "Transactions",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_PropertyId1",
                table: "Transactions",
                column: "PropertyId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
