using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TowhidulsBHsoftWebStore.WebAPI.Migrations
{
    public partial class CodeFirst210919 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(nullable: false),
                    AdminName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    BuyerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuyerName = table.Column<string>(maxLength: 100, nullable: false),
                    CompanyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.BuyerID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierID = table.Column<int>(nullable: false),
                    SupplierName = table.Column<string>(maxLength: 100, nullable: false),
                    BuyerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: false),
                    AdminID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_Admin_Company",
                        column: x => x.AdminID,
                        principalTable: "Admin",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionID = table.Column<int>(nullable: false),
                    BuyerNOS = table.Column<int>(nullable: false),
                    SupplierNOS = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionID);
                    table.ForeignKey(
                        name: "FK_Permissions_Users",
                        column: x => x.UserID,
                        principalTable: "Admin",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuyerRequestSubmission",
                columns: table => new
                {
                    RequestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReuestDetails = table.Column<string>(maxLength: 500, nullable: false),
                    BuyerID = table.Column<int>(nullable: false),
                    SupplierID = table.Column<int>(nullable: false),
                    CompanyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerRequestSubmission", x => x.RequestID);
                    table.ForeignKey(
                        name: "FK_BuyerRequestSubmission2_Buyer",
                        column: x => x.BuyerID,
                        principalTable: "Buyer",
                        principalColumn: "BuyerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierProcessNpractice",
                columns: table => new
                {
                    ProcessID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProcessName = table.Column<string>(maxLength: 100, nullable: false),
                    Practice = table.Column<string>(maxLength: 500, nullable: false),
                    SupplierID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProcessNpractice", x => x.ProcessID);
                    table.ForeignKey(
                        name: "FK_SupplierProcessNpractice2_Supplier",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerRequestSubmission_BuyerID",
                table: "BuyerRequestSubmission",
                column: "BuyerID");

            migrationBuilder.CreateIndex(
                name: "IX_Company_AdminID",
                table: "Company",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserID",
                table: "Permissions",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProcessNpractice_SupplierID",
                table: "SupplierProcessNpractice",
                column: "SupplierID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyerRequestSubmission");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "SupplierProcessNpractice");

            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
