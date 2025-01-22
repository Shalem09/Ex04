using System;

namespace Ex04.Menus.Events
{
    public static class MenuItemEventFactory
    {
        private static readonly Action sr_DefaultAction = () => Console.WriteLine("No action assigned.");

        public static MenuItemEvent Create(string i_Title, Action i_Action = null)
        {
            return new MenuItemEvent(i_Title, i_Action ?? sr_DefaultAction);
        }

        public static SubMenuItemEvent CreateSubMenu(string i_Title)
        {
            return new SubMenuItemEvent(i_Title);
        }

        public static MainMenuItemEvent CreateMainMenu(string i_Title)
        {
            return new MainMenuItemEvent(i_Title);
        }
    }
}