﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseManager2022
{
    static internal class Utils
    {
        static public string PadCenter(string text, int width)
        {
            int padding = (width - text.Length) / 2;
            return text.PadLeft(padding + text.Length).PadRight(width);
        }

        static public string PadRight(string text, int width) => text.PadLeft(width);
        

        static public string PadLeft(string text, int width) => text.PadRight(width);


    }
}
