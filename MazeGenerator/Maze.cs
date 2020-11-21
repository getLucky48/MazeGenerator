using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    public class Maze
    {
        public Maze(int width, int height)
        {

            this.matrix = new string[width, height];

            this.width = width;
            this.height = height;

        }

        public void generate()
        {

            this.initialize();

            Point currentPoint = new Point(1, 1);
            Point neighbourPoint;

            Random rand = new Random();

            Stack<Point> stack = new Stack<Point>();

            do
            {

                List<Point> neighbours = getNeighbours(currentPoint);

                if(neighbours.Count > 0)
                {

                    int randomNum = rand.Next(0, neighbours.Count);

                    neighbourPoint = neighbours[randomNum];

                    stack.Push(currentPoint);

                    matrix[(neighbourPoint.x + currentPoint.x) / 2, (neighbourPoint.y + currentPoint.y) / 2] = "VISITED";
                    matrix[currentPoint.x, currentPoint.y] = "VISITED";
                    matrix[neighbourPoint.x, neighbourPoint.y] = "VISITED";

                    currentPoint = neighbourPoint;

                }
                else if(stack.Count > 0)
                {

                    currentPoint = stack.Pop();

                }
                else
                {
                    
                    Point p = getRandomUnvisited();

                    if(p.x > 0)
                    {

                        currentPoint = p;

                    }

                }

            }
            while (getUnvisited().Count != 0);

        }

        public void print()
        {

            ConsoleColor oldColor = Console.BackgroundColor;

            for(int i = 0; i < this.height; i++)
            {

                for(int j = 0; j < this.width; j++)
                {

                    string type = this.matrix[i, j];

                    if(type == "WALL") { Console.BackgroundColor = ConsoleColor.White; }
                    else if (type == "VISITED") { Console.BackgroundColor = ConsoleColor.Black; }
                    else { Console.BackgroundColor = ConsoleColor.Black; }

                    Console.Write("  ");

                }

                Console.WriteLine();

            }

            Console.BackgroundColor = oldColor;

        }

        private void initialize()
        {

            for (int i = 0; i < this.height; i++)
            {

                for (int j = 0; j < this.width; j++)
                {

                    if((i % 2 != 0 && j % 2 != 0) && (i + 1 < height && j + 1 < width))
                    {

                        this.matrix[i, j] = "UNVISITED";

                    }
                    else { this.matrix[i, j] = "WALL"; }

                }

            }

        }

        private List<Point> getNeighbours(Point currentPoint)
        {

            int x = currentPoint.x;
            int y = currentPoint.y;

            int distance = 2;

            Point up = new Point(x, y - distance);
            Point right = new Point(x + distance, y);
            Point down = new Point(x, y + distance);
            Point left = new Point(x - distance, y);

            Point[] side = { up, right, down, left };

            List<Point> points = new List<Point>();

            for (int i = 0; i < 4; i++)
            {

                if (side[i].x > 0 && side[i].x < width && side[i].y > 0 && side[i].y < height)
                {

                    string mazePointCurrent = this.matrix[side[i].x, side[i].y];

                    Point current = side[i];

                    if (mazePointCurrent == "UNVISITED")
                    {

                        points.Add(current);

                    }

                }

            }

            return points;

        }
        
        private List<Point> getUnvisited()
        {

            List<Point> points = new List<Point>();

            for (int i = 0; i < this.height; i++)
            {

                for (int j = 0; j < this.width; j++)
                {

                    if (this.matrix[i, j] == "UNVISITED") { points.Add(new Point(i, j)); }

                }

            }

            return points;

        }

        private Point getRandomUnvisited()
        {

            for (int i = 0; i < this.height; i++)
            {

                for (int j = 0; j < this.width; j++)
                {

                    if (matrix[i, j] == "UNVISITED") { return new Point(i, j); }

                }

            }

            return new Point(-1, -1);

        }

        private string[,] matrix { get; set; }
        private int width { get; set; }
        private int height { get; set; }

    }
}
