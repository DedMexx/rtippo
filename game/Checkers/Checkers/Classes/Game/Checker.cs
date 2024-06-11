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

        public List<Coordinate> AvailableMoves(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game), "Game object cannot be null!");
            }
            if (Killed) return new List<Coordinate>();
            if (Type == CheckerType.Regular)
             return AvailableMovesForRegular(game);
            return AvailableMovesForLady(game);
        }

        private List<Coordinate> AvailableMovesForLady(Game game)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();
            int[] directions = new int[] { -1, 1 };

            foreach (int xDirection in directions)
            {
                foreach (int yDirection in directions)
                {
                    int newX = Coordinate.X + xDirection;
                    int newY = Coordinate.Y + yDirection;
                    bool canTake = false;

                    while (Coordinate.ExistingCoordinate(newX, newY))
                    {
                        Checker checkerAtDestination = game.GetCheckerByCoordinate(new Coordinate(newX, newY));

                        if (checkerAtDestination != null && !canTake)
                        {

                            if (checkerAtDestination.Player != Player)
                            {
                                int nextX = newX + xDirection;
                                int nextY = newY + yDirection;
                                if (Coordinate.ExistingCoordinate(nextX, nextY) && game.GetCheckerByCoordinate(new Coordinate(nextX, nextY)) == null)
                                {
                                    canTake = true;
                                    availableMoves.Add(new Coordinate(nextX, nextY));
                                    newX = nextX;
                                    newY = nextY;
                                }
                                else
                                    break;
                            }
                            else
                                break;
                        }

                        newX += xDirection;
                        newY += yDirection;
                    }
                }
            }

            if (availableMoves.Count <= 0)
                foreach (int xDirection in directions)
                {
                    foreach (int yDirection in directions)
                    {
                        int newX = Coordinate.X + xDirection;
                        int newY = Coordinate.Y + yDirection;

                        while (Coordinate.ExistingCoordinate(newX, newY))
                        {
                            Checker checkerAtDestination = game.GetCheckerByCoordinate(new Coordinate(newX, newY));

                            if (checkerAtDestination == null)
                            {
                                availableMoves.Add(new Coordinate(newX, newY));

                            }
                            else
                                break;

                            newX += xDirection;
                            newY += yDirection;
                        }
                    }
                }

            return availableMoves;
        }

        private List<Coordinate> AvailableMovesForRegular(Game game)
        {
            List<Coordinate> availableMoves = new List<Coordinate>();
            int[] directions = new int[] { -1, 1};
            int yDelt = Player.Side == SideType.Black ? -1 : 1;
            foreach (int xDirection in directions)
            {
                foreach (int yDirection in directions)
                {
                    int newX = Coordinate.X + xDirection;
                    int newY = Coordinate.Y + yDirection;
                    int nextX = newX + xDirection;
                    int nextY = newY + yDirection;
                    if (!Coordinate.ExistingCoordinate(newX, newY) || !Coordinate.ExistingCoordinate(nextX, nextY))
                        continue;
                    Coordinate coordinate = new Coordinate(newX, newY);
                    Checker checker = game.GetCheckerByCoordinate(coordinate);
                    Coordinate coordinateToJump = new Coordinate(nextX, nextY);
                    if (checker != null &&
                        checker.Player != Player &&
                        game.GetCheckerByCoordinate(coordinateToJump) == null)
                    {
                        availableMoves.Add(coordinateToJump);
                    }
                }
            }

            if (availableMoves.Count <= 0)
            {
                if (Coordinate.ExistingCoordinate(Coordinate.X + 1, Coordinate.Y + yDelt))
                {
                    Coordinate coordinate = new Coordinate(Coordinate.X + 1, Coordinate.Y + yDelt);
                    if (game.GetCheckerByCoordinate(coordinate) == null)
                    {
                        availableMoves.Add(coordinate);
                    }
                }
                if (Coordinate.ExistingCoordinate(Coordinate.X - 1, Coordinate.Y + yDelt))
                {
                    Coordinate coordinate = new Coordinate(Coordinate.X - 1, Coordinate.Y + yDelt);
                    if (game.GetCheckerByCoordinate(coordinate) == null)
                    {
                        availableMoves.Add(coordinate);
                    }
                }
            }

            return availableMoves;
        }
    }
}
