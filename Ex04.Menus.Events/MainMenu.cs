using System;
using System.Collections.Generic;

public class MainMenu
{
    public string Title { get; }

    private readonly List<string> r_MenuItems;

    public event Action<int> MainMenuOptionSelected;

    public MainMenu(string i_Title, List<string> i_MenuItems)
    {
        Title = i_Title;
        r_MenuItems = i_MenuItems;
    }

    public void Show()
    {
        Console.Clear();
        Console.WriteLine(Title);
        Console.WriteLine(new string('=', Title.Length));

        for(int i = 0; i < r_MenuItems.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {r_MenuItems[i]}");
        }

        Console.WriteLine("0. Exit");
        Console.WriteLine(new string('=', Title.Length));

        Console.Write("Please choose an option: ");
        int choice;
        while(!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > r_MenuItems.Count)
        {
            Console.Write("Invalid choice. Please enter a valid option: ");
        }

        MainMenuOptionSelected?.Invoke(choice);
    }
}