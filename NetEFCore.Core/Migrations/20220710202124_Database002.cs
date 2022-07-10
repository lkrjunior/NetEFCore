using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetEFCore.Core.Migrations
{
    public partial class Database002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegisterDate",
                table: "PessoaJuridicas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisterDate",
                table: "PessoaJuridicas");
        }
    }
}
