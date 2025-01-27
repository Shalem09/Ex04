﻿using System;
using System.Collections.Generic;

namespace Ex04.Menus.Events
{
    public class SubMenu
    {
        public string m_SubMenuTitle { get; }

        private readonly List<string> r_MenuItems;

        public event Action<int> SubMenuOptionSelected;

        public SubMenu(string i_Title, List<string> i_MenuItems)
        {
            m_SubMenuTitle = i_Title;
            r_MenuItems = i_MenuItems;
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine($"** {m_SubMenuTitle} **");
            Console.WriteLine(new string('-', m_SubMenuTitle.Length + 6));

            for(int i = 0; i < r_MenuItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {r_MenuItems[i]}");
            }

            Console.WriteLine("0. Back");
            Console.Write($"Please choose an option (1 - {r_MenuItems.Count} or 0 to go back):{Environment.NewLine}");
            int choice;
            while(!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > r_MenuItems.Count)
            {
                Console.Write("Invalid choice. Please enter a valid option: ");
            }

            SubMenuOptionSelected?.Invoke(choice);
        }
    }
}