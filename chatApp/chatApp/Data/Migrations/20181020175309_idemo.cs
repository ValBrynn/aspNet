using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace chatApp.Data.Migrations
{
    public partial class idemo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "msg",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "msg",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
