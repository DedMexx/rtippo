using Checkers.Classes.Game;
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
            Game game = new Game();
           
            //for (int i = 0; i < game.Checkers.Length; i++)
            //{
            //    Console.WriteLine($"{game.Checkers[i].Coordinate.X} {game.Checkers[i].Coordinate.Y}");
            //}
            //for (int i = 0; i < game.Checkers.Length; i++) {
            //Console.WriteLine($"{game.Checkers[i]}");
            //}
            //Console.WriteLine($"{game.GetCheckerByCoordinate(new Coordinate(6, 2)).Coordinate.X} {game.GetCheckerByCoordinate(new Coordinate(6, 2)).Coordinate.Y}");

            //Console.WriteLine($"{game.Checkers[8].Coordinate.X} {game.Checkers[8].Coordinate.Y}");
            //game.Checkers[8].MakeLady();
            //game.Checkers[14].Move(new Coordinate(2, 3));
            //game.Checkers[18].Move(new Coordinate(4, 5));
            //Console.WriteLine(game.Checkers[8].AvailableMoves(game).Count);
            //for (int i = 0; i < game.Checkers[8].AvailableMoves(game).Count; i++)
            //{
            //    Console.WriteLine($"{game.Checkers[8].AvailableMoves(game)[i].X} {game.Checkers[8].AvailableMoves(game)[i].Y}");
            //}

            //Console.WriteLine(game.Board[game.Board.Length - 1].X);
            //Console.WriteLine(game.B)
            //for (int i = 0; i < game.Checkers.Length; i++)
            //{
            //    Console.WriteLine($"{game.Checkers[i].Coordinate.X} {game.Checkers[i].Coordinate.Y}");
            //}
        }
    }
}
