using System;

namespace WWxna
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Play_State game = new Play_State())
            {
                game.Run();
            }
        }
    }
#endif
}

