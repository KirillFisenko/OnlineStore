﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Db;

#nullable disable

namespace OnlineShop.Db.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CompareProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("CompareProducts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.FavoriteProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("FavoriteProducts");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("615aa542-835d-477e-944f-c7e52379a831"),
                            ProductId = new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"),
                            Url = "/images/Products/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb.webp"
                        },
                        new
                        {
                            Id = new Guid("615aa542-835d-477e-944f-c7e52379a842"),
                            ProductId = new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"),
                            Url = "/images/Products/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb_1.webp"
                        },
                        new
                        {
                            Id = new Guid("635aa542-835d-477e-944f-c7e51259a833"),
                            ProductId = new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"),
                            Url = "/images/Products/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb_2.webp"
                        },
                        new
                        {
                            Id = new Guid("f1a36166-5459-4e4e-9c12-38286acc7201"),
                            ProductId = new Guid("f545d4a3-40b1-4f3b-953a-e2e70275fc27"),
                            Url = "/images/Products/NVIDIA GeForce RTX 4080 Gigabyte 16Gb.webp"
                        },
                        new
                        {
                            Id = new Guid("f1a36456-5459-4e4e-9c12-38876acc7012"),
                            ProductId = new Guid("f545d4a3-40b1-4f3b-953a-e2e70275fc27"),
                            Url = "/images/Products/NVIDIA GeForce RTX 4080 Gigabyte 16Gb_1.webp"
                        },
                        new
                        {
                            Id = new Guid("f1a37166-5469-4e4e-9c12-35236acc7003"),
                            ProductId = new Guid("f545d4a3-40b1-4f3b-953a-e2e70275fc27"),
                            Url = "/images/Products/NVIDIA GeForce RTX 4080 Gigabyte 16Gb_2.webp"
                        },
                        new
                        {
                            Id = new Guid("11f0ada9-6749-4202-abc2-0e0798c28951"),
                            ProductId = new Guid("e5650031-f46d-4a08-95e3-73bdcfbe0e03"),
                            Url = "/images/Products/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp"
                        },
                        new
                        {
                            Id = new Guid("11f0ada9-6749-4202-abc2-0e0798c28932"),
                            ProductId = new Guid("e5650031-f46d-4a08-95e3-73bdcfbe0e03"),
                            Url = "/images/Products/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC_1.webp"
                        },
                        new
                        {
                            Id = new Guid("11f0ada9-6749-4202-abc2-0e0798c28953"),
                            ProductId = new Guid("e5650031-f46d-4a08-95e3-73bdcfbe0e03"),
                            Url = "/images/Products/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC_2.webp"
                        },
                        new
                        {
                            Id = new Guid("515113c4-e7ec-4375-8dd8-5ee691534911"),
                            ProductId = new Guid("b1911e79-bc5a-4ddc-9a05-5f0128c956e2"),
                            Url = "/images/Products/NVIDIA GeForce RTX 4070 Ti MSI 12Gb.webp"
                        },
                        new
                        {
                            Id = new Guid("515143c4-e7ec-4375-8dd8-5ee691634712"),
                            ProductId = new Guid("b1911e79-bc5a-4ddc-9a05-5f0128c956e2"),
                            Url = "/images/Products/NVIDIA GeForce RTX 4070 Ti MSI 12Gb_1.webp"
                        },
                        new
                        {
                            Id = new Guid("515313c4-e7ec-4875-8dd8-5ee641534903"),
                            ProductId = new Guid("b1911e79-bc5a-4ddc-9a05-5f0128c956e2"),
                            Url = "/images/Products/NVIDIA GeForce RTX 4070 Ti MSI 12Gb_2.webp"
                        },
                        new
                        {
                            Id = new Guid("566f1b95-98d0-4ffe-8674-613fb2805f81"),
                            ProductId = new Guid("9cef72c1-745c-4188-8455-22f117cb24a4"),
                            Url = "/images/Products/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR.webp"
                        },
                        new
                        {
                            Id = new Guid("564f1b95-94d0-4ffe-8674-613fb6805f62"),
                            ProductId = new Guid("9cef72c1-745c-4188-8455-22f117cb24a4"),
                            Url = "/images/Products/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR_1.webp"
                        },
                        new
                        {
                            Id = new Guid("566f1b97-98d0-4ffe-8694-613fb2305f43"),
                            ProductId = new Guid("9cef72c1-745c-4188-8455-22f117cb24a4"),
                            Url = "/images/Products/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR_2.webp"
                        },
                        new
                        {
                            Id = new Guid("3b86338f-39a1-49be-97e0-8dafb3cde5e1"),
                            ProductId = new Guid("1da615a9-1274-49b1-a5e3-1de9eb4def1e"),
                            Url = "/images/Products/NVIDIA GeForce RTX 4090 ASUS 24Gb.webp"
                        },
                        new
                        {
                            Id = new Guid("5b86338f-37a1-49be-97e0-8dafb3cde9e2"),
                            ProductId = new Guid("1da615a9-1274-49b1-a5e3-1de9eb4def1e"),
                            Url = "/images/Products/NVIDIA GeForce RTX 4090 ASUS 24Gb_1.webp"
                        },
                        new
                        {
                            Id = new Guid("3b87338f-39a1-43be-97e0-8dafb7cde5e3"),
                            ProductId = new Guid("1da615a9-1274-49b1-a5e3-1de9eb4def1e"),
                            Url = "/images/Products/NVIDIA GeForce RTX 4090 ASUS 24Gb_2.webp"
                        },
                        new
                        {
                            Id = new Guid("b4985364-e448-411c-a2f2-70a5f4859607"),
                            ProductId = new Guid("a9e8c758-3456-4c89-b0e4-6190e193cc1c"),
                            Url = "/images/Products/Intel Core i5 - 12400F OEM.webp"
                        },
                        new
                        {
                            Id = new Guid("4dac46b6-1266-46d2-82a4-0d659e330671"),
                            ProductId = new Guid("1d0f8db8-8935-40ba-9d4f-36eb7c62e4f0"),
                            Url = "/images/Products/ASUS PRIME B660M-K D4.webp"
                        },
                        new
                        {
                            Id = new Guid("d81dad65-df25-41f0-88d3-48c9b842c10f"),
                            ProductId = new Guid("b19eba8a-9fe4-4e17-9329-3b8c370eaccd"),
                            Url = "/images/Products/1Tb Samsung 970 EVO Plus (MZ-V7S1T0BW).webp"
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Categories")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("02ee2bb1-9dc4-4296-8119-ee264d8168f3"),
                            Categories = 2,
                            Cost = 33060m,
                            Description = "PCI-E 4.0; 1320 МГц; 1837 МГц; 12 Гб; GDDR6; 15000 МГц; 192 бит; HDMI, 3xDisplayPort",
                            Name = "NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb"
                        },
                        new
                        {
                            Id = new Guid("f545d4a3-40b1-4f3b-953a-e2e70275fc27"),
                            Categories = 2,
                            Cost = 109580m,
                            Description = "PCI-E 4.0; 2535 МГц; 2535 МГц; 16 Гб; GDDR6X; 22400 МГц; 256 бит; HDMI, 3xDisplayPort",
                            Name = "NVIDIA GeForce RTX 4080 Gigabyte 16Gb"
                        },
                        new
                        {
                            Id = new Guid("e5650031-f46d-4a08-95e3-73bdcfbe0e03"),
                            Categories = 2,
                            Cost = 35720m,
                            Description = "PCI-E 4.0; 1720 МГц; 2755 МГц; 8 Гб; GDDR6; 18000 МГц; 128 бит; HDMI, 3xDisplayPort",
                            Name = "AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC"
                        },
                        new
                        {
                            Id = new Guid("b1911e79-bc5a-4ddc-9a05-5f0128c956e2"),
                            Categories = 2,
                            Cost = 93320m,
                            Description = "PCI-E 4.0; 2310 МГц; 2760 МГц; 12 Гб; GDDR6X; 21000 МГц; 192 бит; HDMI, 3xDisplayPort",
                            Name = "NVIDIA GeForce RTX 4070 Ti MSI 12Gb"
                        },
                        new
                        {
                            Id = new Guid("9cef72c1-745c-4188-8455-22f117cb24a4"),
                            Categories = 2,
                            Cost = 48660m,
                            Description = "PCI-E 4.0; 1500 МГц; 1815 МГц; 8 Гб; GDDR6; 14000 МГц; 256 бит; 2xHDMI, 2xDisplayPort",
                            Name = "NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR"
                        },
                        new
                        {
                            Id = new Guid("1da615a9-1274-49b1-a5e3-1de9eb4def1e"),
                            Categories = 2,
                            Cost = 182350m,
                            Description = "PCI-E 4.0; 2235 МГц; 2595 МГц; 24 Гб; GDDR6X; 21000 МГц; 384 бит; HDMI, 3xDisplayPort",
                            Name = "NVIDIA GeForce RTX 4090 ASUS 24Gb"
                        },
                        new
                        {
                            Id = new Guid("a9e8c758-3456-4c89-b0e4-6190e193cc1c"),
                            Categories = 0,
                            Cost = 16490m,
                            Description = "LGA 1700, 6-ядерный, 2500 МГц, Turbo: 4400 МГц, Alder Lake, Кэш L2 - 7.5 Мб, L3 - 18 Мб, 10 нм, 117 Вт",
                            Name = "Intel Core i5 - 12400F OEM"
                        },
                        new
                        {
                            Id = new Guid("1d0f8db8-8935-40ba-9d4f-36eb7c62e4f0"),
                            Categories = 1,
                            Cost = 10070m,
                            Description = "LGA 1700, Intel B660, 2xDDR4, PCI-E 4.0, 2xM.2, 4xUSB 3.2 Gen1, HDMI, mATX",
                            Name = "ASUS PRIME B660M-K D4"
                        },
                        new
                        {
                            Id = new Guid("b19eba8a-9fe4-4e17-9329-3b8c370eaccd"),
                            Categories = 4,
                            Cost = 8840m,
                            Description = "внутренний SSD, M.2, 1000 Гб, PCI-E x4, NVMe, чтение: 3500 МБ/сек, запись: 3300 МБ/сек, TLC, кэш - 1024 Мб",
                            Name = "1Tb Samsung 970 EVO Plus (MZ-V7S1T0BW)"
                        });
                });

            modelBuilder.Entity("OnlineShop.Db.Models.UserDeliveryInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserIdentityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserDeliveryInfo");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CartItem", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Cart", null)
                        .WithMany("Items")
                        .HasForeignKey("CartId");

                    b.HasOne("OnlineShop.Db.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId");

                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.CompareProduct", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.FavoriteProduct", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Image", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.HasOne("OnlineShop.Db.Models.UserDeliveryInfo", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineShop.Db.Models.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
