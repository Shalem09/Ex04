using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class IMenuItemInterface : IActionable
    {
        public string Title { get; }
        public List<IMenuItemInterface> SubItems { get; }
        public IActionable Action { get; private set; }

        internal IMenuItemInterface(string i_Title, IActionable i_Action)
        {
            Title = i_Title;
            Action = i_Action;
            SubItems = new List<IMenuItemInterface>();
        }

        public void AddSubItem(IMenuItemInterface i_SubItem)
        {
            SubItems.Add(i_SubItem);
        }

        public void RemoveSubItem(IMenuItemInterface i_SubItem)
        {
            SubItems.Remove(i_SubItem);
        }

        public void Execute()
        {
            Action.Execute();
        }
    }

}
