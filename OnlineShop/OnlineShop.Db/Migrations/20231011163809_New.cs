using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("11f0ada9-6749-4202-abc2-0e0798c28956"),
                columns: new[] { "ProductId", "Url" },
                values: new object[] { new Guid("e5650031-f46d-4a08-95e3-73bdcfbe0e03"), "/images/Products/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("3b86338f-39a1-49be-97e0-8dafb3cde5e4"),
                columns: new[] { "ProductId", "Url" },
                values: new object[] { new Guid("1da615a9-1274-49b1-a5e3-1de9eb4def1e"), "/images/Products/NVIDIA GeForce RTX 4090 ASUS 24Gb.webp" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("515113c4-e7ec-4375-8dd8-5ee691534916"),
                columns: new[] { "ProductId", "Url" },
                values: new object[] { new Guid("b1911e79-bc5a-4ddc-9a05-5f0128c956e2"), "/images/Products/NVIDIA GeForce RTX 4070 Ti MSI 12Gb.webp" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("566f1b95-98d0-4ffe-8674-613fb2805f87"),
                columns: new[] { "ProductId", "Url" },
                values: new object[] { new Guid("9cef72c1-745c-4188-8455-22f117cb24a4"), "/images/Products/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR.webp" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("615aa542-835d-477e-944f-c7e52379a833"),
                column: "Url",
                value: "/images/Products/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb.webp");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("f1a36166-5459-4e4e-9c12-38286acc700d"),
                columns: new[] { "ProductId", "Url" },
                values: new object[] { new Guid("f545d4a3-40b1-4f3b-953a-e2e70275fc27"), "/images/Products/NVIDIA GeForce RTX 4080 Gigabyte 16Gb.webp" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("11f0ada9-6749-4202-abc2-0e0798c28956"),
                columns: new[] { "ProductId", "Url" },
                values: new object[] { new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"), "/images/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("3b86338f-39a1-49be-97e0-8dafb3cde5e4"),
                columns: new[] { "ProductId", "Url" },
                values: new object[] { new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"), "/images/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("515113c4-e7ec-4375-8dd8-5ee691534916"),
                columns: new[] { "ProductId", "Url" },
                values: new object[] { new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"), "/images/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("566f1b95-98d0-4ffe-8674-613fb2805f87"),
                columns: new[] { "ProductId", "Url" },
                values: new object[] { new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"), "/images/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp" });

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("615aa542-835d-477e-944f-c7e52379a833"),
                column: "Url",
                value: "/images/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("f1a36166-5459-4e4e-9c12-38286acc700d"),
                columns: new[] { "ProductId", "Url" },
                values: new object[] { new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"), "/images/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp" });
        }
    }
}
