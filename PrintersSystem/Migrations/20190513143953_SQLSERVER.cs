using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrintersSystem.Migrations
{
    public partial class SQLSERVER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Printer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Brand = table.Column<string>(maxLength: 20, nullable: false),
                    Model = table.Column<string>(maxLength: 20, nullable: false),
                    PrinterType = table.Column<int>(nullable: false),
                    Serial = table.Column<string>(maxLength: 20, nullable: false),
                    PersonInCharge = table.Column<string>(nullable: true),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Printer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Printer_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Technician = table.Column<string>(maxLength: 40, nullable: false),
                    PrinterId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenance_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Maintenance_Printer_PrinterId",
                        column: x => x.PrinterId,
                        principalTable: "Printer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Recepcion" },
                    { 2, "Sala de juntas" },
                    { 3, "Gerencia" },
                    { 4, "Facturacion" },
                    { 5, "Contabilidad" }
                });

            migrationBuilder.InsertData(
                table: "Printer",
                columns: new[] { "Id", "Brand", "LocationId", "Model", "Name", "PersonInCharge", "PrinterType", "Serial" },
                values: new object[,]
                {
                    { 1, "Epson", 1, "2010", "Printer1", "Arya", 3, "01021" },
                    { 23, "HP", 5, "2012", "Printer23", "Ricon", 0, "01021" },
                    { 22, "Sony", 5, "2011", "Printer22", "Samsa", 2, "01021" },
                    { 21, "Epson", 5, "2010", "Printer21", "Arya", 3, "01021" },
                    { 20, "Ricon", 4, "2014", "Printer20", "Bran", 3, "01021" },
                    { 19, "Dell", 4, "2013", "Printer19", "Robb", 1, "01021" },
                    { 18, "HP", 4, "2012", "Printer18", "Ricon", 0, "01021" },
                    { 17, "Sony", 4, "2011", "Printer17", "Samsa", 2, "01021" },
                    { 16, "Epson", 4, "2010", "Printer16", "Arya", 3, "01021" },
                    { 15, "Ricon", 3, "2014", "Printer15", "Bran", 3, "01021" },
                    { 14, "Dell", 3, "2013", "Printer14", "Robb", 1, "01021" },
                    { 24, "Dell", 5, "2013", "Printer24", "Robb", 1, "01021" },
                    { 13, "HP", 3, "2012", "Printer13", "Ricon", 0, "01021" },
                    { 11, "Epson", 3, "2010", "Printer11", "Arya", 3, "01021" },
                    { 10, "Ricon", 2, "2014", "Printer10", "Bran", 3, "01021" },
                    { 9, "Dell", 2, "2013", "Printer9", "Robb", 1, "01021" },
                    { 8, "HP", 2, "2012", "Printer8", "Ricon", 0, "01021" },
                    { 7, "Sony", 2, "2011", "Printer7", "Samsa", 2, "01021" },
                    { 6, "Epson", 2, "2010", "Printer6", "Arya", 3, "01021" },
                    { 5, "Ricon", 1, "2014", "Printer5", "Bran", 3, "01021" },
                    { 4, "Dell", 1, "2013", "Printer4", "Robb", 1, "01021" },
                    { 3, "HP", 1, "2012", "Printer3", "Ricon", 0, "01021" },
                    { 2, "Sony", 1, "2011", "Printer2", "Samsa", 2, "01021" },
                    { 12, "Sony", 3, "2011", "Printer12", "Samsa", 2, "01021" },
                    { 25, "Ricon", 5, "2014", "Printer25", "Bran", 3, "01021" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "Date", "LocationId", "Name", "PrinterId", "Technician" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 5, 13, 14, 39, 52, 594, DateTimeKind.Local).AddTicks(1921), 1, "Cambio Tinta1", 1, "John Snow" },
                    { 54, new DateTime(2019, 5, 31, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5008), 4, "Calibracion54", 18, "Dayneris" },
                    { 53, new DateTime(2019, 6, 1, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4975), 4, "Limpieza53", 18, "Cersei" },
                    { 52, new DateTime(2019, 5, 22, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4938), 4, "Cambio Tinta52", 18, "John Snow" },
                    { 51, new DateTime(2019, 5, 31, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4814), 4, "Calibracion51", 17, "Dayneris" },
                    { 50, new DateTime(2019, 5, 14, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4785), 4, "Limpieza50", 17, "Cersei" },
                    { 49, new DateTime(2019, 5, 31, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4754), 4, "Cambio Tinta49", 17, "John Snow" },
                    { 48, new DateTime(2019, 5, 21, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4724), 4, "Calibracion48", 16, "Dayneris" },
                    { 47, new DateTime(2019, 5, 22, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4695), 4, "Limpieza47", 16, "Cersei" },
                    { 46, new DateTime(2019, 5, 26, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4667), 4, "Cambio Tinta46", 16, "John Snow" },
                    { 45, new DateTime(2019, 5, 28, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4638), 3, "Calibracion45", 15, "Dayneris" },
                    { 44, new DateTime(2019, 5, 13, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4608), 3, "Limpieza44", 15, "Cersei" },
                    { 43, new DateTime(2019, 5, 31, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4576), 3, "Cambio Tinta43", 15, "John Snow" },
                    { 42, new DateTime(2019, 5, 31, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4545), 3, "Calibracion42", 14, "Dayneris" },
                    { 41, new DateTime(2019, 5, 26, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4515), 3, "Limpieza41", 14, "Cersei" },
                    { 40, new DateTime(2019, 5, 26, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4486), 3, "Cambio Tinta40", 14, "John Snow" },
                    { 55, new DateTime(2019, 5, 27, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5039), 4, "Cambio Tinta55", 19, "John Snow" },
                    { 39, new DateTime(2019, 5, 22, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4455), 3, "Calibracion39", 13, "Dayneris" },
                    { 56, new DateTime(2019, 5, 24, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5068), 4, "Limpieza56", 19, "Cersei" },
                    { 58, new DateTime(2019, 5, 30, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5127), 4, "Cambio Tinta58", 20, "John Snow" },
                    { 73, new DateTime(2019, 5, 24, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5721), 5, "Cambio Tinta73", 25, "John Snow" },
                    { 72, new DateTime(2019, 5, 27, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5692), 5, "Calibracion72", 24, "Dayneris" },
                    { 71, new DateTime(2019, 5, 30, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5664), 5, "Limpieza71", 24, "Cersei" },
                    { 70, new DateTime(2019, 5, 13, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5634), 5, "Cambio Tinta70", 24, "John Snow" },
                    { 69, new DateTime(2019, 5, 21, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5606), 5, "Calibracion69", 23, "Dayneris" },
                    { 68, new DateTime(2019, 5, 21, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5572), 5, "Limpieza68", 23, "Cersei" },
                    { 67, new DateTime(2019, 5, 20, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5386), 5, "Cambio Tinta67", 23, "John Snow" },
                    { 66, new DateTime(2019, 5, 16, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5357), 5, "Calibracion66", 22, "Dayneris" },
                    { 65, new DateTime(2019, 5, 27, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5326), 5, "Limpieza65", 22, "Cersei" },
                    { 64, new DateTime(2019, 5, 22, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5297), 5, "Cambio Tinta64", 22, "John Snow" },
                    { 63, new DateTime(2019, 5, 14, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5269), 5, "Calibracion63", 21, "Dayneris" },
                    { 62, new DateTime(2019, 5, 17, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5241), 5, "Limpieza62", 21, "Cersei" },
                    { 61, new DateTime(2019, 5, 25, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5212), 5, "Cambio Tinta61", 21, "John Snow" },
                    { 60, new DateTime(2019, 5, 15, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5185), 4, "Calibracion60", 20, "Dayneris" },
                    { 59, new DateTime(2019, 5, 25, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5155), 4, "Limpieza59", 20, "Cersei" },
                    { 57, new DateTime(2019, 5, 22, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5098), 4, "Calibracion57", 19, "Dayneris" },
                    { 74, new DateTime(2019, 5, 15, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5750), 5, "Limpieza74", 25, "Cersei" },
                    { 38, new DateTime(2019, 6, 1, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4424), 3, "Limpieza38", 13, "Cersei" },
                    { 36, new DateTime(2019, 5, 18, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4358), 3, "Calibracion36", 12, "Dayneris" },
                    { 16, new DateTime(2019, 5, 31, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3452), 2, "Cambio Tinta16", 6, "John Snow" },
                    { 15, new DateTime(2019, 5, 24, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3422), 1, "Calibracion15", 5, "Dayneris" },
                    { 14, new DateTime(2019, 5, 15, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3391), 1, "Limpieza14", 5, "Cersei" },
                    { 13, new DateTime(2019, 5, 17, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3360), 1, "Cambio Tinta13", 5, "John Snow" },
                    { 12, new DateTime(2019, 5, 30, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3327), 1, "Calibracion12", 4, "Dayneris" },
                    { 11, new DateTime(2019, 5, 26, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3296), 1, "Limpieza11", 4, "Cersei" },
                    { 10, new DateTime(2019, 5, 16, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3264), 1, "Cambio Tinta10", 4, "John Snow" },
                    { 9, new DateTime(2019, 6, 1, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3227), 1, "Calibracion9", 3, "Dayneris" },
                    { 8, new DateTime(2019, 5, 24, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3194), 1, "Limpieza8", 3, "Cersei" },
                    { 7, new DateTime(2019, 5, 31, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3162), 1, "Cambio Tinta7", 3, "John Snow" },
                    { 6, new DateTime(2019, 5, 29, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3128), 1, "Calibracion6", 2, "Dayneris" },
                    { 5, new DateTime(2019, 5, 30, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3090), 1, "Limpieza5", 2, "Cersei" },
                    { 4, new DateTime(2019, 5, 13, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3055), 1, "Cambio Tinta4", 2, "John Snow" },
                    { 3, new DateTime(2019, 5, 31, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3014), 1, "Calibracion3", 1, "Dayneris" },
                    { 2, new DateTime(2019, 5, 29, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(2947), 1, "Limpieza2", 1, "Cersei" },
                    { 17, new DateTime(2019, 6, 1, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3484), 2, "Limpieza17", 6, "Cersei" },
                    { 37, new DateTime(2019, 5, 28, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4393), 3, "Cambio Tinta37", 13, "John Snow" },
                    { 18, new DateTime(2019, 5, 19, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3649), 2, "Calibracion18", 6, "Dayneris" },
                    { 20, new DateTime(2019, 5, 30, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3714), 2, "Limpieza20", 7, "Cersei" },
                    { 35, new DateTime(2019, 5, 21, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4324), 3, "Limpieza35", 12, "Cersei" },
                    { 34, new DateTime(2019, 5, 23, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4290), 3, "Cambio Tinta34", 12, "John Snow" },
                    { 33, new DateTime(2019, 5, 18, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4131), 3, "Calibracion33", 11, "Dayneris" },
                    { 32, new DateTime(2019, 5, 17, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4100), 3, "Limpieza32", 11, "Cersei" },
                    { 31, new DateTime(2019, 5, 16, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4069), 3, "Cambio Tinta31", 11, "John Snow" },
                    { 30, new DateTime(2019, 5, 17, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4030), 2, "Calibracion30", 10, "Dayneris" },
                    { 29, new DateTime(2019, 5, 17, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(4000), 2, "Limpieza29", 10, "Cersei" },
                    { 28, new DateTime(2019, 5, 21, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3965), 2, "Cambio Tinta28", 10, "John Snow" },
                    { 27, new DateTime(2019, 5, 31, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3934), 2, "Calibracion27", 9, "Dayneris" },
                    { 26, new DateTime(2019, 5, 22, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3905), 2, "Limpieza26", 9, "Cersei" },
                    { 25, new DateTime(2019, 5, 15, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3873), 2, "Cambio Tinta25", 9, "John Snow" },
                    { 24, new DateTime(2019, 5, 28, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3841), 2, "Calibracion24", 8, "Dayneris" },
                    { 23, new DateTime(2019, 5, 14, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3808), 2, "Limpieza23", 8, "Cersei" },
                    { 22, new DateTime(2019, 5, 16, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3777), 2, "Cambio Tinta22", 8, "John Snow" },
                    { 21, new DateTime(2019, 5, 29, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3747), 2, "Calibracion21", 7, "Dayneris" },
                    { 19, new DateTime(2019, 5, 14, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(3684), 2, "Cambio Tinta19", 7, "John Snow" },
                    { 75, new DateTime(2019, 5, 31, 14, 39, 52, 597, DateTimeKind.Local).AddTicks(5780), 5, "Calibracion75", 25, "Dayneris" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_LocationId",
                table: "Maintenance",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_PrinterId",
                table: "Maintenance",
                column: "PrinterId");

            migrationBuilder.CreateIndex(
                name: "IX_Printer_LocationId",
                table: "Printer",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "Printer");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
