using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NASEB.MVCWebUI.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 250, nullable: false),
                    BranchName = table.Column<string>(maxLength: 150, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    BranchID = table.Column<int>(nullable: false),
                    EMail = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Branches_BranchID",
                        column: x => x.BranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                       onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarName = table.Column<string>(maxLength: 150, nullable: false),
                    Detail = table.Column<string>(maxLength: 200, nullable: false),
                    ExistingBranchID = table.Column<int>(nullable: false),
                    LicenseInfo = table.Column<string>(nullable: false),
                    Plate = table.Column<string>(maxLength: 15, nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_Cars_Branches_ExistingBranchID",
                        column: x => x.ExistingBranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cars_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                       onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(maxLength: 500, nullable: false),
                    AuthorizedName = table.Column<string>(maxLength: 200, nullable: false),
                    CompanyName = table.Column<string>(maxLength: 200, nullable: false),
                    Fax = table.Column<string>(maxLength: 15, nullable: true),
                    OtherPhone = table.Column<string>(maxLength: 15, nullable: true),
                    Phone = table.Column<string>(maxLength: 15, nullable: false),
                    TaskAdministration = table.Column<string>(maxLength: 100, nullable: false),
                    TaskNumber = table.Column<string>(maxLength: 15, nullable: false),
                    TradeRegisterNumber = table.Column<string>(maxLength: 20, nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    isActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_Companies_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                       onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    LogID = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Detail = table.Column<string>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.LogID);
                    table.ForeignKey(
                        name: "FK_Log_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                       onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                       onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                       onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    CompanyID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PasportNumber = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    Surname = table.Column<string>(maxLength: 100, nullable: false),
                    TRIDNo = table.Column<long>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    isCorporate = table.Column<bool>(nullable: false),
                    isTRCitizen = table.Column<bool>(nullable: false),
                    isTRIDVerified = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.ForeignKey(
                        name: "FK_Customers_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                       onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    RentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CarID = table.Column<int>(nullable: false),
                    CompanyID = table.Column<int>(nullable: true),
                    CustomerID = table.Column<int>(nullable: false),
                    DamagePrice = table.Column<double>(nullable: true),
                    DelayFine = table.Column<double>(nullable: true),
                    DeliveredBranchID = table.Column<int>(nullable: false),
                    DeliveredDate = table.Column<DateTime>(nullable: true),
                    PaymentComplate = table.Column<bool>(nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    RemaindDebt = table.Column<double>(nullable: false),
                    RentBranchID = table.Column<int>(nullable: false),
                    RentDay = table.Column<int>(nullable: false),
                    RentEndDate = table.Column<DateTime>(nullable: false),
                    RentStartDate = table.Column<DateTime>(nullable: false),
                    TotalRentPrice = table.Column<double>(nullable: false),
                    TrafficTicket = table.Column<double>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    isCommercial = table.Column<bool>(nullable: false),
                    isComplate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.RentID);
                    table.ForeignKey(
                        name: "FK_Rents_Cars_CarID",
                        column: x => x.CarID,
                        principalTable: "Cars",
                        principalColumn: "CarID",
                       onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rents_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rents_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                       onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rents_Branches_DeliveredBranchID",
                        column: x => x.DeliveredBranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                       onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rents_Branches_RentBranchID",
                        column: x => x.RentBranchID,
                        principalTable: "Branches",
                        principalColumn: "BranchID",
                       onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rents_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                       onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ExistingBranchID",
                table: "Cars",
                column: "ExistingBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserID",
                table: "Cars",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserID",
                table: "Companies",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyID",
                table: "Customers",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TRIDNo",
                table: "Customers",
                column: "TRIDNo",
                unique: true,
                filter: "[TRIDNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserID",
                table: "Customers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Log_UserID",
                table: "Log",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CarID",
                table: "Rents",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CompanyID",
                table: "Rents",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CustomerID",
                table: "Rents",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_DeliveredBranchID",
                table: "Rents",
                column: "DeliveredBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_RentBranchID",
                table: "Rents",
                column: "RentBranchID");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_UserID",
                table: "Rents",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleID",
                table: "UserRole",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BranchID",
                table: "Users",
                column: "BranchID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}
