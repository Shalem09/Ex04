using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    public class IMainMenuInterface
    {
        private readonly IMenuItemInterface r_RootMenu;
        List<IMenuItemInterface> m_ItemsList = new List<IMenuItemInterface> { };

        public IMainMenuInterface(IMenuItemInterface i_RootMenuItem)
        {
            r_RootMenu = i_RootMenuItem;
        }

        public void Show()
        {
            IMenuItemInterface currentMenu = r_RootMenu;
            Stack<IMenuItemInterface> menuStack = new Stack<IMenuItemInterface>();

            while (true)
            {
                Console.Clear();

                // הצגת כותרת
                Console.WriteLine($"** {currentMenu.Title} **");
                Console.WriteLine(new string('-', 20));

                // הצגת פריטים
                for (int i = 0; i < currentMenu.SubItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {currentMenu.SubItems[i].Title}");
                }

                // אפשרות חזרה/יציאה
                Console.WriteLine(menuStack.Count > 0 ? "0. Back" : "0. Exit");

                // קלט מהמשתמש
                Console.Write("Please enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice) &&
                    choice >= 0 && choice <= currentMenu.SubItems.Count)
                {
                    if (choice == 0)
                    {
                        if (menuStack.Count > 0)
                            currentMenu = menuStack.Pop();
                        else
                            break;
                    }
                    else
                    {
                        IMenuItemInterface selectedItem = currentMenu.SubItems[choice - 1];
                        if (selectedItem.SubItems.Count > 0)
                        {
                            menuStack.Push(currentMenu);
                            currentMenu = selectedItem;
                        }
                        else
                        {
                            Console.Clear();
                            selectedItem.Execute();
                            Console.WriteLine("Press any key to return...");
                            Console.ReadKey();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                    Console.ReadKey();
                }
            }

        }
    }
}
