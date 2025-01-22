using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bank_management.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bankcards",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cardnumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    expirydate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankcards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    bankcardid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Customers_bankcards_bankcardid",
                        column: x => x.bankcardid,
                        principalTable: "bankcards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "branchemployee",
                columns: table => new
                {
                    branchid = table.Column<int>(type: "int", nullable: false),
                    employeesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branchemployee", x => new { x.branchid, x.employeesid });
                    table.ForeignKey(
                        name: "FK_branchemployee_Branches_branchid",
                        column: x => x.branchid,
                        principalTable: "Branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_branchemployee_Employees_employeesid",
                        column: x => x.employeesid,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    balance = table.Column<int>(type: "int", nullable: false),
                    customerid = table.Column<int>(type: "int", nullable: true),
                    customer_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_customerid",
                        column: x => x.customerid,
                        principalTable: "Customers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    amount = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    accountid = table.Column<int>(type: "int", nullable: true),
                    account_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_accountid",
                        column: x => x.accountid,
                        principalTable: "Accounts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_customerid",
                table: "Accounts",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "IX_branchemployee_employeesid",
                table: "branchemployee",
                column: "employeesid");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_bankcardid",
                table: "Customers",
                column: "bankcardid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_accountid",
                table: "Transactions",
                column: "accountid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "branchemployee");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "bankcards");
        }
    }
}
