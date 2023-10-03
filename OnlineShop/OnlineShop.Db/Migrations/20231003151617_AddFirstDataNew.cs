using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstDataNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0687cbc0-ef2e-4663-acb9-7403108b3e4c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("08de86ab-44b7-40a0-bf82-bab495db1443"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3fbb27c4-f757-4036-bbc4-116d5dcc5369"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("77761eb7-bbaf-4eda-8e05-d4f63baee132"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c90ea37f-d273-4f2e-96c7-857616d740a3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f7ecbb86-f42b-417e-8b27-f1899b569886"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("0549004c-8315-4cbc-9e51-186279df538d"), 33060m, "PCI-E 4.0; 1320 МГц; 1837 МГц; 12 Гб; GDDR6; 15000 МГц; 192 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb.webp", "NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb" },
                    { new Guid("09819a9a-e4fd-481a-9d14-2f63a67f4fd9"), 109580m, "PCI-E 4.0; 2535 МГц; 2535 МГц; 16 Гб; GDDR6X; 22400 МГц; 256 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4080 Gigabyte 16Gb.webp", "NVIDIA GeForce RTX 4080 Gigabyte 16Gb" },
                    { new Guid("394dbaed-c916-4ffa-a0ab-3e65a30f5379"), 48660m, "PCI-E 4.0; 1500 МГц; 1815 МГц; 8 Гб; GDDR6; 14000 МГц; 256 бит; 2xHDMI, 2xDisplayPort", "/images/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR.webp", "NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR" },
                    { new Guid("3c871feb-a5f7-438f-97a5-c805c58d8142"), 35720m, "PCI-E 4.0; 1720 МГц; 2755 МГц; 8 Гб; GDDR6; 18000 МГц; 128 бит; HDMI, 3xDisplayPort", "/images/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp", "AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC" },
                    { new Guid("574e0852-aeee-431d-bf1d-ca8c1269f3ed"), 182350m, "PCI-E 4.0; 2235 МГц; 2595 МГц; 24 Гб; GDDR6X; 21000 МГц; 384 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4090 ASUS 24Gb.webp", "NVIDIA GeForce RTX 4090 ASUS 24Gb" },
                    { new Guid("ba3d4660-bbb5-4771-a3dd-4e5ea75d4a0a"), 93320m, "PCI-E 4.0; 2310 МГц; 2760 МГц; 12 Гб; GDDR6X; 21000 МГц; 192 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4070 Ti MSI 12Gb.webp", "NVIDIA GeForce RTX 4070 Ti MSI 12Gb" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0549004c-8315-4cbc-9e51-186279df538d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("09819a9a-e4fd-481a-9d14-2f63a67f4fd9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("394dbaed-c916-4ffa-a0ab-3e65a30f5379"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3c871feb-a5f7-438f-97a5-c805c58d8142"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("574e0852-aeee-431d-bf1d-ca8c1269f3ed"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ba3d4660-bbb5-4771-a3dd-4e5ea75d4a0a"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("0687cbc0-ef2e-4663-acb9-7403108b3e4c"), 93320m, "PCI-E 4.0; 2310 МГц; 2760 МГц; 12 Гб; GDDR6X; 21000 МГц; 192 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4070 Ti MSI 12Gb.webp", "NVIDIA GeForce RTX 4070 Ti MSI 12Gb" },
                    { new Guid("08de86ab-44b7-40a0-bf82-bab495db1443"), 33060m, "PCI-E 4.0; 1320 МГц; 1837 МГц; 12 Гб; GDDR6; 15000 МГц; 192 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb.webp", "NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb" },
                    { new Guid("3fbb27c4-f757-4036-bbc4-116d5dcc5369"), 109580m, "PCI-E 4.0; 2535 МГц; 2535 МГц; 16 Гб; GDDR6X; 22400 МГц; 256 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4080 Gigabyte 16Gb.webp", "NVIDIA GeForce RTX 4080 Gigabyte 16Gb" },
                    { new Guid("77761eb7-bbaf-4eda-8e05-d4f63baee132"), 182350m, "PCI-E 4.0; 2235 МГц; 2595 МГц; 24 Гб; GDDR6X; 21000 МГц; 384 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4090 ASUS 24Gb.webp", "NVIDIA GeForce RTX 4090 ASUS 24Gb" },
                    { new Guid("c90ea37f-d273-4f2e-96c7-857616d740a3"), 48660m, "PCI-E 4.0; 1500 МГц; 1815 МГц; 8 Гб; GDDR6; 14000 МГц; 256 бит; 2xHDMI, 2xDisplayPort", "/images/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR.webp", "NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR" },
                    { new Guid("f7ecbb86-f42b-417e-8b27-f1899b569886"), 35720m, "PCI-E 4.0; 1720 МГц; 2755 МГц; 8 Гб; GDDR6; 18000 МГц; 128 бит; HDMI, 3xDisplayPort", "/images/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp", "AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC" }
                });
        }
    }
}
