using System;

namespace MazeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {

            Maze maze = new Maze(23, 23);

            maze.generate();
            maze.print();

        }
    }
}
