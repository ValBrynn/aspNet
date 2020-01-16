using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace chatApp.Data.Migrations
{
    public partial class Fin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userDateTimeInfo",
                table: "userDateTimeInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "userDateTimeInfo",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_userDateTimeInfo",
                table: "userDateTimeInfo",
                column: "LogInDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userDateTimeInfo",
                table: "userDateTimeInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "userDateTimeInfo",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_userDateTimeInfo",
                table: "userDateTimeInfo",
                column: "Id");
        }
    }
}
