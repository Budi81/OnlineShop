using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public interface IControler
    {
        int UserChoice();

        void DisplayError(string massage, int miliseconds);

        void WriteOutData(string message);
    }
}
