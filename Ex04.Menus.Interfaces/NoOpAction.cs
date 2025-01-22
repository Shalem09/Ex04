using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class NoOpAction : IActionable
    {
        public void Execute()
        {
            Console.WriteLine("No action assigned to this menu item.");
        }
    }

}
