﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    public class Point
    {
        public Point(int x, int y)
        {

            this.x = x;
            this.y = y;

        }

        public int x { get; set; }
        public int y { get; set; }

    }
}
