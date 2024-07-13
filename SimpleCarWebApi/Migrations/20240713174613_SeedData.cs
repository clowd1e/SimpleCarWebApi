using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpleCarWebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CarBodyTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SUV" },
                    { 2, "Sedan" },
                    { 3, "Convertible" },
                    { 4, "Coupe" }
                });

            migrationBuilder.InsertData(
                table: "CarBrands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Audi" },
                    { 2, "Alfa Romeo" },
                    { 3, "Dodge" },
                    { 4, "BMW" },
                    { 5, "Hyundai" },
                    { 6, "Nissan" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarBodyTypeId", "CarBrandId", "Description", "Model", "Price", "TopSpeed", "Year" },
                values: new object[,]
                {
                    { 1, 1, 1, "Audi Q3 1.4 TFSI is a 2011 SUV model with 6 speed manual transmission.\r\n                        With a power of 110 KW you can reach 0-100km h in just 9,2 seconds and a maximum speed of 203 km/h with an urban consumption of 7,4 l/100km.\r\n                        The engine has a capacity of 1395 cc with 4, in line cylinders and 4 valves per cylinders.\r\n                        Also this model has a weight of with coil springs front suspension and a coil springs rear suspension.", "Audi Q3 1.4 TFSI", 36.430m, 203.0, 2019 },
                    { 2, 2, 2, "Alfa Romeo 156 1.6 T.Spark 16V Progression is a 2002 Sedan model with 5 speed manual transmission.\r\n                        With a power of 88 KW you can reach 0-100km h in just 10,5 seconds and a maximum speed of 200 km/h with an urban consumption of 11,4 l/100km.\r\n                        The engine has a capacity of 1598 cc with 4, in line cylinders and 4 valves per cylinders.\r\n                        Also this model has a weight of with coil springs front suspension and a coil springs rear suspension.", "Alfa Romeo 156 1.6 T.Spark 16V Progression", 24.685m, 200.0, 2002 },
                    { 3, 2, 3, "Dodge Avenger 2.0 SE is a 2007 Sedan model with 5 speed manual transmission.\r\n                        With a power of 115 KW you can reach 0-100km h in just 10,8 seconds and a maximum speed of 200 km/h with an urban consumption of 10,7 l/100km.\r\n                        The engine has a capacity of 1998 cc with 4, in line cylinders and 4 valves per cylinders.\r\n                        Also this model has a weight of with coil springs front suspension and a coil springs rear suspension.", "Dodge Avenger 2.0 SE", 24.450m, 204.0, 2007 },
                    { 4, 3, 4, "BMW 840i Cabrio is a 2019 Convertible model with 8 speed automatic.\r\n                        With a power of 250 KW you can reach 0-100km h in just 5,3 seconds and a maximum speed of 250 km/h with an urban consumption of 9,1 l/100km.\r\n                        The engine has a capacity of 2998 cc with 6, in line cylinders and 4 valves per cylinders.\r\n                        Also this model has a weight of with coil springs front suspension and a coil springs rear suspension.", "BMW 840i Cabrio", 120.141m, 250.0, 2019 },
                    { 5, 4, 5, "Hyundai Coupe 2.0i FX DynamicVersion is a 2004 Coupe model with 5 speed manual transmission.\r\n                        With a power of 105 KW you can reach 0-100km h in just 9,1 seconds and a maximum speed of 208 km/h with an urban consumption of 10,9 l/100km.\r\n                        The engine has a capacity of 1975 cc with 4, in line cylinders and 4 valves per cylinders.\r\n                        Also this model has a weight of with coil springs front suspension and a coil springs rear suspension.", "Hyundai Coupe 2.0i FX DynamicVersion", 26.195m, 208.0, 2004 },
                    { 6, 1, 6, "Nissan Juke 1.6 Juke is a 2010 SUV model with 5 speed manual transmission.\r\n                        With a power of 68 KW you can reach 0-100km h in just 12,0 seconds and a maximum speed of 168 km/h with an urban consumption of 7,6 l/100km.\r\n                        The engine has a capacity of 1598 cc with 4, in line cylinders and 4 valves per cylinders.\r\n                        Also this model has a weight of with coil springs front suspension and a coil springs rear suspension.", "Nissan Juke 1.6 Juke", 19.490m, 168.0, 2010 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CarBodyTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarBodyTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarBodyTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarBodyTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CarBrands",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
