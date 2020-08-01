using OnlineShop.BusinessLayer;
using System;
using System.Data;

namespace OnlineShop.ConsoleInterface
{
    // nie wiem jak zrobić zależności, żeby były tu widoczne klasy z OnlineShop.BusinessLayer
    class Program
    {
        static void Main()
        {
            Shop shopRunning = new Shop(new SqlDb(), new ConsoleController());

            shopRunning.ProgramRunning();
        }
    }
}
