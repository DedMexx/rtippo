using Checkers.Classes.Game;
using Checkers.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checkers
{
    //internal static class Program
    //{
    //    // <summary>
    //    // главная точка входа для приложения.
    //    // </summary>
    //    [STAThread]
    //    static void Main()
    //    {
    //        Application.EnableVisualStyles();
    //        Application.SetCompatibleTextRenderingDefault(false);
    //        Application.Run(new MainForm());
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            Application.Run(new InputForm());
        }
    }
}
