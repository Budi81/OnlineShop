using OnlineShop.BusinessLayer;

namespace OnlineShop.ConsoleInterface
{
    internal class Program
    {
        private static void Main()
        {
            Shop shopRunning = new Shop(new SqlDb(), new ConsoleController());

            shopRunning.ProgramRunning();
        }
    }
}