using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly List<SubMenu> r_SubMenu;
        public string m_MenuTitle { get; }

        public MainMenu(string i_Title)
        {
            m_MenuTitle = i_Title;
            r_SubMenu = new List<SubMenu>();
        }

        public void AddSubMenu(SubMenu i_SubMenu)
        {
            r_SubMenu.Add(i_SubMenu);
        }

        public void Show()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"** {m_MenuTitle} **");
                Console.WriteLine(new string('-', m_MenuTitle.Length));

                for (int i = 0; i < r_SubMenu.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {r_SubMenu[i].m_MenuTitle}");
                }

                Console.WriteLine("0. Exit");
                Console.Write($"Please choose an option (1 - {r_SubMenu.Count} or 0 to exit):{Environment.NewLine}");

                string input = Console.ReadLine();
                int choice;

                if (int.TryParse(input, out choice) && choice >= 0 && choice <= r_SubMenu.Count)
                {
                    if (choice == 0)
                    {
                        exit = true;
                    }
                    else
                    {
                        (r_SubMenu[choice - 1] as IMenu).Show();
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