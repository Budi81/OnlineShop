using OnlineShop.BusinessLayer.Enums;
using OnlineShop.BusinessLayer.Products.Games;
using System;
using System.Collections.Generic;

namespace OnlineShop.BusinessLayer.Products
{
    internal class ProductFactory
    {
        public static Product Produce(int id,
            string name,
            decimal price,
            int stock,
            ProductType type,
            Dictionary<String, String> attributes)
        {
            switch (type)
            {
                case ProductType.Game:
                default:
                    return CreateGame(id, name, price, stock, type, attributes);
            }
        }

        private static Product CreateGame(int id,
            string name,
            decimal price,
            int stock,
            ProductType type,
            Dictionary<String, String> attributes)
        {
            GamesStorageDataDevices dataDevices = (GamesStorageDataDevices)Enum.Parse(typeof(GamesStorageDataDevices),
                attributes["GamesStorageDataDevices"]);
            GamesPlatforms platform = (GamesPlatforms)Enum.Parse(typeof(GamesPlatforms), attributes["GamesPlatform"]);
            GamesCategory category = (GamesCategory)Enum.Parse(typeof(GamesCategory), attributes["GamesCategory"]);

            return new Game(id, name, price, stock, type, dataDevices, platform, category);
        }
    }
}