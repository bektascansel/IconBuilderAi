using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MextFullstackSaaS.Infrastructure.Persistence.Migrations.ApplicationDB
{
    /// <inheritdoc />
    public partial class UserPaymentTokenIndexAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a20acbe4-f1fa-484d-859c-4b17bd776e9b", "AQAAAAIAAYagAAAAEPfXLNAJpRJlwcS0ZZVtBaP296aoaE1/FesXotgOU6sJRr1awRsbk6omtKw+/YuejA==" });

            migrationBuilder.CreateIndex(
                name: "IX_UserPayments_Token",
                table: "UserPayments",
                column: "Token",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserPayments_Token",
                table: "UserPayments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "26138b63-8237-45e0-a10c-68d5097bdbbf", "AQAAAAIAAYagAAAAEJVC+1MfpcUzPSS88jPfABIaLC6vMhbCCdA2Kt22CuC5yacWbA8P1O4HHQxwwPw2sQ==" });
        }
    }
}
