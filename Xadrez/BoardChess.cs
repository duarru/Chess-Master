using System;
using Xadrez.Board;
using Xadrez.Pallets;
using Xadrez.Parts;

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
                Console.Write(8-i + " ");
                for (int j = 0; j < board.Collumn; j++)
                {
                    if (board.PieceOnTheBoard(i,j)== null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        EditCollor(board.PieceOnTheBoard(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        /// <summary>Edita a cor do texto.</summary>
        /// <param name="piece"></param>
        public static void EditCollor(Piece piece)
        {
            if(piece.Collor == Collor.WHITE)
            {
                ConsoleColor temp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(piece);
                Console.ForegroundColor = temp;
            }
            else
            {
                ConsoleColor temp = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(piece);
                Console.ForegroundColor = temp;
            }
        }
    }
}
