namespace Snake
{
    class Heart :
    {
        public Heart(int numberOfRows, int numberOfColumns)
        {
            var random = new Random();
            var top = random.Next(0, numberOfRows + 1);
            var left = random.Next(0, numberOfColumns + 1);
            Position = new Position(top, left);
        }

        public Position Position { get; }

        public void Render()
        {
            Console.SetCursorPosition(Position.Left, Position.Top);
            Console.Write("♥");
        }
    }
}
