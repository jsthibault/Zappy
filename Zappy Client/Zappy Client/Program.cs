using System;

namespace Zappy_Client
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
            {
                game.Run();
            }
        }
    }
#endif
}
