using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DOT.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("9e6e6f5b-4e1d-43ed-aae7-69617ba2a8b6"), "JK Rowling" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("4ef1735e-a2a6-4fe4-bab6-39d3e5d38d92"), "Agatha Christie" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AuthorID", "Title" },
                values: new object[] { new Guid("14c631b0-c96a-4bfa-8905-875b0111fd35"), new Guid("9e6e6f5b-4e1d-43ed-aae7-69617ba2a8b6"), "Harry Potter" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "AuthorID", "Title" },
                values: new object[] { new Guid("68bf8b1f-6381-42da-95c4-fc6ce2d0af9a"), new Guid("4ef1735e-a2a6-4fe4-bab6-39d3e5d38d92"), "Murder on the Orient Express" });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorID",
                table: "Books",
                column: "AuthorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
