using OnlineShop.BusinessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BusinessLayer.Products.Games
{
    public class Game :Product
    {


        public Game(int productId, string productName, decimal price, int stock, ProductType type, 
            GamesStorageDataDevices gamesStorageDataDevices, GamesPlatforms platform, GamesCategory category) 
            : base(productId, productName, price, stock, type)
        {
            this.DataStorageDevice = gamesStorageDataDevices;
            this.Platform = platform;
            this.Category = category;
        }

        public override List<ProductAttribute> GetAttributes()
        {
            List<ProductAttribute> attributes = new List<ProductAttribute>();
            attributes.Add(new ProductAttribute("Game Storage Device", DataStorageDevice.ToString()));
            attributes.Add(new ProductAttribute("Platform", Platform.ToString()));
            attributes.Add(new ProductAttribute("Category", Category.ToString()));

            return attributes;
        }

        public override Product WithId(int newId)
        {
              return new Game(newId, this.ProductName, this.Price, this.Stock, this.Type, this.DataStorageDevice, this.Platform, this.Category);
        }

        public GamesStorageDataDevices DataStorageDevice { get; private set; }
        
        public GamesPlatforms Platform { get; private set; }
        public GamesCategory Category { get; private set; }


    }
}
