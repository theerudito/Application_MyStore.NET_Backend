using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store.Database.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppCode",
                columns: table => new
                {
                    IdCode = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppCode", x => x.IdCode);
                });

            migrationBuilder.CreateTable(
                name: "Auth",
                columns: table => new
                {
                    IdAuth = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    User = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Direction = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Role = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth", x => x.IdAuth);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    IdBrand = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Brand = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.IdBrand);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    IdCity = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.IdCity);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DNI = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    FisrtName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Direction = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    IdCompany = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    OwnerCompany = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    DirectionCompany = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    EmailCompany = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    DNICompany = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    PhoneCompany = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    NumDocumentCompany = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SerieOneCompany = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    SerieTwoCompany = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    DataBaseName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TypeDocument = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IvaCompany = table.Column<decimal>(type: "TEXT", nullable: false),
                    CoinCompany = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.IdCompany);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NameProduct = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    CodeProduct = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Brand = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    PriceUnitary = table.Column<decimal>(type: "TEXT", nullable: false),
                    PriceTotal = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false),
                    Iva = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.IdProduct);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    IdCart = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdProduct = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductsIdProduct = table.Column<int>(type: "INTEGER", nullable: true),
                    IdClient = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientsIdClient = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.IdCart);
                    table.ForeignKey(
                        name: "FK_Cart_Client_ClientsIdClient",
                        column: x => x.ClientsIdClient,
                        principalTable: "Client",
                        principalColumn: "IdClient");
                    table.ForeignKey(
                        name: "FK_Cart_Product_ProductsIdProduct",
                        column: x => x.ProductsIdProduct,
                        principalTable: "Product",
                        principalColumn: "IdProduct");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ClientsIdClient",
                table: "Cart",
                column: "ClientsIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductsIdProduct",
                table: "Cart",
                column: "ProductsIdProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppCode");

            migrationBuilder.DropTable(
                name: "Auth");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
