using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class MenuItemEvent
    {
        public string Title { get; }
        public List<MenuItemEvent> SubItems { get; }
        public Action Action { get; }

        internal MenuItemEvent(string i_Title, Action i_Action)
        {
            Title = i_Title;
            SubItems = new List<MenuItemEvent>();
            Action = i_Action;
        }


        public void AddSubItem(MenuItemEvent i_SubItem)
        {
            SubItems.Add(i_SubItem);
        }

        public void Execute()
        {
            Action?.Invoke();
        }
    }
}