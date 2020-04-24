using System;
using TicTacToe.Interfaces;

namespace TicTacToe
{
    public abstract class Player
    {
        public int ReadChoice()
        {
            int input = -1;
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a number between 1 and 9");
            }

            return input;
        }
    }
}
