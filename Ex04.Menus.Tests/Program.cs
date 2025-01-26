using System;
using System.Collections.Generic;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Tests
{
    internal static class Program
    {
        private static bool s_IsRunning = true;
        private static readonly Stack<object> sr_MenuHistoryStack = new Stack<object>();

        private static void Main()
        {
            MethodsHandler methodsHandler = new MethodsHandler();

            #region Menu with interface

            Interfaces.MainMenu mainMenu = createInterfaceMainMenu(
                out SubMenu lettersAndVersionSubInterfaceMenu,
                out SubMenu dateAndTimeInterfaceSubMenu,
                methodsHandler);
            (mainMenu as IMenuItem).Execute();

            #endregion

            #region Menu with Events Main

            MainMenu delegateMainMenu = createEventMainMenu(
                out Events.SubMenu lettersAndVersionEventsSubMenu,
                out Events.SubMenu dateAndTimeEventsSubMenu);
            setupEventHandlers(
                delegateMainMenu,
                lettersAndVersionEventsSubMenu,
                dateAndTimeEventsSubMenu,
                methodsHandler);
            sr_MenuHistoryStack.Push(delegateMainMenu);
            runApplication();

            #endregion
        }

        #region Menu with interface Methods


        private static Interfaces.MainMenu createInterfaceMainMenu(
    out SubMenu o_LettersAndVersionSubMenu,
    out SubMenu o_DateAndTimeSubMenu)
        {
            string mainMenuTitle = "Interfaces Main Menu";
            Interfaces.MainMenu mainMenu = new Interfaces.MainMenu(mainMenuTitle);

            // יצירת תפריט Letters and Version
            string lettersAndVersionSubMenuTitle = "Letters And Version";
            o_LettersAndVersionSubMenu = new SubMenu(lettersAndVersionSubMenuTitle);

            (o_LettersAndVersionSubMenu as IMenu).AddItem(
                new MenuItem("Show Version", new Methods("ShowVersion")));
            (o_LettersAndVersionSubMenu as IMenu).AddItem(
                new MenuItem("Count Lowercase Letters", new Methods("CountLowercaseLetters")));

            // יצירת תפריט Date and Time
            string dateAndTimeMenuTitle = "Show Current Date/Time";
            o_DateAndTimeSubMenu = new SubMenu(dateAndTimeMenuTitle);

            (o_DateAndTimeSubMenu as IMenu).AddItem(
                new MenuItem("Show Current Date", new Methods("ShowCurrentDate")));
            (o_DateAndTimeSubMenu as IMenu).AddItem(
                new MenuItem("Show Current Time", new Methods("ShowCurrentTime")));

            // הוספת תפריטים ראשיים
            mainMenu.AddItem(o_LettersAndVersionSubMenu);
            mainMenu.AddItem(o_DateAndTimeSubMenu);

            return mainMenu;
        }

        //private static Interfaces.MainMenu createInterfaceMainMenu(
        //    out SubMenu o_LettersAndVersionSubMenu,
        //    out SubMenu o_DateAndTimeSubMenu,
        //    MethodsHandler i_MethodsHandler)
        //{
        //    string mainMenuTitle = "Interfaces Main Menu";
        //    Interfaces.MainMenu mainMenu = new Interfaces.MainMenu(mainMenuTitle);

        //    string lettersAndVersionSubMenuTitle = "Letters And Version";
        //    o_LettersAndVersionSubMenu = new SubMenu(lettersAndVersionSubMenuTitle);

        //    (o_LettersAndVersionSubMenu as IMenu).AddItem(new MenuItem("Show Version", i_MethodsHandler.ShowVersion));
        //    (o_LettersAndVersionSubMenu as IMenu).AddItem(
        //        new MenuItem("Count Lowercase Letters", i_MethodsHandler.CountLowercaseLetters));

        //    string dateAndTimeMenuTitle = "Show Current Date/Time";
        //    o_DateAndTimeSubMenu = new SubMenu(dateAndTimeMenuTitle);

        //    (o_DateAndTimeSubMenu as IMenu).AddItem(
        //        new MenuItem("Show Current Date", i_MethodsHandler.ShowCurrentDate));
        //    (o_DateAndTimeSubMenu as IMenu).AddItem(
        //        new MenuItem("Show Current Time", i_MethodsHandler.ShowCurrentTime));

        //    mainMenu.AddItem(o_LettersAndVersionSubMenu);
        //    mainMenu.AddItem(o_DateAndTimeSubMenu);

        //    return mainMenu;
        //}

        #endregion

        #region Menu with Events Methods

        private static MainMenu createEventMainMenu(
            out Events.SubMenu o_LettersAndVersionSubMenu,
            out Events.SubMenu o_DateAndTimeSubMenu)
        {
            string mainMenuTitle = "Delegates Main Menu";
            List<string> mainMenuSubMenuItems = new List<string> { "Letters And Version", "Show Current Date/Time" };
            MainMenu mainMenu = new MainMenu(mainMenuTitle, mainMenuSubMenuItems);

            string lettersAndVersionSubMenuTitle = "Letters And Version";
            List<string> lettersAndVersionSubMenuItems = new List<string> { "Show Version", "Count Lowercase Letters" };
            o_LettersAndVersionSubMenu = new Events.SubMenu(
                lettersAndVersionSubMenuTitle,
                lettersAndVersionSubMenuItems);

            string dateAndTimeMenuTitle = "Show Current Date/Time";
            List<string> dateAndTimeMenuItems = new List<string> { "Show Current Date", "Show Current Time" };
            o_DateAndTimeSubMenu = new Events.SubMenu(dateAndTimeMenuTitle, dateAndTimeMenuItems);

            return mainMenu;
        }

        private static void setupEventHandlers(
            MainMenu i_MainMenu,
            Events.SubMenu i_LettersAndVersionSubMenu,
            Events.SubMenu i_DateAndTimeSubMenu,
            MethodsHandler i_MethodsHandler)
        {
            i_MainMenu.MainMenuOptionSelected += delegate(int i_Choice)
                {
                    handleMainMenuSelection(i_Choice, i_LettersAndVersionSubMenu, i_DateAndTimeSubMenu);
                };

            i_LettersAndVersionSubMenu.SubMenuOptionSelected += delegate(int i_Choice)
                {
                    handleSubMenuSelection(i_Choice, i_MethodsHandler, i_LettersAndVersionSubMenu);
                };

            i_DateAndTimeSubMenu.SubMenuOptionSelected += delegate(int i_Choice)
                {
                    handleSubMenuSelection(i_Choice, i_MethodsHandler, i_DateAndTimeSubMenu);
                };
        }

        private static void runApplication()
        {
            while(s_IsRunning)
            {
                if(sr_MenuHistoryStack.Peek() is MainMenu currentMainMenu)
                {
                    currentMainMenu.Show();
                }
                else if(sr_MenuHistoryStack.Peek() is Events.SubMenu currentSubMenu)
                {
                    currentSubMenu.Show();
                }
            }
        }

        private static void handleMainMenuSelection(
            int i_Choice,
            Events.SubMenu i_LettersAndVersionSubMenu,
            Events.SubMenu i_DateAndTimeSubMenu)
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
            Events.SubMenu i_CurrentSubMenu)
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
                if(i_Choice == 1)
                {
                    i_MethodsHandler.ShowVersion();
                }
                else if(i_Choice == 2)
                {
                    i_MethodsHandler.CountLowercaseLetters();
                }
            }
            else if(i_CurrentSubMenu.m_SubMenuTitle == "Show Current Date/Time")
            {
                if(i_Choice == 1)
                {
                    i_MethodsHandler.ShowCurrentDate();
                }
                else if(i_Choice == 2)
                {
                    i_MethodsHandler.ShowCurrentTime();
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }

        #endregion
    }
}