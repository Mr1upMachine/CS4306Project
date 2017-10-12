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
        //removed in favor of variable size
        //public const int Queen = 9;
    }
    class Program
    {
        public static bool found = false;
        public static int boardSize = 0;
        //  FOR THE BOARD:
        //  2 MEANS QUEEN
        //  1 MEANS INVALID
        //  0 MEANS AVAILABLE

        static void Main(string[] args)
        {
            //Asks the user for size of board (greater then 3)
            Console.Write("Enter a board size (greater then 3): ");
            while (true)
            {
                boardSize = Convert.ToInt32(Console.ReadLine());
                if(boardSize > 3) { break; }
                Console.WriteLine("Invalid number, enter new value: ");
            }
            
            //Create a stopwatch for Measuring the total time taken.
            Stopwatch watch = new Stopwatch();
            watch.Start();

            
            
            int[,] board = new int[boardSize,boardSize];
            int[,] complete = placeQueen(board,1,1);
            //Stop the watch, and output the amount of Milliseconds taken. Should be after everything is done.
            //System.Threading.Thread.Sleep(5000);            //Forces the App to wait for now to make sure stopwatch is working, will be removed.
            watch.Stop();
            long time = watch.ElapsedMilliseconds;
            Console.WriteLine(time);
            printBoard(complete);
        }


        //**********************************************************************************************
        /// <summary>
        /// Places a Queen on the board and marks all of the spaces that it threatens Invalid
        /// </summary>
        /// <param name="nboard"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        //**********************************************************************************************
        public static int[,] placeQueen(int[,] nboard, int row, int col)
        {
            //Performs a Deep copy of array
            int[,] copyboard = (int[,])nboard.Clone();
            if (copyboard[row, col] == 0)
            {
                copyboard[row, col] = 2;
                //Marking Up and Down Invalid
                for (int r = 0; r < boardSize; r++)
                    if (copyboard[r, col] == 0)
                        copyboard[r, col] = 1;
                //Marking Left and Right Invalid
                for(int c=0;c<boardSize;c++)
                    if (copyboard[row, c] == 0)
                        copyboard[row, c] = 1;
                #region//Marking Diagonal Invalid (Jarrod Ariola)
                //Marking Upper-left Diagonals
                for (int r = row, c = col; r >= 0 && c >= 0; r--, c--)
                    if (copyboard[r, c] == 0)
                        copyboard[r, c] = 1;
                //Marking Upper-right Diagonals
                for (int r = row, c = col; r >= 0 && c < boardSize; r--, c++)
                    if (copyboard[r, c] == 0)
                        copyboard[r, c] = 1;
                //Marking Lower-left Diagonals
                for (int r = row, c = col; r < boardSize && c >= 0; r++, c--)
                    if (copyboard[r, c] == 0)
                        copyboard[r, c] = 1;
                //Marking Lower-right Diagonals
                for (int r = row, c = col; r < boardSize && c < boardSize; r++, c++)
                    if (copyboard[r, c] == 0)
                        copyboard[r, c] = 1;
                #endregion
            }

            return copyboard;
        }


        /*
        //Test code, working on the core algorithm
        public static bool canPlaceQueen(int[,] nboard, int row, int col)
        {
            //Performs a Deep copy of array
            int[,] copyboard = (int[,])nboard.Clone();
            


            return false;
        }

        public static bool solveQueen(int[,] nboard, int col)
        {
            for (int row = 0; row < nboard.Length; row++)
            {
                if (canPlaceQueen())
                {
                    nboard = placeQueen(nboard, row, col);
                    if(solveQueen(nboard, ++col))
                    {
                        return true;
                    }
                }
            }
        }
        */



        public static void printBoard(int[,] board)
        {
            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    Console.Write(board[row, col]+"|");
                }
                Console.WriteLine();
            }
        }


    }
}
