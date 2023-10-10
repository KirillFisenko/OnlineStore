using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10843725-67ea-49fc-aabb-02e052a99067"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("714e5951-c5db-47a0-b896-a8f525a5ecdd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7fd9949a-dcbb-4e72-b5f8-6b965f539173"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86d54e31-78af-4885-926a-1dfb28ab76ce"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c81426d8-9bb0-400c-8d5d-803cec297970"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c957322a-a475-4ed1-9946-3fad864edaf4"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "CartItem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("09d624fb-14d1-464c-912d-37b06f9a318c"), 48660m, "PCI-E 4.0; 1500 МГц; 1815 МГц; 8 Гб; GDDR6; 14000 МГц; 256 бит; 2xHDMI, 2xDisplayPort", "/images/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR.webp", "NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR" },
                    { new Guid("89825af3-fe11-4b74-ba2c-9fad0ad669b0"), 93320m, "PCI-E 4.0; 2310 МГц; 2760 МГц; 12 Гб; GDDR6X; 21000 МГц; 192 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4070 Ti MSI 12Gb.webp", "NVIDIA GeForce RTX 4070 Ti MSI 12Gb" },
                    { new Guid("bdb743bd-15e0-4447-a8ce-f6030ec042c0"), 33060m, "PCI-E 4.0; 1320 МГц; 1837 МГц; 12 Гб; GDDR6; 15000 МГц; 192 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb.webp", "NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb" },
                    { new Guid("cb30e6e8-2fb9-471a-8b0b-25e0ba0376aa"), 35720m, "PCI-E 4.0; 1720 МГц; 2755 МГц; 8 Гб; GDDR6; 18000 МГц; 128 бит; HDMI, 3xDisplayPort", "/images/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp", "AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC" },
                    { new Guid("d1758a9c-fd60-4ba2-b878-4abb7df6b523"), 109580m, "PCI-E 4.0; 2535 МГц; 2535 МГц; 16 Гб; GDDR6X; 22400 МГц; 256 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4080 Gigabyte 16Gb.webp", "NVIDIA GeForce RTX 4080 Gigabyte 16Gb" },
                    { new Guid("d515c5c2-1bb7-498d-9575-96e2fcd1dd56"), 182350m, "PCI-E 4.0; 2235 МГц; 2595 МГц; 24 Гб; GDDR6X; 21000 МГц; 384 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4090 ASUS 24Gb.webp", "NVIDIA GeForce RTX 4090 ASUS 24Gb" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("09d624fb-14d1-464c-912d-37b06f9a318c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("89825af3-fe11-4b74-ba2c-9fad0ad669b0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("bdb743bd-15e0-4447-a8ce-f6030ec042c0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cb30e6e8-2fb9-471a-8b0b-25e0ba0376aa"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1758a9c-fd60-4ba2-b878-4abb7df6b523"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d515c5c2-1bb7-498d-9575-96e2fcd1dd56"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "CartItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("10843725-67ea-49fc-aabb-02e052a99067"), 35720m, "PCI-E 4.0; 1720 МГц; 2755 МГц; 8 Гб; GDDR6; 18000 МГц; 128 бит; HDMI, 3xDisplayPort", "/images/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp", "AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC" },
                    { new Guid("714e5951-c5db-47a0-b896-a8f525a5ecdd"), 93320m, "PCI-E 4.0; 2310 МГц; 2760 МГц; 12 Гб; GDDR6X; 21000 МГц; 192 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4070 Ti MSI 12Gb.webp", "NVIDIA GeForce RTX 4070 Ti MSI 12Gb" },
                    { new Guid("7fd9949a-dcbb-4e72-b5f8-6b965f539173"), 48660m, "PCI-E 4.0; 1500 МГц; 1815 МГц; 8 Гб; GDDR6; 14000 МГц; 256 бит; 2xHDMI, 2xDisplayPort", "/images/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR.webp", "NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR" },
                    { new Guid("86d54e31-78af-4885-926a-1dfb28ab76ce"), 109580m, "PCI-E 4.0; 2535 МГц; 2535 МГц; 16 Гб; GDDR6X; 22400 МГц; 256 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4080 Gigabyte 16Gb.webp", "NVIDIA GeForce RTX 4080 Gigabyte 16Gb" },
                    { new Guid("c81426d8-9bb0-400c-8d5d-803cec297970"), 33060m, "PCI-E 4.0; 1320 МГц; 1837 МГц; 12 Гб; GDDR6; 15000 МГц; 192 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb.webp", "NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb" },
                    { new Guid("c957322a-a475-4ed1-9946-3fad864edaf4"), 182350m, "PCI-E 4.0; 2235 МГц; 2595 МГц; 24 Гб; GDDR6X; 21000 МГц; 384 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4090 ASUS 24Gb.webp", "NVIDIA GeForce RTX 4090 ASUS 24Gb" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Carts_CartId",
                table: "CartItem",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
