using System;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenuItem
    {
        public string m_MenuTitle { get; }

        private readonly Action r_Action;

        public MenuItem(string i_MenuTitle, Action i_Action)
        {
            m_MenuTitle = i_MenuTitle;
            r_Action = i_Action;
        }

        void IMenuItem.Execute()
        {
            r_Action?.Invoke();
        }
    }
}