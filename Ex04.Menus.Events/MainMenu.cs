using System;
using System.Collections.Generic;

public class MainMenu
{
    public string m_MainMenuTitle { get; }

    private readonly List<string> r_MenuItems;

    public event Action<int> MainMenuOptionSelected;

    public MainMenu(string i_MainMenuTitle, List<string> i_MenuItems)
    {
        m_MainMenuTitle = i_MainMenuTitle;
        r_MenuItems = i_MenuItems;
    }

    public void Show()
    {
        Console.Clear();
        Console.WriteLine($"** {m_MainMenuTitle} **");
        Console.WriteLine(new string('-', m_MainMenuTitle.Length + 6));

        for(int i = 0; i < r_MenuItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {r_MenuItems[i]}");
        }

        Console.WriteLine("0. Exit");
        Console.Write($"Please choose an option (1 - {r_MenuItems.Count} or 0 to exit):{Environment.NewLine}");
        int choice;
        while(!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > r_MenuItems.Count)
        {
            Console.Write("Invalid choice. Please enter a valid option: ");
        }

        MainMenuOptionSelected?.Invoke(choice);
    }
}