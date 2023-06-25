using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    public class ProductRepository
    {
        private static List<Product> products = new List<Product>()
            {
                new Product("NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb", 33_060, "PCI-E 4.0, ядро - 1320 МГц, Boost - 1837 МГц, память - 12 Гб GDDR6 15000 МГц, 192 бит, HDMI, 3xDisplayPort, подсветка, Retail" ),
                new Product("NVIDIA GeForce RTX 4080 Gigabyte 16Gb", 109_580, "PCI-E 4.0, ядро - 2535 МГц, память - 16 Гб GDDR6X 22400 МГц, 256 бит, HDMI, 3xDisplayPort, подсветка, Retail" ),
                new Product("AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC", 35_720, "PCI-E 4.0, ядро - 1720 МГц, Boost - 2755 МГц, память - 8 Гб GDDR6 18000 МГц, 128 бит, HDMI, 3xDisplayPort, подсветка, Retail" )
            };

        public List<Product> GetAll()
        {
            return products;
        }
    }
}