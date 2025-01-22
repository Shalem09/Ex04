﻿using System;

namespace Ex04.Menus.Events
{
    public class MainMenuItemEvent : MenuItemEvent
    {
        public MainMenuItemEvent(string i_Title) : base(i_Title, null)
        {
        }

        public void Show()
        {
            MenuItemEvent currentMenu = this;

            while (true)
            {
                Console.Clear();
                displayMenu(currentMenu);

                int choice = getUserChoice(currentMenu.SubItems.Count);

                if (choice == 0)
                {
                    Console.WriteLine("Exiting the menu. Goodbye!");
                    break;
                }

                handleSelection(ref currentMenu, choice);
            }
        }

        private static void displayMenu(MenuItemEvent i_CurrentMenu)
        {
            Console.WriteLine($"** {i_CurrentMenu.Title} **");
            Console.WriteLine(new string('-', 20));

            for (int i = 0; i < i_CurrentMenu.SubItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {i_CurrentMenu.SubItems[i].Title}");
            }

            Console.WriteLine("0. Exit");
        }

        private static int getUserChoice(int i_MaxChoice)
        {
            while (true)
            {
                Console.Write("Please enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 0 && choice <= i_MaxChoice)
                {
                    return choice;
                }

                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        private static void handleSelection(ref MenuItemEvent i_CurrentMenu, int i_Choice)
        {
            MenuItemEvent selectedItem = i_CurrentMenu.SubItems[i_Choice - 1];

            if (selectedItem is SubMenuItemEvent subMenu)
            {
                subMenu.Show(i_CurrentMenu);
            }
            else
            {
                Console.Clear();
                selectedItem.Execute();
                Console.WriteLine("Press any key to return to the previous menu...");
                Console.ReadKey();
            }
        }
    }
}