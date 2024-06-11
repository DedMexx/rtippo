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
            GenerateBoard();
            CreatePlayer("Роман");
            CreatePlayer("Иван");

            CurrentPlayer = Players[0];
            CurrentPlayer.SelectChecker(Checkers[10]);
            for (int i = 0; i < CurrentPlayer.SelectedChecker.AvailableMoves().Count; i++)
            {
                Console.WriteLine($"{CurrentPlayer.SelectedChecker.AvailableMoves()[i].X} {CurrentPlayer.SelectedChecker.AvailableMoves()[i].Y}");
            }
            Move move1 = new Move(CurrentPlayer.SelectedChecker, new Coordinate(4, 3), Checkers);
            CurrentPlayer.MakeMove(move1);
            AppendMove(move1);
            CurrentPlayer.EndMove();

            CurrentPlayer.SelectChecker(Checkers[13]);
            Move move2 = new Move(CurrentPlayer.SelectedChecker, new Coordinate(3, 4), Checkers);
            CurrentPlayer.MakeMove(move2);
            AppendMove(move2);
            CurrentPlayer.EndMove();

            CurrentPlayer.SelectChecker(Checkers[10]);
            Move move3 = new Move(CurrentPlayer.SelectedChecker, CurrentPlayer.SelectedChecker.AvailableMoves()[0], Checkers);
            CurrentPlayer.MakeMove(move3);
            AppendMove(move3);
            CurrentPlayer.EndMove();

            Console.WriteLine(Checkers[13].Killed);

            //for (int i = 0; i < CurrentPlayer.SelectedChecker.AvailableMoves(this).Count; i++)
            //{
            //    Console.WriteLine($"{CurrentPlayer.SelectedChecker.AvailableMoves(this)[i].X} {CurrentPlayer.SelectedChecker.AvailableMoves(this)[i].Y}");
            //}
            //Console.WriteLine($"{CurrentPlayer.SelectedChecker.AvailableMoves(this)}");
            //Move move3 = new Move(CurrentPlayer.SelectedChecker, new Coordinate(6, 6), Checkers);
            //CurrentPlayer.MakeMove(move1);

        }

        private void CreatePlayer(string name) {
            if (Players.All(p => p != null))
            {
                throw new InvalidOperationException("Maximum number of players reached!");
            }
            Player player;
            bool isBlackPlayer = Players[0] != null;
            int offset = isBlackPlayer ? 40 : 0;

            player = new Player(name, isBlackPlayer ? Enums.SideType.Black : Enums.SideType.White, this);

            AppendPlayer(player);

            for (int i = 0; i < 12; i++)
            {
                int coordinageId = i * 2 + 1;
                coordinageId += offset;
                if (isBlackPlayer) coordinageId--;
                if (i >= 4 && i < 8)
                    if (isBlackPlayer)
                        coordinageId++;
                    else
                        coordinageId--;
                AppendChecker(new Checker(Board[coordinageId], player, this));
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
            {
                if (Players[0] != null)
                {
                    throw new InvalidOperationException("White player slot already occupied!");
                }
                Players[0] = player;
            }
            else
            {
                if (Players[1] != null)
                {
                    throw new InvalidOperationException("Black player slot already occupied!");
                }
                Players[1] = player;
            }
        }

        private void AppendChecker(Checker checker)
        {
            int freeSlotIndex = Array.IndexOf(Checkers, null);

            if (freeSlotIndex == -1)
            {
                throw new InvalidOperationException("Maximum number of checkers reached!");
            }

            Checkers[freeSlotIndex] = checker;
        }

        // TODO:
        public void PrintWinner(Player player)
        {
            throw new NotImplementedException();
        }

        // TODO:
        public void PrintDraw()
        {
            throw new NotImplementedException();
        }

        public void AppendMove(Move move)
        {
            Moves.Add(move);
        }

        public Player OppositePlayer(Player player)
        {
            if (player == null)
            {
                throw new InvalidOperationException("Current player is not set yet");
            }

            int oppositeIndex = (player == Players[0]) ? 1 : 0;
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
