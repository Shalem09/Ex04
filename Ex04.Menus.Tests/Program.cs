using System;
using Ex04.Menus.Events;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Tests
{
    internal static class Program
    {
        private static void Main()
        {
            MainMenu mainMenu = new MainMenu();
            SubMenu subMenu = new SubMenu();
            MethodsHandler methodsHandler = new MethodsHandler();

            // חיבור התפריט הראשי לתת-תפריט
            mainMenu.MainMenuOptionSelected += subMenu.HandleMainMenuSelection;

            // חיבור תת-תפריט למתודות
            subMenu.SubMenuOptionSelected += HandleSubMenuOptionSelected;

            while (true)
            {
                mainMenu.Show();
            }


            //MainMenuItemEvent mainMenu = createMainMenu();
            //mainMenu.Show();
        }


        private static void HandleSubMenuOptionSelected(int i_Choice)
        {
            MethodsHandler methodsHandler = new MethodsHandler();

            switch (i_Choice)
            {
                case 1:
                    methodsHandler.ShowVersion();
                    break;
                case 2:
                    methodsHandler.CountLowercaseLetters();
                    break;
                case 0:
                    Console.WriteLine("Returning to Main Menu...");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }


        private static MainMenuItemEvent createMainMenu()
        {
            MainMenuItemEvent mainMenu = MenuItemEventFactory.CreateMainMenu("Events Main Menu");

            SubMenuItemEvent lettersAndVersionMenu = MenuItemEventFactory.CreateSubMenu("Letters and Version");
            lettersAndVersionMenu.AddSubItem(MenuItemEventFactory.Create("Show Version", showVersion));
            lettersAndVersionMenu.AddSubItem(MenuItemEventFactory.Create("Count Lowercase Letters", countLowercaseLetters));

            SubMenuItemEvent dateAndTimeMenu = MenuItemEventFactory.CreateSubMenu("Date and Time");
            dateAndTimeMenu.AddSubItem(MenuItemEventFactory.Create("Show Current Date", showCurrentDate));
            dateAndTimeMenu.AddSubItem(MenuItemEventFactory.Create("Show Current Time", showCurrentTime));

            mainMenu.AddSubItem(lettersAndVersionMenu);
            mainMenu.AddSubItem(dateAndTimeMenu);
            return mainMenu;
        }

        private static void showVersion()
        {
            Console.WriteLine("App version 25.1.4.5480");
        }

        private static void countLowercaseLetters()
        {
            int counter = 0;

            Console.WriteLine("Please enter a sentence:");
            string sentence = Console.ReadLine();

            foreach (char c in sentence)
            {
                if (char.IsLower(c))
                {
                    counter++;
                }
            }

            Console.WriteLine($"There are {counter} lowercase letters in your text");
        }

        private static void showCurrentTime()
        {
            DateTime currentDateTime = DateTime.Now;
            string timeOnly = currentDateTime.ToString("HH:mm:ss");

            Console.WriteLine($"Current time is {timeOnly}");
        }

        private static void showCurrentDate()
        {
            DateTime currentDateTime = DateTime.Now;
            string dateOnly = currentDateTime.ToString("dd/MM/yyyy");

            Console.WriteLine($"Current date is {dateOnly}");

        }
    }
}