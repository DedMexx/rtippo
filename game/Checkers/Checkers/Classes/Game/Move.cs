using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers.Classes.Game
{
    public class Move
    {
        public Checker Checker { get; private set; }
        public Coordinate FinalCoordinate { get; private set; }
        public Checker[] Checkers { get; private set; }
        public List<Checker> KilledCheckers { get; private set; } = new List<Checker>();
        public Drawer drawer;

        public Move(Drawer drawer, Checker checker, Coordinate finalCoordinate, Checker[] checkers)
        {
            if (checker == null)
            {
                throw new ArgumentNullException(nameof(checker), "Checker cannot be null!");
            }

            if (checkers == null)
            {
                throw new ArgumentNullException(nameof(checkers), "Checkers cannot be null!");
            }

            Checker = checker;
            FinalCoordinate = finalCoordinate;
            Checkers = checkers;
            this.drawer = drawer;
        }

        public bool IsValid()
        {
            for (int i = 0; i < Checker.AvailableMoves().Count; i++)
            {
                if (Checker.AvailableMoves()[i].Equals(FinalCoordinate))
                    return true;
            }
            return false;
        }

        public void ApplyMove()
        {
            if (!IsValid())
                throw new InvalidOperationException("Cannot apply invalid move!");

            int maxX = Math.Max(FinalCoordinate.X, Checker.Coordinate.X);
            int minX = Math.Min(FinalCoordinate.X, Checker.Coordinate.X);
            int maxY = Math.Max(FinalCoordinate.Y, Checker.Coordinate.Y);
            int minY = Math.Min(FinalCoordinate.Y, Checker.Coordinate.Y);


            for (int i = 0; i < Checkers.Length; i++)
            {
                if (Checkers[i].Coordinate.X < maxX && Checkers[i].Coordinate.X > minX &&
                    Checkers[i].Coordinate.Y < maxY && Checkers[i].Coordinate.Y > minY)
                {
                    KilledCheckers.Add(Checkers[i]);
                    Checkers[i].Kill();
                    drawer.DeleteChecker(Checkers[i]);
                }
            }

            Checker.Move(FinalCoordinate);

            if (Checker.Player.Side == Enums.SideType.White && FinalCoordinate.Y == 7)
            {
                Checker.MakeLady();
                drawer.MakeLady(Checker);
            }

            if (Checker.Player.Side == Enums.SideType.Black && FinalCoordinate.Y == 0)
            {
                Checker.MakeLady();
                drawer.MakeLady(Checker);
            }
        }
    }
}
