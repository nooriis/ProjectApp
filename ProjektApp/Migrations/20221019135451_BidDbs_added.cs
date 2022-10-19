using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectApp.Migrations
{
    public partial class BidDbs_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 19, 15, 54, 51, 496, DateTimeKind.Local).AddTicks(1993));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "BidTime",
                value: new DateTime(2022, 10, 19, 15, 54, 51, 496, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.InsertData(
                table: "BidDbs",
                columns: new[] { "Id", "Amount", "AuctionId", "BidTime" },
                values: new object[] { -2, 13000, -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "CreatedDate",
                value: new DateTime(2022, 10, 19, 15, 44, 58, 827, DateTimeKind.Local).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "BidTime",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
