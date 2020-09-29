using OnlineShop.BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BusinessLayer.Products.Games
{
    public class Game :Product
    {
        private GamesStorageDataDevices dataStorageDevice;

        private GamesPlatforms platform;

        private GamesCategory category;

        public Game(int productId, string productName, decimal price, int stock, ProductType type, 
            GamesStorageDataDevices gamesStorageDataDevices, GamesPlatforms platform, GamesCategory category) 
            : base(productId, productName, price, stock, type)
        {
            this.DataStorageDevice = gamesStorageDataDevices;
            this.Platform = platform;
            this.category = category;
        }

        public override List<ProductAttribute> GetAttributes()
        {
            List<ProductAttribute> attributes = new List<ProductAttribute>();
            attributes.Add(new ProductAttribute("Game Storage Device", dataStorageDevice.ToString()));
            attributes.Add(new ProductAttribute("Platform", platform.ToString()));
            attributes.Add(new ProductAttribute("Category", category.ToString()));

            return attributes;
        }

        public override Product WithId(int newId)
        {
              return new Game(newId, this.ProductName, this.Price, this.Stock, this.Type, this.DataStorageDevice, this.Platform, this.Category);
        }

        public GamesStorageDataDevices DataStorageDevice { get => dataStorageDevice; private set => dataStorageDevice = value; }
        
        public GamesPlatforms Platform { get => platform; private set => platform = value; }
        public GamesCategory Category { get => category; private set => category = value; }


    }
}
