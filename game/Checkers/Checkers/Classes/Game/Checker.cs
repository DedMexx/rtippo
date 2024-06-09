using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Checkers.Classes.Game.Enums;

namespace Checkers.Classes.Game
{
    public class Checker
    {
        public Coordinate Coordinate { get; private set; }
        public Player Player { get; private set; }
        // TODO AvailableMoves detect
        public List<Coordinate> AvailableMoves {  get; private set; }
        public CheckerType Type {  get; private set; } 
        public bool Killed {  get; private set; }

        public Checker(Coordinate coordinate, Player player)
        {
            Coordinate = coordinate;
            Player = player;
            Type = CheckerType.Regular;
            Killed = false;
        }

        public void MakeLady()
        {
            Type = CheckerType.Lady;
        }

        public void Kill()
        {
            Killed = true;
        }

        public void Move(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }
    }
}
