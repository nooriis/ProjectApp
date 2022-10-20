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
                columns: new[] { "CreatedDate", "EndingDate" },
                values: new object[] { new DateTime(2022, 10, 20, 18, 8, 11, 405, DateTimeKind.Local).AddTicks(5912), new DateTime(2022, 10, 20, 18, 8, 11, 405, DateTimeKind.Local).AddTicks(5985) });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "BidTime",
                value: new DateTime(2022, 10, 20, 18, 8, 11, 405, DateTimeKind.Local).AddTicks(6152));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "BidTime",
                value: new DateTime(2022, 10, 20, 18, 8, 11, 405, DateTimeKind.Local).AddTicks(6087));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AuctionDbs",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "CreatedDate", "EndingDate" },
                values: new object[] { new DateTime(2022, 10, 20, 18, 7, 40, 759, DateTimeKind.Local).AddTicks(5099), new DateTime(2022, 10, 20, 18, 7, 40, 759, DateTimeKind.Local).AddTicks(5141) });

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -2,
                column: "BidTime",
                value: new DateTime(2022, 10, 20, 18, 7, 40, 759, DateTimeKind.Local).AddTicks(5329));

            migrationBuilder.UpdateData(
                table: "BidDbs",
                keyColumn: "Id",
                keyValue: -1,
                column: "BidTime",
                value: new DateTime(2022, 10, 20, 18, 7, 40, 759, DateTimeKind.Local).AddTicks(5303));
        }
    }
}
