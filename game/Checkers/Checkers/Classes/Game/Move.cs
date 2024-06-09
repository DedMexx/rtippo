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
        public List<Checker> KilledCheckers { get; private set; }

        public Move(Checker checker, Coordinate finalCoordinate)
        {
            Checker = checker;
            FinalCoordinate = finalCoordinate;
        }

        // TODO: Implement IsValid checking
        public bool IsValid()
        {
            return false;
        }

        public void ApplyMove()
        {
            Checker.Move(FinalCoordinate);
            // TODO: Implement appending a killed checkers
        }
    }
}
