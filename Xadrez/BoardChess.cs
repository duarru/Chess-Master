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
            Console.WriteLine();
            for (int i = 0; i < board.Line; i++)
            {
                Console.Write($" {8 - i} ");
                for (int j = 0; j < board.Collumn; j++)
                {
                    EditCollor(board.PieceOnTheBoard(i, j), i, j);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("    a  b  c  d  e  f  g  h");
            Console.WriteLine();
        }
        public static void Show(Quadrant board, bool[,] quadrantsToMove)
        {
            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor changeBackground = ConsoleColor.Cyan;
            Console.WriteLine();
            for (int i = 0; i < board.Line; i++)
            {
                Console.Write($" {8 - i} ");
                for (int j = 0; j < board.Collumn; j++)
                {
                    if (quadrantsToMove[i, j])
                    {
                        Console.BackgroundColor = changeBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = background;
                    }
                    EditCollor(board.PieceOnTheBoard(i, j), i, j);
                    Console.BackgroundColor = background;

                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("    a  b  c  d  e  f  g  h");
            Console.WriteLine();
            Console.BackgroundColor = background;
        }

        public static Quadrant Input()
        {
            string input = Console.ReadLine();
            char collumn = input[0];
            int line = int.Parse(input[1] + "");
            return new Quadrant(collumn, line);
        }
        /// <summary>Edita a cor do texto.</summary>
        /// <param name="piece"></param>
        public static void EditCollor(Piece piece, int i, int j)
        {
            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor fireground = Console.ForegroundColor;
            if (piece == null)
            {
                if (i % 2 == 0 && j % 2 == 0 || !(i % 2 == 0) && !(j % 2 == 0))
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                Console.Write("   ");
            }
            else
            {
                if (piece.Collor == Collor.WHITE)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (i % 2 == 0 && j % 2 == 0 || !(i % 2 == 0) && !(j % 2 == 0))
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                }
                else if (piece.Collor == Collor.DARKGREY)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (i % 2 == 0 && j % 2 == 0 || !(i % 2 == 0) && !(j % 2 == 0))
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                }
                Console.Write(piece);
            }
            Console.ForegroundColor = fireground;
            Console.BackgroundColor = background;
        }
    }
}