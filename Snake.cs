namespace Snake
{
    class Snake :
    {
        private List<Position> _body;
        private int _growthSpurtsRemaining;
        private int _maxRow;
        private int _maxCol;

        public Snake(Position spawnLocation, int maxRow, int maxCol, int initialSize = 2)
        {
            _body = new List<Position> { spawnLocation };
            _growthSpurtsRemaining = Math.Max(0, initialSize - 1);
            Dead = false;
            _maxRow = maxRow;
            _maxCol = maxCol;
        }

        public bool Dead { get; private set; }
        public Position HeadPosition => _body.First();
        private IEnumerable<Position> Body => _body.Skip(1);

        public void Move(DirectionEnum direction)
        {
            if (Dead) throw new InvalidOperationException();

            Position newHead;

            switch (direction)
            {
                case DirectionEnum.Up:
                    newHead = HeadPosition.DownBy(-1);
                    break;

                case DirectionEnum.Left:
                    newHead = HeadPosition.RightBy(-1);
                    break;

                case DirectionEnum.Down:
                    newHead = HeadPosition.DownBy(1);
                    break;

                case DirectionEnum.Right:
                    newHead = HeadPosition.RightBy(1);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (_body.Contains(newHead) || !PositionIsValid(newHead))
            {
                Dead = true;
                return;
            }

            _body.Insert(0, newHead);

            if (_growthSpurtsRemaining > 0)
            {
                _growthSpurtsRemaining--;
            }
            else
            {
                _body.RemoveAt(_body.Count - 1);
            }
        }

        public void Grow()
        {
            if (Dead) throw new InvalidOperationException();

            _growthSpurtsRemaining++;
        }

        public void Render()
        {
            Console.SetCursorPosition(HeadPosition.Left, HeadPosition.Top);
            Console.Write("♦");

            foreach (var vertebra in Body)
            {
                Console.SetCursorPosition(vertebra.Left, vertebra.Top);
                Console.Write("■");
            }
        }

        private static bool PositionIsValid(Position position) =>
            position.Top >= 0 && position.Left >= 0;
    }

}
