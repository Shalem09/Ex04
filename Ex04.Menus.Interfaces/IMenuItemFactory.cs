using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public static class IMenuItemFactory
    {
        private static readonly IActionable sr_DefaultAction = new NoOpAction();

        public static IMenuItemInterface Create(string i_Title, IActionable i_Action = null)
        {
            return new IMenuItemInterface(i_Title, i_Action ?? sr_DefaultAction);
        }
    }

}
