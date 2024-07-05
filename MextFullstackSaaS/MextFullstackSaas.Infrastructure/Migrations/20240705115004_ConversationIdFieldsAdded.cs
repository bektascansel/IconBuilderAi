using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MextFullstackSaaS.Infrastructure.Persistence.Migrations.ApplicationDB
{
    /// <inheritdoc />
    public partial class ConversationIdFieldsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "UserPayments");

            migrationBuilder.AddColumn<string>(
                name: "ConversationId",
                table: "UserPaymentHistories",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "26138b63-8237-45e0-a10c-68d5097bdbbf", "AQAAAAIAAYagAAAAEJVC+1MfpcUzPSS88jPfABIaLC6vMhbCCdA2Kt22CuC5yacWbA8P1O4HHQxwwPw2sQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "UserPaymentHistories");

            migrationBuilder.AddColumn<string>(
                name: "ConversationId",
                table: "UserPayments",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "338639c6-9402-4e6c-b2b9-14f9cb819b11", "AQAAAAIAAYagAAAAEI0SaGs/Xxoag/NwP9GKJZKpuyODSZfKD8PVggrpYZiz1Pbc1gCT5axsbqUs7/Y1fA==" });
        }
    }
}
