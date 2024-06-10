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
            if (checker == null)
            {
                throw new ArgumentNullException(nameof(checker), "Checker cannot be null!");
            }

            Checker = checker;
            FinalCoordinate = finalCoordinate;
        }

        // TODO: Implement IsValid checking
        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public void ApplyMove()
        {
            if (!IsValid())
            {
                // TODO: when not valid
                throw new InvalidOperationException("Cannot apply invalid move!");
            }
            Checker.Move(FinalCoordinate);
            // TODO: Implement appending a killed checkers
            throw new NotImplementedException();
        }
    }
}
