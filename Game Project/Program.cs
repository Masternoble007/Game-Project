﻿using System;

namespace Game_Project
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new GameProject())
                game.Run();
        }
    }
}
