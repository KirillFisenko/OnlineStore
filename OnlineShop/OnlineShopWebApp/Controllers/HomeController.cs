using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using OnlineShopWebApp.Models;
using System.Diagnostics;
using System.Xml.Linq;

namespace OnlineShopWebApp.Controllers
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
        public Item(int id, string name, double cost, string description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
        }
    }
    public class HomeController : Controller
    {
        public string Index(int id)
        {
            var itemsList = new List<Item>()
            {
                new Item(381509, "NVIDIA GeForce RTX 3060 Palit Dual OC 12Gb", 33_060, "PCI-E 4.0, ядро - 1320 МГц, Boost - 1837 МГц, память - 12 Гб GDDR6 15000 МГц, 192 бит, HDMI, 3xDisplayPort, подсветка, Retail" ),
                new Item(458123, "NVIDIA GeForce RTX 4080 Gigabyte 16Gb", 109_580, "PCI-E 4.0, ядро - 2535 МГц, память - 16 Гб GDDR6X 22400 МГц, 256 бит, HDMI, 3xDisplayPort, подсветка, Retail" ),
                new Item(491589, "AMD Radeon RX 7600 ASRock Phantom Gaming 8G OC", 35_720, "PCI-E 4.0, ядро - 1720 МГц, Boost - 2755 МГц, память - 8 Гб GDDR6 18000 МГц, 128 бит, HDMI, 3xDisplayPort, подсветка, Retail" )
            };
           
            if(id == 0)
            {
                return $"{itemsList[0].Id}\n{itemsList[0].Name}\n{itemsList[0].Cost}\n\n" +
                $"{itemsList[1].Id}\n{itemsList[1].Name}\n{itemsList[1].Cost}\n\n" +
                $"{itemsList[2].Id}\n{itemsList[2].Name}\n{itemsList[2].Cost}\n\n";
            }
            else
            {
                foreach(var item in itemsList)
                {
                    if(item.Id == id)
                    {
                        return $"{item.Id}\n{item.Name}\n{item.Cost}\n{item.Description}";
                    }
                }
            }
            return null;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}