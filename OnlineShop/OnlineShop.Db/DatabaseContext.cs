using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Models;


namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        // таблица продуктов в БД
        public DbSet<Product> Products { get; set; }

		// таблица списка избранного в БД
		public DbSet<FavoriteProduct> FavoriteProducts { get; set; }

		// таблица списка сравнения в БД
		public DbSet<CompareProduct> CompareProducts { get; set; }

		// таблица корзин в БД
		public DbSet<Cart> Carts { get; set; }

		// таблица заказов в БД
		public DbSet<Order> Orders { get; set; }

		// таблица изображений товаров в БД
		public DbSet<Image> Images { get; set; }        

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            // использование миграций
            Database.Migrate();
        }

        // стартовые продукты
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .HasOne(p => p.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            var product1Id = Guid.Parse("02ee2bb1-9dc4-4296-8119-ee264d8168f3");
            var product2Id = Guid.Parse("f545d4a3-40b1-4f3b-953a-e2e70275fc27");
            var product3Id = Guid.Parse("e5650031-f46d-4a08-95e3-73bdcfbe0e03");
            var product4Id = Guid.Parse("b1911e79-bc5a-4ddc-9a05-5f0128c956e2");
            var product5Id = Guid.Parse("9cef72c1-745c-4188-8455-22f117cb24a4");
            var product6Id = Guid.Parse("1da615a9-1274-49b1-a5e3-1de9eb4def1e");

            var product7Id = Guid.Parse("a9e8c758-3456-4c89-b0e4-6190e193cc1c");

            var product8Id = Guid.Parse("1d0f8db8-8935-40ba-9d4f-36eb7c62e4f0");

            var product9Id = Guid.Parse("b19eba8a-9fe4-4e17-9329-3b8c370eaccd");

            var image1 = new Image
            {
                Id = Guid.Parse("615aa542-835d-477e-944f-c7e52379a831"),
                Url = "/images/Products/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb.webp",
                ProductId = product1Id
            };

            var image1_1 = new Image
            {
                Id = Guid.Parse("615aa542-835d-477e-944f-c7e52379a842"),
                Url = "/images/Products/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb_1.webp",
                ProductId = product1Id
            };

            var image1_2 = new Image
            {
                Id = Guid.Parse("635aa542-835d-477e-944f-c7e51259a833"),
                Url = "/images/Products/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb_2.webp",
                ProductId = product1Id
            };

            var image2 = new Image
            {
                Id = Guid.Parse("f1a36166-5459-4e4e-9c12-38286acc7201"),
                Url = "/images/Products/NVIDIA GeForce RTX 4080 Gigabyte 16Gb.webp",
                ProductId = product2Id
            };

            var image2_1 = new Image
            {
                Id = Guid.Parse("f1a36456-5459-4e4e-9c12-38876acc7012"),
                Url = "/images/Products/NVIDIA GeForce RTX 4080 Gigabyte 16Gb_1.webp",
                ProductId = product2Id
            };

            var image2_2 = new Image
            {
                Id = Guid.Parse("f1a37166-5469-4e4e-9c12-35236acc7003"),
                Url = "/images/Products/NVIDIA GeForce RTX 4080 Gigabyte 16Gb_2.webp",
                ProductId = product2Id
            };

            var image3 = new Image
            {
                Id = Guid.Parse("11f0ada9-6749-4202-abc2-0e0798c28951"),
                Url = "/images/Products/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp",
                ProductId = product3Id
            };

            var image3_1 = new Image
            {
                Id = Guid.Parse("11f0ada9-6749-4202-abc2-0e0798c28932"),
                Url = "/images/Products/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC_1.webp",
                ProductId = product3Id
            };

            var image3_2 = new Image
            {
                Id = Guid.Parse("11f0ada9-6749-4202-abc2-0e0798c28953"),
                Url = "/images/Products/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC_2.webp",
                ProductId = product3Id
            };

            var image4 = new Image
            {
                Id = Guid.Parse("515113c4-e7ec-4375-8dd8-5ee691534911"),
                Url = "/images/Products/NVIDIA GeForce RTX 4070 Ti MSI 12Gb.webp",
                ProductId = product4Id
            };

            var image4_1 = new Image
            {
                Id = Guid.Parse("515143c4-e7ec-4375-8dd8-5ee691634712"),
                Url = "/images/Products/NVIDIA GeForce RTX 4070 Ti MSI 12Gb_1.webp",
                ProductId = product4Id
            };

            var image4_2 = new Image
            {
                Id = Guid.Parse("515313c4-e7ec-4875-8dd8-5ee641534903"),
                Url = "/images/Products/NVIDIA GeForce RTX 4070 Ti MSI 12Gb_2.webp",
                ProductId = product4Id
            };

            var image5 = new Image
            {
                Id = Guid.Parse("566f1b95-98d0-4ffe-8674-613fb2805f81"),
                Url = "/images/Products/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR.webp",
                ProductId = product5Id
            };

            var image5_1 = new Image
            {
                Id = Guid.Parse("564f1b95-94d0-4ffe-8674-613fb6805f62"),
                Url = "/images/Products/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR_1.webp",
                ProductId = product5Id
            };

            var image5_2 = new Image
            {
                Id = Guid.Parse("566f1b97-98d0-4ffe-8694-613fb2305f43"),
                Url = "/images/Products/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR_2.webp",
                ProductId = product5Id
            };

            var image6 = new Image
            {
                Id = Guid.Parse("3b86338f-39a1-49be-97e0-8dafb3cde5e1"),
                Url = "/images/Products/NVIDIA GeForce RTX 4090 ASUS 24Gb.webp",
                ProductId = product6Id
            };

            var image6_1 = new Image
            {
                Id = Guid.Parse("5b86338f-37a1-49be-97e0-8dafb3cde9e2"),
                Url = "/images/Products/NVIDIA GeForce RTX 4090 ASUS 24Gb_1.webp",
                ProductId = product6Id
            };

            var image6_2 = new Image
            {
                Id = Guid.Parse("3b87338f-39a1-43be-97e0-8dafb7cde5e3"),
                Url = "/images/Products/NVIDIA GeForce RTX 4090 ASUS 24Gb_2.webp",
                ProductId = product6Id
            };

            var image7 = new Image
            {
                Id = Guid.Parse("b4985364-e448-411c-a2f2-70a5f4859607"),
                Url = "/images/Products/Intel Core i5 - 12400F OEM.webp",
                ProductId = product7Id
            };

            var image8 = new Image
            {
                Id = Guid.Parse("4dac46b6-1266-46d2-82a4-0d659e330671"),
                Url = "/images/Products/ASUS PRIME B660M-K D4.webp",
                ProductId = product8Id
            };

            var image9 = new Image
            {
                Id = Guid.Parse("d81dad65-df25-41f0-88d3-48c9b842c10f"),
                Url = "/images/Products/1Tb Samsung 970 EVO Plus (MZ-V7S1T0BW).webp",
                ProductId = product9Id
            };

            modelBuilder.Entity<Image>().HasData(image1, image1_1, image1_2, image2, image2_1, image2_2, 
                image3, image3_1, image3_2, image4, image4_1, image4_2, image5, image5_1, image5_2, 
                image6, image6_1, image6_2, image7, image8, image9);

            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
            new Product(
                    product1Id,
                    "NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb",
                    33_060,
                    "PCI-E 4.0; 1320 МГц; 1837 МГц; 12 Гб; GDDR6; 15000 МГц; 192 бит; HDMI, 3xDisplayPort",
                    Categories.VideoCards
                ),
            new Product(
                product2Id,
                    "NVIDIA GeForce RTX 4080 Gigabyte 16Gb",
                    109_580,
                    "PCI-E 4.0; 2535 МГц; 2535 МГц; 16 Гб; GDDR6X; 22400 МГц; 256 бит; HDMI, 3xDisplayPort",
                    Categories.VideoCards
                ),
            new Product(
                product3Id,
                    "AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC",
                    35_720,
                    "PCI-E 4.0; 1720 МГц; 2755 МГц; 8 Гб; GDDR6; 18000 МГц; 128 бит; HDMI, 3xDisplayPort",
                    Categories.VideoCards
                ),
            new Product(
                product4Id,
                    "NVIDIA GeForce RTX 4070 Ti MSI 12Gb",
                    93_320,
                    "PCI-E 4.0; 2310 МГц; 2760 МГц; 12 Гб; GDDR6X; 21000 МГц; 192 бит; HDMI, 3xDisplayPort",
                    Categories.VideoCards
                ),
            new Product(
                product5Id,
                    "NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR",
                    48_660, "PCI-E 4.0; 1500 МГц; 1815 МГц; 8 Гб; GDDR6; 14000 МГц; 256 бит; 2xHDMI, 2xDisplayPort",
                    Categories.VideoCards
                ),
            new Product(
                product6Id,
                    "NVIDIA GeForce RTX 4090 ASUS 24Gb",
                    182_350,
                    "PCI-E 4.0; 2235 МГц; 2595 МГц; 24 Гб; GDDR6X; 21000 МГц; 384 бит; HDMI, 3xDisplayPort",
                    Categories.VideoCards
                ),
            new Product(
                product7Id,
                    "Intel Core i5 - 12400F OEM",
                    16_490,
                    "LGA 1700, 6-ядерный, 2500 МГц, Turbo: 4400 МГц, Alder Lake, Кэш L2 - 7.5 Мб, L3 - 18 Мб, 10 нм, 117 Вт",
                    Categories.Processors
                ),
            new Product(
                product8Id,
                    "ASUS PRIME B660M-K D4",
                    10_070,
                    "LGA 1700, Intel B660, 2xDDR4, PCI-E 4.0, 2xM.2, 4xUSB 3.2 Gen1, HDMI, mATX",
                    Categories.Motherboards
                ),
            new Product(
                product9Id,
                    "1Tb Samsung 970 EVO Plus (MZ-V7S1T0BW)",
                    8_840,
                    "внутренний SSD, M.2, 1000 Гб, PCI-E x4, NVMe, чтение: 3500 МБ/сек, запись: 3300 МБ/сек, TLC, кэш - 1024 Мб",
                    Categories.SSD
                )
            });
        }
    }
}