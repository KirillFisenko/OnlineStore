using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class Inizialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDeliveryInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserIdentityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDeliveryInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompareProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompareProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompareProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_UserDeliveryInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDeliveryInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CartItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Categories", "Cost", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"), 2, 33060m, "PCI-E 4.0; 1320 МГц; 1837 МГц; 12 Гб; GDDR6; 15000 МГц; 192 бит; HDMI, 3xDisplayPort", "NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb" },
                    { new Guid("1d0f8db8-8935-40ba-9d4f-36eb7c62e4f0"), 1, 10070m, "LGA 1700, Intel B660, 2xDDR4, PCI-E 4.0, 2xM.2, 4xUSB 3.2 Gen1, HDMI, mATX", "ASUS PRIME B660M-K D4" },
                    { new Guid("1da615a9-1274-49b1-a5e3-1de9eb4def1e"), 2, 182350m, "PCI-E 4.0; 2235 МГц; 2595 МГц; 24 Гб; GDDR6X; 21000 МГц; 384 бит; HDMI, 3xDisplayPort", "NVIDIA GeForce RTX 4090 ASUS 24Gb" },
                    { new Guid("9cef72c1-745c-4188-8455-22f117cb24a4"), 2, 48660m, "PCI-E 4.0; 1500 МГц; 1815 МГц; 8 Гб; GDDR6; 14000 МГц; 256 бит; 2xHDMI, 2xDisplayPort", "NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR" },
                    { new Guid("a9e8c758-3456-4c89-b0e4-6190e193cc1c"), 0, 16490m, "LGA 1700, 6-ядерный, 2500 МГц, Turbo: 4400 МГц, Alder Lake, Кэш L2 - 7.5 Мб, L3 - 18 Мб, 10 нм, 117 Вт", "Intel Core i5 - 12400F OEM" },
                    { new Guid("b1911e79-bc5a-4ddc-9a05-5f0128c956e2"), 2, 93320m, "PCI-E 4.0; 2310 МГц; 2760 МГц; 12 Гб; GDDR6X; 21000 МГц; 192 бит; HDMI, 3xDisplayPort", "NVIDIA GeForce RTX 4070 Ti MSI 12Gb" },
                    { new Guid("b19eba8a-9fe4-4e17-9329-3b8c370eaccd"), 4, 8840m, "внутренний SSD, M.2, 1000 Гб, PCI-E x4, NVMe, чтение: 3500 МБ/сек, запись: 3300 МБ/сек, TLC, кэш - 1024 Мб", "1Tb Samsung 970 EVO Plus (MZ-V7S1T0BW)" },
                    { new Guid("e5650031-f46d-4a08-95e3-73bdcfbe0e03"), 2, 35720m, "PCI-E 4.0; 1720 МГц; 2755 МГц; 8 Гб; GDDR6; 18000 МГц; 128 бит; HDMI, 3xDisplayPort", "AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC" },
                    { new Guid("f545d4a3-40b1-4f3b-953a-e2e70275fc27"), 2, 109580m, "PCI-E 4.0; 2535 МГц; 2535 МГц; 16 Гб; GDDR6X; 22400 МГц; 256 бит; HDMI, 3xDisplayPort", "NVIDIA GeForce RTX 4080 Gigabyte 16Gb" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[,]
                {
                    { new Guid("11f0ada9-6749-4202-abc2-0e0798c28932"), new Guid("e5650031-f46d-4a08-95e3-73bdcfbe0e03"), "/images/Products/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC_1.webp" },
                    { new Guid("11f0ada9-6749-4202-abc2-0e0798c28951"), new Guid("e5650031-f46d-4a08-95e3-73bdcfbe0e03"), "/images/Products/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp" },
                    { new Guid("11f0ada9-6749-4202-abc2-0e0798c28953"), new Guid("e5650031-f46d-4a08-95e3-73bdcfbe0e03"), "/images/Products/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC_2.webp" },
                    { new Guid("3b86338f-39a1-49be-97e0-8dafb3cde5e1"), new Guid("1da615a9-1274-49b1-a5e3-1de9eb4def1e"), "/images/Products/NVIDIA GeForce RTX 4090 ASUS 24Gb.webp" },
                    { new Guid("3b87338f-39a1-43be-97e0-8dafb7cde5e3"), new Guid("1da615a9-1274-49b1-a5e3-1de9eb4def1e"), "/images/Products/NVIDIA GeForce RTX 4090 ASUS 24Gb_2.webp" },
                    { new Guid("4dac46b6-1266-46d2-82a4-0d659e330671"), new Guid("1d0f8db8-8935-40ba-9d4f-36eb7c62e4f0"), "/images/Products/ASUS PRIME B660M-K D4.webp" },
                    { new Guid("515113c4-e7ec-4375-8dd8-5ee691534911"), new Guid("b1911e79-bc5a-4ddc-9a05-5f0128c956e2"), "/images/Products/NVIDIA GeForce RTX 4070 Ti MSI 12Gb.webp" },
                    { new Guid("515143c4-e7ec-4375-8dd8-5ee691634712"), new Guid("b1911e79-bc5a-4ddc-9a05-5f0128c956e2"), "/images/Products/NVIDIA GeForce RTX 4070 Ti MSI 12Gb_1.webp" },
                    { new Guid("515313c4-e7ec-4875-8dd8-5ee641534903"), new Guid("b1911e79-bc5a-4ddc-9a05-5f0128c956e2"), "/images/Products/NVIDIA GeForce RTX 4070 Ti MSI 12Gb_2.webp" },
                    { new Guid("564f1b95-94d0-4ffe-8674-613fb6805f62"), new Guid("9cef72c1-745c-4188-8455-22f117cb24a4"), "/images/Products/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR_1.webp" },
                    { new Guid("566f1b95-98d0-4ffe-8674-613fb2805f81"), new Guid("9cef72c1-745c-4188-8455-22f117cb24a4"), "/images/Products/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR.webp" },
                    { new Guid("566f1b97-98d0-4ffe-8694-613fb2305f43"), new Guid("9cef72c1-745c-4188-8455-22f117cb24a4"), "/images/Products/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR_2.webp" },
                    { new Guid("5b86338f-37a1-49be-97e0-8dafb3cde9e2"), new Guid("1da615a9-1274-49b1-a5e3-1de9eb4def1e"), "/images/Products/NVIDIA GeForce RTX 4090 ASUS 24Gb_1.webp" },
                    { new Guid("615aa542-835d-477e-944f-c7e52379a831"), new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"), "/images/Products/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb.webp" },
                    { new Guid("615aa542-835d-477e-944f-c7e52379a842"), new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"), "/images/Products/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb_1.webp" },
                    { new Guid("635aa542-835d-477e-944f-c7e51259a833"), new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"), "/images/Products/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb_2.webp" },
                    { new Guid("b4985364-e448-411c-a2f2-70a5f4859607"), new Guid("a9e8c758-3456-4c89-b0e4-6190e193cc1c"), "/images/Products/Intel Core i5 - 12400F OEM.webp" },
                    { new Guid("d81dad65-df25-41f0-88d3-48c9b842c10f"), new Guid("b19eba8a-9fe4-4e17-9329-3b8c370eaccd"), "/images/Products/1Tb Samsung 970 EVO Plus (MZ-V7S1T0BW).webp" },
                    { new Guid("f1a36166-5459-4e4e-9c12-38286acc7201"), new Guid("f545d4a3-40b1-4f3b-953a-e2e70275fc27"), "/images/Products/NVIDIA GeForce RTX 4080 Gigabyte 16Gb.webp" },
                    { new Guid("f1a36456-5459-4e4e-9c12-38876acc7012"), new Guid("f545d4a3-40b1-4f3b-953a-e2e70275fc27"), "/images/Products/NVIDIA GeForce RTX 4080 Gigabyte 16Gb_1.webp" },
                    { new Guid("f1a37166-5469-4e4e-9c12-35236acc7003"), new Guid("f545d4a3-40b1-4f3b-953a-e2e70275fc27"), "/images/Products/NVIDIA GeForce RTX 4080 Gigabyte 16Gb_2.webp" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_OrderId",
                table: "CartItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CompareProducts_ProductId",
                table: "CompareProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_ProductId",
                table: "FavoriteProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "CompareProducts");

            migrationBuilder.DropTable(
                name: "FavoriteProducts");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserDeliveryInfo");
        }
    }
}
