using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class SubMenu
    {
        public event Action<int> SubMenuOptionSelected;

        public void HandleMainMenuSelection(int i_Option)
        {
            if (i_Option == 1) // Letters and Version
            {
                Console.WriteLine("** Letters and Version **");
                Console.WriteLine("--------------------");
                Console.WriteLine("1. Show Version");
                Console.WriteLine("2. Count Lowercase Letters");
                Console.WriteLine("0. Back");

                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());
                SubMenuOptionSelected?.Invoke(choice); // שידור האירוע
            }
            else if (i_Option == 2) // Date and Time
            {
                Console.WriteLine("** Date and Time **");
                Console.WriteLine("--------------------");
                Console.WriteLine("1. Show Current Date");
                Console.WriteLine("2. Show Current Time");
                Console.WriteLine("0. Back");

                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());
                SubMenuOptionSelected?.Invoke(choice); // שידור האירוע
            }
        }
    }

}
