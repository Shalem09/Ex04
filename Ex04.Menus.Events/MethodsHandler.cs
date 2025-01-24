using System;


namespace Ex04.Menus.Events
{
    public class MethodsHandler
    {
        public void ShowVersion()
        {
            Console.WriteLine("App version 25.1.4.5480");

        }

        public void CountLowercaseLetters()
        {
            Console.WriteLine("Enter text:");
            string input = Console.ReadLine();
            int count = 0;

            foreach (char c in input)
            {
                if (char.IsLower(c))
                {
                    count++;
                }
            }

            Console.WriteLine($"There are {count} lowercase letters in your text");
        }

        public void ShowCurrentDate()
        {
            DateTime currentDateTime = DateTime.Now;
            string dateOnly = currentDateTime.ToString("dd/MM/yyyy");

            Console.WriteLine($"Current date is {dateOnly}");
        }

        public void ShowCurrentTime()
        {
            DateTime currentDateTime = DateTime.Now;
            string timeOnly = currentDateTime.ToString("HH:mm:ss");

            Console.WriteLine($"Current time is {timeOnly}");
        }
    }

}
