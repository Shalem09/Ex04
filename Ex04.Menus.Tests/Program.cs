using System;
using System.Collections.Generic;
using Ex04.Menus.Events;

namespace Ex04.Menus.Tests
{
    internal static class Program
    {
        private static bool s_IsRunning = true;
        private static readonly Stack<Object> sr_MenuHistoryStack = new Stack<Object>();

        private static void Main()
        {
            MainMenu mainMenu = createMainMenu(
                out SubMenu lettersAndVersionSubMenu,
                out SubMenu dateAndTimeSubMenu,
                out MethodsHandler methodsHandler);

            setupEventHandlers(mainMenu, lettersAndVersionSubMenu, dateAndTimeSubMenu, methodsHandler);

            sr_MenuHistoryStack.Push(mainMenu);

            runApplication();
        }

        private static MainMenu createMainMenu(
            out SubMenu o_LettersAndVersionSubMenu,
            out SubMenu o_DateAndTimeSubMenu,
            out MethodsHandler o_MethodsHandler)
        {
            string mainMenuTitle = "Delegates Main Menu";
            List<string> mainMenuSubMenuItems = new List<string>
                                                {
                                                    "Letters And Version",
                                                    "Date And Time"
                                                };
            MainMenu mainMenu = new MainMenu(mainMenuTitle, mainMenuSubMenuItems);

            string lettersAndVersionSubMenuTitle = "Letters And Version";
            List<string> lettersAndVersionSubMenuItems = new List<string>
                                                         {
                                                             "Show Version",
                                                             "Count Lowercase Letters"
                                                         };
            o_LettersAndVersionSubMenu = new SubMenu(lettersAndVersionSubMenuTitle, lettersAndVersionSubMenuItems);

            string dateAndTimeMenuTitle = "Show Current Date/Time";
            List<string> dateAndTimeMenuItems = new List<string>
                                                {
                                                    "Show Current Date",
                                                    "Show Current Time"
                                                };
            o_DateAndTimeSubMenu = new SubMenu(dateAndTimeMenuTitle, dateAndTimeMenuItems);

            o_MethodsHandler = new MethodsHandler();

            return mainMenu;
        }

        private static void setupEventHandlers(
            MainMenu i_MainMenu,
            SubMenu i_LettersAndVersionSubMenu,
            SubMenu i_DateAndTimeSubMenu,
            MethodsHandler i_MethodsHandler)
        {
            i_MainMenu.MainMenuOptionSelected += delegate (int i_Choice)
            {
                handleMainMenuSelection(i_Choice, i_LettersAndVersionSubMenu, i_DateAndTimeSubMenu);
            };

            i_LettersAndVersionSubMenu.SubMenuOptionSelected += delegate (int i_Choice)
            {
                handleSubMenuSelection(i_Choice, i_MethodsHandler, i_LettersAndVersionSubMenu);
            };

            i_DateAndTimeSubMenu.SubMenuOptionSelected += delegate (int i_Choice)
            {
                handleSubMenuSelection(i_Choice, i_MethodsHandler, i_DateAndTimeSubMenu);
            };
        }

        private static void runApplication()
        {
            while (s_IsRunning)
            {
                if (sr_MenuHistoryStack.Peek() is MainMenu currentMainMenu)
                {
                    currentMainMenu.Show();
                }
                else if (sr_MenuHistoryStack.Peek() is SubMenu currentSubMenu)
                {
                    currentSubMenu.Show();
                }
            }
        }

        private static void handleMainMenuSelection(
            int i_Choice,
            SubMenu i_LettersAndVersionSubMenu,
            SubMenu i_DateAndTimeSubMenu)
        {
            if(i_Choice == 1)
            {
                sr_MenuHistoryStack.Push(i_LettersAndVersionSubMenu);
            }
            else if(i_Choice == 2)
            {
                sr_MenuHistoryStack.Push(i_DateAndTimeSubMenu);
            }
            else if(i_Choice == 0)
            {
                Console.WriteLine("Exiting application...");
                s_IsRunning = false;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }

        private static void handleSubMenuSelection(
            int i_Choice,
            MethodsHandler i_MethodsHandler,
            SubMenu i_CurrentSubMenu)
        {
            if(i_Choice == 0)
            {
                sr_MenuHistoryStack.Pop();
            }
            else if(i_CurrentSubMenu == null)
            {
                Console.WriteLine("Invalid sub-menu. Please try again.");
            }
            else if(i_CurrentSubMenu.m_SubMenuTitle == "Letters And Version")
            {
                Console.Clear();
                if(i_Choice == 1)
                {
                    i_MethodsHandler.ShowVersion();
                }
                else if(i_Choice == 2)
                {
                    i_MethodsHandler.CountLowercaseLetters();
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if(i_CurrentSubMenu.m_SubMenuTitle == "Show Current Date/Time")
            {
                Console.Clear();

                if(i_Choice == 1)
                {
                    i_MethodsHandler.ShowCurrentDate();
                }
                else if(i_Choice == 2)
                {
                    i_MethodsHandler.ShowCurrentTime();
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }
    }
}
