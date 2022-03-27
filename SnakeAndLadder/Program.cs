using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAndLadder
{
    internal class Program
    {
        public static int GetPosition(int options, int DiceNo, int position)
        {
            const int LADDER = 1;
            const int NOPLAY = 2;
            const int SNAKE = 3;
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
            return position;
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            int FirstPlayerposition = 0, SecondPlayerPosition = 0, turn = 0;
            int diceRolledCount = 0;

            while (FirstPlayerposition < 100 && SecondPlayerPosition < 100)
            {
                int DiceNo = random.Next(1, 7);
                int options = random.Next(1, 4);
                if (turn == 0)
                {
                    FirstPlayerposition = GetPosition(options, DiceNo, FirstPlayerposition);
                    turn = 1;
                    if (options == 1)
                    {
                        DiceNo = random.Next(1, 7);
                        FirstPlayerposition = GetPosition(options, DiceNo, FirstPlayerposition);
                    }
                }
                else
                {
                    SecondPlayerPosition = GetPosition(options, DiceNo, SecondPlayerPosition);
                    turn = 0;
                    if (options == 1)
                    {
                        DiceNo = random.Next(1, 7);
                        SecondPlayerPosition = GetPosition(options, DiceNo, SecondPlayerPosition);
                    }

                }
                diceRolledCount++;
                Console.WriteLine("Dice No is " + diceRolledCount + " position of player one is " + FirstPlayerposition + " position of second player is " + SecondPlayerPosition);
            }
            if (FirstPlayerposition == 100)
                Console.WriteLine("Player One won");
            else
                Console.WriteLine("Player Two won ");
        }
    }
}