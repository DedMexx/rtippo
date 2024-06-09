using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Checkers.Classes.Game.Enums;

namespace Checkers.Classes.Game
{
    public class Game
    {
        public Player[] Players { get; private set; } = new Player[2];
        public Checker[] Checkers { get; private set; } = new Checker[24];
        public Player CurrentPlayer { get; set; }
        public List<Move> Moves { get; private set; } = new List<Move>();
        public Player Winner { get; private set; }
        public Coordinate[] Board { get; private set; } = new Coordinate[64];
        public bool IsDraw { get; private set; }

        // TODO: Game logic
        public Game() 
        { 
           this.GenerateBoard();

        }

        private void CreatePlayer(string name) {
            Player player;
            bool isBlackPlayer = Players[0] != null;

            player = new Player(name, isBlackPlayer ? Enums.SideType.Black : Enums.SideType.White);

            this.AppendPlayer(player);

            for (int i = 0; i < 12; i++)
            {
                int coordinageId = i * 2;
                if (isBlackPlayer)
                    coordinageId += 5 / 8 * 64;
                if (i >= 4 && i <= 8)
                    coordinageId--;
                Checkers[i + (isBlackPlayer ? 12 : 0)] = new Checker(Board[coordinageId], player);
            }
        }

        private void GenerateBoard()
        {
            for (int i = 0; i < 64; i++)
            {
                int x = i % 8;
                int y = i / 8;
                Board[i] = new Coordinate(x, y);
            }
        }

        private void AppendPlayer(Player player)
        {
            if (player.Side == Enums.SideType.White)
                Players[0] = player;
            else
                Players[1] = player;
        }

        // TODO:
        private void AppendChecker(Checker checker)
        {

        }

        // TODO:
        public void PrintWinner(Player player)
        {

        }

        // TODO:
        public void PrintDraw()
        {

        }

        public void AppendMove(Move move)
        {
            Moves.Add(move);
        }

        public Player OppositePlayer()
        {
            if (CurrentPlayer == null)
            {
                throw new InvalidOperationException("Current player is not set yet");
            }

            int oppositeIndex = (CurrentPlayer == Players[0]) ? 1 : 0;
            return Players[oppositeIndex];
        }

        public Checker GetCheckerByCoordinate(Coordinate coordinate)
        {
            for (int i = 0; i < Checkers.Length; i++)
            {
                if (Checkers[i] != null && Checkers[i].Coordinate.Equals(coordinate))
                {
                    return Checkers[i];
                }
            }
            return null;
        }

    }
}
