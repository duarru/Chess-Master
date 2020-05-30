using System;
using Xadrez.Board;

namespace Xadrez
{
    /// <summary>
    /// Classe representa a tela do Xadrez.
    /// </summary>
    class BoardChess
    {
        public static void Show(Quadrant board)
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
                        Console.Write(board.TakePiece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
