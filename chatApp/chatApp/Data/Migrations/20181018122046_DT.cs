using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace chatApp.Data.Migrations
{
    public partial class DT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "msg",
                columns: table => new
                {
                    msgID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDeleted = table.Column<int>(nullable: false),
                    isRead = table.Column<int>(nullable: false),
                    message = table.Column<string>(nullable: true),
                    receiverID = table.Column<string>(nullable: true),
                    senderID = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_msg", x => x.msgID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "msg");
        }
    }
}
