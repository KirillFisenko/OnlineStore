﻿using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public class ProductsInMemoryRepository : IProductsRepository
	{
		public List<Product> products = new List<Product>()
			{

			new Product(
					"NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb",
					33_060,
					"PCI-E 4.0, ядро - 1320 МГц, Boost - 1837 МГц, память - 12 Гб GDDR6 15000 МГц, 192 бит, HDMI, 3xDisplayPort, подсветка, Retail",
					"/images/NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb.webp"
				),
			new Product(
					"NVIDIA GeForce RTX 4080 Gigabyte 16Gb",
					109_580,
					"PCI-E 4.0, ядро - 2535 МГц, память - 16 Гб GDDR6X 22400 МГц, 256 бит, HDMI, 3xDisplayPort, подсветка, Retail",
					"/images/NVIDIA GeForce RTX 4080 Gigabyte 16Gb.webp"
				),
			new Product(
					"AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC",
					35_720,
					"PCI-E 4.0, ядро - 1720 МГц, Boost - 2755 МГц, память - 8 Гб GDDR6 18000 МГц, 128 бит, HDMI, 3xDisplayPort, подсветка, Retail",
					"/images/AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC.webp"
				),
			new Product(
					"NVIDIA GeForce RTX 4070 Ti MSI 12Gb",
					93_320,
					"PCI-E 4.0, ядро - 2310 МГц, Boost - 2760 МГц, память - 12 Гб GDDR6X 21000 МГц, 192 бит, HDMI, 3xDisplayPort, подсветка, Retail" ,
					"/images/NVIDIA GeForce RTX 4070 Ti MSI 12Gb.webp"
				),
			new Product(
					"NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR",
					48_660, "PCI-E 4.0, ядро - 1500 МГц, Boost - 1815 МГц, память - 8 Гб GDDR6 14000 МГц, 256 бит, 2xHDMI, 2xDisplayPort, подсветка, Retail" ,
					"/images/NVIDIA GeForce RTX 3070 Gigabyte 8Gb LHR.webp"
				),
			new Product(
					"NVIDIA GeForce RTX 4090 ASUS 24Gb",
					182_350,
					"PCI-E 4.0, ядро - 2235 МГц, Boost - 2595 МГц, память - 24 Гб GDDR6X 21000 МГц, 384 бит, HDMI, 3xDisplayPort, подсветка, Retail",
					"/images/NVIDIA GeForce RTX 4090 ASUS 24Gb.webp"
				)
			};

		public List<Product> GetAllProducts()
		{
			return products;
		}

		public Product TryGetById(int id)
		{
			return products.FirstOrDefault(product => product.Id == id);
		}
	}
}