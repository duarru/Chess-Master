using System;
using System.Collections.Generic;
using System.Text;
using Xadrez.Board;

namespace Xadrez
{
    class Chess
    {
        public static void Show(BoardChess board)
        {
            for (int i = 0; i < board.Line; i++)
            {
                for (int j = 0; j < board.Collumn; j++)
                {
                    if (board.TakePiece(i,j)== null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.WriteLine(board.TakePiece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
