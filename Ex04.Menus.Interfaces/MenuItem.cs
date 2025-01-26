using System;


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

//namespace Ex04.Menus.Interfaces
//{
//    public class MenuItem : IMenuItem
//    {
//        public string m_MenuTitle { get; }

//        private readonly IMenuItem r_ActionHandler;

//        public MenuItem(string i_MenuTitle, IMenuItem i_ActionHandler)
//        {
//            m_MenuTitle = i_MenuTitle;
//            r_ActionHandler = i_ActionHandler;
//        }

//        void IMenuItem.Execute()
//        {
//            r_ActionHandler?.Execute();
//        }
//    }
//}

//namespace Ex04.Menus.Interfaces
//{
//    public class MenuItem : IMenuItem
//    {
//        public string m_MenuTitle { get; }

//        private readonly Action r_Action;

//        public MenuItem(string i_MenuTitle, Action i_Action)
//        {
//            m_MenuTitle = i_MenuTitle;
//            r_Action = i_Action;
//        }

//        void IMenuItem.Execute()
//        {
//            r_Action?.Invoke();
//        }
//    }
//}