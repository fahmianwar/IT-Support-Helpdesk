using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_M_Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Priorities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Priorities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_StatusCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_StatusCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Review = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Cases_TB_M_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TB_M_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Cases_TB_M_Priorities_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "TB_M_Priorities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Users_TB_M_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "TB_M_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Convertations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Convertations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Convertations_TB_M_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "TB_M_Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Convertations_TB_M_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_M_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    StatusCodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Histories_TB_M_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "TB_M_Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Histories_TB_M_StatusCodes_StatusCodeId",
                        column: x => x.StatusCodeId,
                        principalTable: "TB_M_StatusCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_M_Histories_TB_M_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "TB_M_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_M_Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConvertationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_M_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_M_Attachments_TB_M_Convertations_ConvertationId",
                        column: x => x.ConvertationId,
                        principalTable: "TB_M_Convertations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Attachments_ConvertationId",
                table: "TB_M_Attachments",
                column: "ConvertationId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Cases_CategoryId",
                table: "TB_M_Cases",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Cases_PriorityId",
                table: "TB_M_Cases",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Convertations_CaseId",
                table: "TB_M_Convertations",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Convertations_UserId",
                table: "TB_M_Convertations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Histories_CaseId",
                table: "TB_M_Histories",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Histories_StatusCodeId",
                table: "TB_M_Histories",
                column: "StatusCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Histories_UserId",
                table: "TB_M_Histories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_M_Users_RoleId",
                table: "TB_M_Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_M_Attachments");

            migrationBuilder.DropTable(
                name: "TB_M_Histories");

            migrationBuilder.DropTable(
                name: "TB_M_Convertations");

            migrationBuilder.DropTable(
                name: "TB_M_StatusCodes");

            migrationBuilder.DropTable(
                name: "TB_M_Cases");

            migrationBuilder.DropTable(
                name: "TB_M_Users");

            migrationBuilder.DropTable(
                name: "TB_M_Categories");

            migrationBuilder.DropTable(
                name: "TB_M_Priorities");

            migrationBuilder.DropTable(
                name: "TB_M_Roles");
        }
    }
}
