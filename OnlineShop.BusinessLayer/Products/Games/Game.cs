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

        public override ProductType GetType()
        {
            throw new NotImplementedException();
        }

        public override List<ProductAttribute> GetAttributes()
        {
            List<ProductAttribute> attributes = new List<ProductAttribute>();
            attributes.Add(new ProductAttribute("Game Storage Device", dataStorageDevice.ToString()));
            attributes.Add(new ProductAttribute("Platform", platform.ToString()));
            attributes.Add(new ProductAttribute("Category", category.ToString()));

            return attributes;
        }

        public GamesStorageDataDevices DataStorageDevice { get => dataStorageDevice; private set => dataStorageDevice = value; }
        
        public GamesPlatforms Platform { get => platform; private set => platform = value; }
        public GamesCategory Category { get => category; private set => category = value; }
    }
}
