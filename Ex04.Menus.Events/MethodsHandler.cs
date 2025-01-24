using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class MethodsHandler
    {
        public void ShowVersion()
        {
            Console.WriteLine("Version 1.0");
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

            Console.WriteLine($"Lowercase letters count: {count}");
        }

        public void ShowCurrentDate()
        {
            Console.WriteLine($"Current Date: {DateTime.Now.ToShortDateString()}");
        }

        public void ShowCurrentTime()
        {
            Console.WriteLine($"Current Time: {DateTime.Now.ToShortTimeString()}");
        }
    }

}
