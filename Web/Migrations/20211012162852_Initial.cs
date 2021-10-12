﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Nickname = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Wins = table.Column<int>(type: "INTEGER", nullable: false),
                    Losses = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Races",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BestTime = table.Column<int>(type: "INTEGER", nullable: false),
                    Winner = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Races", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Model = table.Column<int>(type: "INTEGER", nullable: false),
                    Nickname = table.Column<string>(type: "TEXT", nullable: true),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    TopSpeed = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    DriverId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DriverRace",
                columns: table => new
                {
                    ParticipantsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RacesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverRace", x => new { x.ParticipantsId, x.RacesId });
                    table.ForeignKey(
                        name: "FK_DriverRace_Drivers_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverRace_Races_RacesId",
                        column: x => x.RacesId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DriverId",
                table: "Cars",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_DriverRace_RacesId",
                table: "DriverRace",
                column: "RacesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "DriverRace");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Races");
        }
    }
}
