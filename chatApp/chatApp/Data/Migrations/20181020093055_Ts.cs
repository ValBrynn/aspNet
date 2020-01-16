using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace chatApp.Data.Migrations
{
    public partial class Ts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "receiverID",
                table: "msg",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "message",
                table: "msg",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "sendTimeStample",
                table: "msg",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sendTimeStample",
                table: "msg");

            migrationBuilder.AlterColumn<string>(
                name: "receiverID",
                table: "msg",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "message",
                table: "msg",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
