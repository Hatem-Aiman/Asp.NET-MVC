using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    country = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__city__031491A896834912", x => x.city_id);
                });

            migrationBuilder.CreateTable(
                name: "notstudent",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    join_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "vehicle",
                columns: table => new
                {
                    vehicle_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vehicle_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    seat = table.Column<int>(type: "int", nullable: true),
                    top_speed = table.Column<int>(type: "int", nullable: true),
                    driver_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vehicles__476B54923333A483", x => x.vehicle_id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    last_name = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    phone = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    city_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__customer__CD65CB8540B8FE0C", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK__customer__city_i__412EB0B6",
                        column: x => x.city_id,
                        principalTable: "city",
                        principalColumn: "city_id");
                });

            migrationBuilder.CreateTable(
                name: "driver",
                columns: table => new
                {
                    driver_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    driver_name = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    vehicle_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.driver_id);
                    table.ForeignKey(
                        name: "FK_driver_vehicle",
                        column: x => x.vehicle_id,
                        principalTable: "vehicle",
                        principalColumn: "vehicle_id");
                });

            migrationBuilder.CreateTable(
                name: "ride",
                columns: table => new
                {
                    ride_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start_city = table.Column<int>(type: "int", nullable: true),
                    end_city = table.Column<int>(type: "int", nullable: true),
                    start_time = table.Column<TimeOnly>(type: "time", nullable: true),
                    end_time = table.Column<TimeOnly>(type: "time", nullable: true),
                    vehicle_id = table.Column<int>(type: "int", nullable: false),
                    driver_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rides__C5B8C4F48EEB3DD3", x => x.ride_id);
                    table.ForeignKey(
                        name: "FK_Rides_Vehicles",
                        column: x => x.vehicle_id,
                        principalTable: "vehicle",
                        principalColumn: "vehicle_id");
                    table.ForeignKey(
                        name: "FK__Rides__End_City__3F466844",
                        column: x => x.end_city,
                        principalTable: "city",
                        principalColumn: "city_id");
                    table.ForeignKey(
                        name: "FK__Rides__Start_Cit__3E52440B",
                        column: x => x.start_city,
                        principalTable: "city",
                        principalColumn: "city_id");
                    table.ForeignKey(
                        name: "FK_ride_driver",
                        column: x => x.driver_id,
                        principalTable: "driver",
                        principalColumn: "driver_id");
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    ticket_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    ride_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ticket_id);
                    table.ForeignKey(
                        name: "FK_Tickets_Rides",
                        column: x => x.ride_id,
                        principalTable: "ride",
                        principalColumn: "ride_id");
                    table.ForeignKey(
                        name: "FK_Tickets_customers",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "customer_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_city_id",
                table: "customer",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_driver_vehicle_id",
                table: "driver",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_ride_driver_id",
                table: "ride",
                column: "driver_id");

            migrationBuilder.CreateIndex(
                name: "IX_ride_end_city",
                table: "ride",
                column: "end_city");

            migrationBuilder.CreateIndex(
                name: "IX_ride_start_city",
                table: "ride",
                column: "start_city");

            migrationBuilder.CreateIndex(
                name: "IX_ride_vehicle_id",
                table: "ride",
                column: "vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_customer_id",
                table: "ticket",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_ride_id",
                table: "ticket",
                column: "ride_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notstudent");

            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "ride");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "driver");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "vehicle");
        }
    }
}
