using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MextFullstackSaaS.Infrastructure.Persistence.Migrations.ApplicationDB
{
    /// <inheritdoc />
    public partial class PaymentRelatedEntitiesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConversationId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BasketId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Token = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    PaidPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CurrencyCode = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Note = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    RefundedAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    UserPaymentDetail = table.Column<string>(type: "jsonb", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPayments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPaymentHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    UserPaymentId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ModifiedByUserId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPaymentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPaymentHistories_UserPayments_UserPaymentId",
                        column: x => x.UserPaymentId,
                        principalTable: "UserPayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "338639c6-9402-4e6c-b2b9-14f9cb819b11", "AQAAAAIAAYagAAAAEI0SaGs/Xxoag/NwP9GKJZKpuyODSZfKD8PVggrpYZiz1Pbc1gCT5axsbqUs7/Y1fA==" });

            migrationBuilder.CreateIndex(
                name: "IX_UserPaymentHistories_UserPaymentId",
                table: "UserPaymentHistories",
                column: "UserPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPayments_UserId",
                table: "UserPayments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPaymentHistories");

            migrationBuilder.DropTable(
                name: "UserPayments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("35c16d2a-f25b-4701-9a74-ea1fb7ed6d93"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6db5ed01-c869-4105-8b39-1bc0e61d67e9", "AQAAAAIAAYagAAAAEIgn2p1xMpbeT7PXv3xsnySDQAiXqaKgqD3nFkNs3SFZk81h8LhuL+c4iSGNU3bcew==" });
        }
    }
}
