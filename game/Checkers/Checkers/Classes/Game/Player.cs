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

        public Player(string name, SideType side)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name), "Player name cannot be null or empty!");
            }

            Name = name;
            Side = side;
        }

        public void MakeMove(Move move) 
        {
            if (move == null)
                throw new ArgumentNullException(nameof(move), "Move cannot be null!");

            if (SelectedChecker != move.Checker)
                throw new InvalidOperationException("Selected checker does not match the move's checker!");

            if (!move.IsValid())
                throw new InvalidOperationException("This movement is invalid!");

            move.ApplyMove();
        }

        // TODO: Giving Up
        public void GiveUp()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        // TODO: Move Possibility Check
        public bool IsAvailableToMove() {
            throw new NotImplementedException();
        }
    }
}
