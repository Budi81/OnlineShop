using OnlineShop.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OnlineShop.ConsoleInterface
{
    public class ConsoleController :IController
    {
        public int UserChoice()
        {
            throw new NotImplementedException();
        }

        public void DisplayError(string massage, int milliseconds)
        {
            Console.WriteLine(massage);
            Thread.Sleep(milliseconds);
        }

        public void WriteOutData(string message)
        {
            Console.WriteLine(message);
        }

    }
}
