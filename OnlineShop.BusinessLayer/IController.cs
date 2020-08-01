using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.BusinessLayer
{
    public interface IController
    {
        int UserChoice(string message);

        void DisplayError(string massage, int milliseconds);

        void WriteOutData(string message);

        string GetInput(string message);

        string GetPassword();
    }
}
