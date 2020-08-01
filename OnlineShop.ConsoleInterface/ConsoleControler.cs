using OnlineShop.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OnlineShop.ConsoleInterface
{
    public class ConsoleControler :IControler
    {
        public int UserChoice()
        {
            throw new NotImplementedException();
        }

        public void DisplayError(string massage, int miliseconds)
        {
            Console.WriteLine(massage);
            Thread.Sleep(miliseconds);
        }

        public void WriteOutData(string message)
        {
            Console.WriteLine(message);
        }

    }
}
