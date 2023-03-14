using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class SnakeGame : IRenderable
    {
        private static readonly Position Origin = new Position(0, 0);

        private DirectionEnum _currentDirection;
        private DirectionEnum _nextDirection;
        private Snake _snake;
        private Heart _apple;
        const int numberOfRows = 20;
        const int numberOfColumns = 20;

        public SnakeGame()
        {
            // Init : a snake of size 5, an apple
            /*
             * ... Something is missing here 
             */
            _currentDirection = DirectionEnum.Right;
            _nextDirection = DirectionEnum.Right;
        }

        public bool GameOver => _snake.Dead;

        public void OnKeyPress(ConsoleKey key)
        {
            DirectionEnum newDirection;

            switch (key)
            {
                case ConsoleKey.Z:
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    newDirection = DirectionEnum.Up;
                    break;

                case ConsoleKey.Q:
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    newDirection = DirectionEnum.Left;
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    newDirection = DirectionEnum.Down;
                    break;

                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    newDirection = DirectionEnum.Right;
                    break;

                default:
                    return;
            }

            // Snake cannot turn 180 degrees.
            if (newDirection == OppositeDirectionTo(_currentDirection))
            {
                return;
            }

            _nextDirection = newDirection;
        }

        public void OnGameTick()
        {
            if (GameOver) throw new InvalidOperationException();
            // The snake follow the player directions : 
            _currentDirection = _nextDirection;
            // The snake move :
            _snake.Move(_currentDirection);

            // If the snake's head moves to the same position as an apple, the snake
            // eats it.
            if (_snake.HeadPosition.Equals(_apple.Position))
            {
                /*
                 * ... Something is missing here 
                 */
            }
        }

        public void Render()
        {
            // Clear the console, 
            // Render the snake and the apple
            /*
             * ... Something is missing here 
             */

            // Replace the cursor to the top, so he dont block us.
            Console.SetCursorPosition(0, 0);
        }

        private static DirectionEnum OppositeDirectionTo(DirectionEnum direction)
        {
            switch (direction)
            {
                case DirectionEnum.Up: return DirectionEnum.Down;
                case DirectionEnum.Left: return DirectionEnum.Right;
                case DirectionEnum.Right: return DirectionEnum.Left;
                case DirectionEnum.Down: return DirectionEnum.Up;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
