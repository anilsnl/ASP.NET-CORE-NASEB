using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NASEB.Library.MVCWebUI.Migrations
{
    public partial class UniqueJeysUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
       
            migrationBuilder.CreateIndex(
                name: "IX_Members_TRIDNo",
                table: "Members",
                column: "TRIDNo",
                unique: true);

      
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropIndex(
                name: "IX_Members_TRIDNo",
                table: "Members");

        }
    }
}
