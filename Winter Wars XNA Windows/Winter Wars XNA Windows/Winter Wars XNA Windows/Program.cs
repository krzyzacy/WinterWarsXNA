using System;

namespace Winter_Wars_XNA_Windows
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// We need to add our menu state machine here
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

