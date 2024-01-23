using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagementService.Migrations
{
    /// <inheritdoc />
    public partial class AllModelsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PaymentShares = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    BarCode = table.Column<string>(type: "text", nullable: false),
                    MedicineType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    BranchName = table.Column<string>(type: "text", nullable: false),
                    BranchName1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Employee_Branch_BranchName",
                        column: x => x.BranchName,
                        principalTable: "Branch",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Branch_BranchName1",
                        column: x => x.BranchName1,
                        principalTable: "Branch",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BranchName",
                table: "Employee",
                column: "BranchName");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BranchName1",
                table: "Employee",
                column: "BranchName1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Medicine");

            migrationBuilder.DropTable(
                name: "Branch");
        }
    }
}
