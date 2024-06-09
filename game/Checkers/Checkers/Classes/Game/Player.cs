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
            Name = name;
            Side = side;
        }

        public void MakeMove(Move move) 
        {
            // TODO: Move valid check
            move.ApplyMove();
        }

        // TODO: Giving Up
        public void GiveUp()
        {

        }

        public void SelectChecker(Checker checker) 
        {
            SelectedChecker = checker;
        }

        // TODO: Ending Move
        public void EndMove()
        {

        }

        // TODO: Move Possibility Check
        public bool IsAvailableToMove() {
            return true;
        }
    }
}
