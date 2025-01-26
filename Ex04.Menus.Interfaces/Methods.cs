using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class Methods : IMethods
    {
        public string m_MethodName { get; }

        public Methods(string i_MethodName)
        {
            m_MethodName = i_MethodName;
        }

        public void Execute()
        {
            switch (m_MethodName)
            {
                case "ShowVersion":
                    ShowVersion();
                    break;
                case "CountLowercaseLetters":
                    CountLowercaseLetters();
                    break;
                case "ShowCurrentDate":
                    ShowCurrentDate();
                    break;
                case "ShowCurrentTime":
                    ShowCurrentTime();
                    break;
                default:
                    Console.WriteLine("Method not implemented.");
                    break;
            }
        }

        private void ShowVersion()
        {
            Console.WriteLine("App version 25.1.4.5480");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void CountLowercaseLetters()
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
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void ShowCurrentDate()
        {
            DateTime currentDateTime = DateTime.Now;
            string dateOnly = currentDateTime.ToString("dd/MM/yyyy");

            Console.WriteLine($"Current date is {dateOnly}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void ShowCurrentTime()
        {
            DateTime currentDateTime = DateTime.Now;
            string timeOnly = currentDateTime.ToString("HH:mm:ss");

            Console.WriteLine($"Current time is {timeOnly}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
