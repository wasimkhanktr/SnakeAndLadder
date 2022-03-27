﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int position = 0;
            const int LADDER = 1;
            const int NOPLAY = 2;
            const int SNAKE = 3;
            while (position < 100)
            {
                int DiceNo = random.Next(1, 7);
                int options = random.Next(1, 4);
                switch (options)
                {
                    case LADDER:
                        if (position + DiceNo > 100)
                            break;
                        position += DiceNo;
                        break;
                    case NOPLAY:
                        break;
                    case SNAKE:
                        position -= DiceNo;
                        position = Math.Max(position, 0);
                        break;
                }
            }
            Console.WriteLine("position is " + position);
        }
    }
}