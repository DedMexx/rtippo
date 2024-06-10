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
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player), "Player cannot be null!");
            }

            Coordinate = coordinate;
            Player = player;
            Type = CheckerType.Regular;
            Killed = false;
        }

        public void MakeLady()
        {
            if (Killed)
            {
                throw new InvalidOperationException("Cannot make a killed checker a lady!");
            }
            Type = CheckerType.Lady;
        }

        public void Kill()
        {
            if (Killed)
            {
                throw new InvalidOperationException("Checker is already killed!");
            }
            Killed = true;
        }

        public void Move(Coordinate coordinate)
        {
            Coordinate = coordinate;
        }
    }
}
