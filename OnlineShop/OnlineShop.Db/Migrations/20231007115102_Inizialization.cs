﻿using System;
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
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("5ef9c894-0ccc-4337-b018-4e63a7e003d6"), 109580m, "PCI-E 4.0; 2535 МГц; 2535 МГц; 16 Гб; GDDR6X; 22400 МГц; 256 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4080 Gigabyte 16Gb.webp", "NVIDIA GeForce RTX 4080 Gigabyte 16Gb" },
                    { new Guid("61b2961c-6df7-4727-b7c3-fbefcbd72b16"), 35720m, "PCI-E 4.0; 1720 МГц; 2755 МГц; 8 Гб; GDDR6; 18000 МГц; 128 бит; HDMI, 3xDisplayPort", "/images/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp", "AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC" },
                    { new Guid("b167403a-21a1-4da0-8161-d038e39f942f"), 93320m, "PCI-E 4.0; 2310 МГц; 2760 МГц; 12 Гб; GDDR6X; 21000 МГц; 192 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4070 Ti MSI 12Gb.webp", "NVIDIA GeForce RTX 4070 Ti MSI 12Gb" },
                    { new Guid("c75ad07a-40d7-40ec-a41b-ff2b28d53e4e"), 48660m, "PCI-E 4.0; 1500 МГц; 1815 МГц; 8 Гб; GDDR6; 14000 МГц; 256 бит; 2xHDMI, 2xDisplayPort", "/images/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR.webp", "NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR" },
                    { new Guid("df979ef2-9c2b-44aa-9235-cd87a8505b66"), 182350m, "PCI-E 4.0; 2235 МГц; 2595 МГц; 24 Гб; GDDR6X; 21000 МГц; 384 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 4090 ASUS 24Gb.webp", "NVIDIA GeForce RTX 4090 ASUS 24Gb" },
                    { new Guid("e235b856-1d7a-4ef4-84e1-ad6946cfe867"), 33060m, "PCI-E 4.0; 1320 МГц; 1837 МГц; 12 Гб; GDDR6; 15000 МГц; 192 бит; HDMI, 3xDisplayPort", "/images/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb.webp", "NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb" }
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
