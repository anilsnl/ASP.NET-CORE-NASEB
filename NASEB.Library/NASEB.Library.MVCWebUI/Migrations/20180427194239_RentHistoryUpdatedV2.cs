using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NASEB.Library.MVCWebUI.Migrations
{
    public partial class RentHistoryUpdatedV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.AddColumn<double>(
                name: "DelayFine",
                table: "Rents",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveredDate",
                table: "Rents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelayFine",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "DeliveredDate",
                table: "Rents");

         
        }
    }
}
