using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MextFullstackSaas.Infrastructure.Persistence.Migrations.ApplicationDB
{
    /// <inheritdoc />
    public partial class OrderDescriptionFielAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Orders",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "740c6182-fb92-4b55-b8dc-c77122c0a697", "AQAAAAIAAYagAAAAENm57TKAt9RO9hiibWJZOUK3OLCdRBXf2cqH3VFngK5Ysedx+ZePALqPWyMqsk4aUA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0a1ceb26-8309-46c0-8d74-2904cdad8daa", "AQAAAAIAAYagAAAAEB3o5F7NgVexx9bntbfkAAbILCdOkavj63VifVAcncPwrj4UWBCNcVEcVAY2AxemVQ==" });
        }
    }
}
