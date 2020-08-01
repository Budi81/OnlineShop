using OnlineShop.BusinessLayer;
using System;
using System.Data;

namespace OnlineShop.ConsoleInterface
{

    class Program
    {
        static void Main()
        {
            Shop shopRunning = new Shop(new SqlDb(), new ConsoleController());

            shopRunning.ProgramRunning();
        }
    }
}
