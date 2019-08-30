using System;
using System.Collections.Generic;
using System.Linq;

namespace RIVER_RAID

{

    
    static class Program
    {

        static void Main(string[] args)       
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
}

