namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenuItem
    {
        public string m_MenuTitle { get; }
        private readonly IMethods r_Method;

        public MenuItem(string i_MenuTitle, IMethods i_Method)
        {
            m_MenuTitle = i_MenuTitle;
            r_Method = i_Method;
        }

        public void Execute()
        {
            r_Method?.Execute();
        }
    }
}
