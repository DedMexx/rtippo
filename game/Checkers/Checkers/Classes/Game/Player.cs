using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Checkers.Classes.Game.Enums;

namespace Checkers.Classes.Game
{
    public class Player
    {
        public string Name { get; private set; }
        public SideType Side { get; private set; }
        public Checker SelectedChecker { get; private set; }
        public Game Game { get; private set; }

        public Player(string name, SideType side, Game game)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Player name cannot be null or empty!");
            }

            Name = name;
            Side = side;
            Game = game;
        }

        public void MakeMove(Move move) 
        {
            if (move == null)
                throw new ArgumentNullException(nameof(move), "Move cannot be null!");

            if (SelectedChecker != move.Checker)
                throw new InvalidOperationException("Selected checker does not match the move's checker!");

            move.ApplyMove();
        }

        // TODO: Giving Up
        public void GiveUp()
        {
            Game.PrintWinner(Game.OppositePlayer(this));
        }

        public void SelectChecker(Checker checker) 
        {
            if (checker == null)
            {
                throw new ArgumentNullException(nameof(checker), "Checker cannot be null!");
            }

            if (checker.Player != this)
            {
                throw new InvalidOperationException("Cannot select checker from opponent!");
            }

            SelectedChecker = checker;
        }

        // TODO: Ending Move
        public void EndMove()
        {
            Game.CurrentPlayer = Game.OppositePlayer(this);
        }

        // TODO: Move Possibility Check
        public bool IsAvailableToMove() {
            for (int i = 0; i < Game.Checkers.Length; i++)
            {
                if (Game.Checkers[i].Player == this && Game.Checkers[i].AvailableMoves().Count > 0)
                    return true;
            }
            return false;
        }
    }
}
