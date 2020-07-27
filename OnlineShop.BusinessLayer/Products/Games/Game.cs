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

        public Game()
            :this(productId, productName, price, stock)
        {

        }

        public Game(GamesStorageDataDevices dataStorageDevice, GamesPlatforms platform, GamesCategory category)
        {
            base.productId = productId;
            DataStorageDevice = dataStorageDevice;
            Platform = platform;
            Category = category;
        }

        public GamesStorageDataDevices DataStorageDevice { get => dataStorageDevice; private set => dataStorageDevice = value; }
        public GamesPlatforms Platform { get => platform; private set => platform = value; }
        public GamesCategory Category { get => category; private set => category = value; }
    }
}
