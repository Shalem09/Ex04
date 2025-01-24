using System;

namespace Ex04.Menus.Tests
{
    public class MethodsHandler
    {
        public void ShowVersion()
        {
            Console.WriteLine("App version 25.1.4.5480");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void CountLowercaseLetters()
        {
            Console.WriteLine("Enter text:");
            string input = Console.ReadLine();
            int count = 0;

            foreach(char c in input)
            {
                if(char.IsLower(c))
                {
                    count++;
                }
            }

            Console.WriteLine($"There are {count} lowercase letters in your text");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void ShowCurrentDate()
        {
            DateTime currentDateTime = DateTime.Now;
            string dateOnly = currentDateTime.ToString("dd/MM/yyyy");

            Console.WriteLine($"Current date is {dateOnly}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void ShowCurrentTime()
        {
            DateTime currentDateTime = DateTime.Now;
            string timeOnly = currentDateTime.ToString("HH:mm:ss");

            Console.WriteLine($"Current time is {timeOnly}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}