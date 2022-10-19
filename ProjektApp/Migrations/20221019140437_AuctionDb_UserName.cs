using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectApp.Migrations
{
    public partial class AuctionDb_UserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "BidDbs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AuctionDbs",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "UserName" },
                values: new object[] { new DateTime(2022, 10, 19, 16, 4, 37, 561, DateTimeKind.Local).AddTicks(8232), "zaedn@kth.se" });

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "Amount", "AuctionId", "BidTime" },
                values: new object[] { -1, 10500, -1, new DateTime(2022, 10, 19, 16, 4, 37, 561, DateTimeKind.Local).AddTicks(8459) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "BidDbs");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AuctionDbs");

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 18, 22, 46, 5, 919, DateTimeKind.Local).AddTicks(2142));
        }
    }
}
