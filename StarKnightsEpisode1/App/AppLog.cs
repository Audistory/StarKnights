﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarKnightsEpisode1.App
{
    public static class AppLog
    {
        public static void Log(string msg,string area="")
        {
            Console.WriteLine(msg + "@" + area);
        }
    }
}
