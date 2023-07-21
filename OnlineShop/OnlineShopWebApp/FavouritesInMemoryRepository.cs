﻿using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
	public class FavouritesInMemoryRepository : IFavourites
	{
		public List<Product> favourites = new List<Product>();

		public void Add(Product product)
		{
			favourites.Add(product);
		}

        public void Del(Product product)
        {
            favourites.Remove(product);
        }

        public void Clear()
        {
            favourites.Clear();
        }

        public List<Product> GetAllFavourites()
		{
			return favourites;
		}
	}
}