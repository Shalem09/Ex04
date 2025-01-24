namespace Ex04.Menus.Interfaces
{
    public interface IMenuItem
    {
        string m_MenuTitle { get; }

        void Execute();
    }
}