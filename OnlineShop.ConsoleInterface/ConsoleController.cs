using OnlineShop.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OnlineShop.ConsoleInterface
{
    public class ConsoleController : IController
    {
        public int UserChoice(string message)
        {
            bool output;
            do
            {
                Console.WriteLine(message);
                Console.Write("> ");
                output = int.TryParse(Console.ReadLine(), out int result);
                return result;
            } while (!output);
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

        public string GetInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public string GetPassword()
        {
            Console.Write("Password: ");
            string password = null;
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }

                password += key.KeyChar;
            }
            Console.WriteLine();
            return password;
        }

    }
}
