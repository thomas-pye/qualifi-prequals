using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace efmodels.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanId", "CreditLimit", "LenderName", "ProductName" },
                values: new object[] { Guid.NewGuid(), 1000001, "Lender 1", "Loan 1" });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanId", "CreditLimit", "LenderName", "ProductName" },
                values: new object[] { Guid.NewGuid(), 99999, "Lender 2", "Loan 2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
