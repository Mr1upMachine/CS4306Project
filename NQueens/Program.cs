using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueens
{
    public static class Constants
    {
        public const int Queen = 9;
    }
    class Program
    {
        public static bool found = false;
        static void Main(string[] args)
        {
            //Create a stopwatch for Measuring the total time taken.
            Stopwatch watch = new Stopwatch();
            watch.Start();

            
            int[,] board = new int[Constants.Queen,Constants.Queen];
            board[2, 2] = 99;
            int[,] complete = placeQueen(board,1,1);
            //Stop the watch, and output the amount of Milliseconds taken. Should be after everything is done.
            //System.Threading.Thread.Sleep(5000);            //Forces the App to wait for now to make sure stopwatch is working, will be removed.
            watch.Stop();
            long time = watch.ElapsedMilliseconds;
            Console.WriteLine(time);
        }


        public static int[,] placeQueen(int[,] nboard, int row, int col)
        {
            //Performs a Deep copy of array
            int[,] copyboard = (int[,])nboard.Clone();
            if (copyboard[row, col] == 0)
            {
                copyboard[row, col] = 2;
                //Marking Up and Down Invalid
                for (int r = 0; r < Constants.Queen - 1; r++)
                    if (copyboard[r, col] == 0)
                        copyboard[r, col] = 1;
                //Marking Left and Right Invalid
                for(int c=0;c<Constants.Queen-1;c++)
                    if (copyboard[row, c] == 0)
                        copyboard[row, c] = 1;
                //Marking Diagonal Invalid
            }

            return copyboard;
        }


    }
}
