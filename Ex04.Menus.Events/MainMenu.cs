using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class MainMenu
    {
        public event Action<int> MainMenuOptionSelected;

        public void Show()
        {
            Console.WriteLine("** Events Main Menu **");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Letters and Version");
            Console.WriteLine("2. Date and Time");
            Console.WriteLine("0. Exit");

            Console.Write("Choose an option: ");
            int choice = int.Parse(Console.ReadLine());
            MainMenuOptionSelected?.Invoke(choice); // שידור האירוע
        }
    }
}