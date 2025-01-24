using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : IMenu
    {
        private readonly List<SubMenu> r_SubMenus;

        public MainMenu(string i_Title)
        {
            m_MenuTitle = i_Title;
            r_SubMenus = new List<SubMenu>();
        }

        public string m_MenuTitle { get; }

        public void AddItem(IMenuItem i_SubMenu)
        {
            r_SubMenus.Add((SubMenu)i_SubMenu);
        }

        void IMenuItem.Execute()
        {
            bool exit = false;

            while(!exit)
            {
                Console.Clear();
                Console.WriteLine($"** {m_MenuTitle} **");
                Console.WriteLine(new string('-', m_MenuTitle.Length));

                for(int i = 0; i < r_SubMenus.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {r_SubMenus[i].m_MenuTitle}");
                }

                Console.WriteLine("0. Exit");
                Console.Write($"Please choose an option (1 - {r_SubMenus.Count} or 0 to exit):{Environment.NewLine}");

                string input = Console.ReadLine();
                int choice;

                if(int.TryParse(input, out choice) && choice >= 0 && choice <= r_SubMenus.Count)
                {
                    if(choice == 0)
                    {
                        exit = true;
                    }
                    else
                    {
                        (r_SubMenus[choice - 1] as IMenuItem).Execute();
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