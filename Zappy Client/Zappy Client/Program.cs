using System;

namespace Zappy_Client
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Zappy())
            {
                game.Run();
            }
        }
    }
#endif
}
