namespace Main
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var tickRate = TimeSpan.FromMilliseconds(100);
            var snakeGame = new SnakeGame();

            using (var cts = new CancellationTokenSource())
            {
                async Task MonitorKeyPresses()
                {
                    while (!cts.Token.IsCancellationRequested)
                    {
                        if (Console.KeyAvailable)
                        {
                            var key = Console.ReadKey(intercept: true).Key;
                            snakeGame.OnKeyPress(key);
                        }

                        await Task.Delay(10);
                    }
                }

                var monitorKeyPresses = MonitorKeyPresses();

                do
                {
                    snakeGame.OnGameTick();
                    snakeGame.Render();
                    await Task.Delay(tickRate);
                } while (!snakeGame.GameOver);

                // Allow time for user to weep before application exits.
                for (var i = 0; i < 3; i++)
                {
                    Console.Clear();
                    await Task.Delay(500);
                    snakeGame.Render();
                    await Task.Delay(500);
                }

                cts.Cancel();
                await monitorKeyPresses;
            }
        }
    }
}

