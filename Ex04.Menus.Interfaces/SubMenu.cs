using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class SubMenu : IMenu
    {
        private readonly List<MenuItem> r_MenuItems;

        public SubMenu(string i_Title)
        {
            m_MenuTitle = i_Title;
            r_MenuItems = new List<MenuItem>();
        }

        public string m_MenuTitle { get; }

        void IMenu.AddItem(IMenuItem i_Item)
        {
            r_MenuItems.Add((MenuItem)i_Item);
        }

        void IMenuItem.Execute()
        {
            bool exit = false;

            while(!exit)
            {
                Console.Clear();
                Console.WriteLine($"** {m_MenuTitle} **");
                Console.WriteLine(new string('-', m_MenuTitle.Length));

                for(int i = 0; i < r_MenuItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {r_MenuItems[i].m_MenuTitle}");
                }

                Console.WriteLine("0. Back");
                Console.Write(
                    $"Please choose an option (1 - {r_MenuItems.Count} or 0 to go back):{Environment.NewLine}");

                string input = Console.ReadLine();
                int choice;

                if(int.TryParse(input, out choice) && choice >= 0 && choice <= r_MenuItems.Count)
                {
                    if(choice == 0)
                    {
                        exit = true;
                    }
                    else
                    {
                        (r_MenuItems[choice - 1] as IMenuItem).Execute();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Press any key to try again...");
                    Console.ReadKey();
                }
            }
        }
    }
}