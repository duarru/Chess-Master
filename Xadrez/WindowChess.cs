using System;
using Xadrez.Board;
using Xadrez.Pallets;
using Xadrez.Parts;

namespace Xadrez
{
    /// <summary>
    /// Classe representa a tela do Xadrez.
    /// </summary>
    class WindowChess
    {
        /// <summary>Imprime o tabuleiro.</summary>
        /// <param name="board"></param>
        public static void Show(BoardChess board)
        {
            Console.WriteLine();
            for (int i = 0; i < board.Line; i++)
            {
                Console.Write($" {8 - i} ");
                for (int j = 0; j < board.Collumn; j++)
                {
                    EditCollor(board.Piece(i, j), i, j);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("    a  b  c  d  e  f  g  h");
            Console.WriteLine();
        }
        /// <summary>Re imprime o tabuleiro com os movimentos possiveis.</summary>
        /// <param name="board"></param>
        /// <param name="quadrantsToMove"></param>
        public static void Show(BoardChess board, bool[,] quadrantsToMove)
        {
            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor changeBackground = ConsoleColor.DarkGray;
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
                    Console.BackgroundColor = background;
                    EditCollor(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("    a  b  c  d  e  f  g  h");
            Console.WriteLine();
            Console.BackgroundColor = background;
        }
        /// <summary>Le a posição.</summary>
        /// <returns></returns>
        public static PositionChess ReadPosition()
        {
            string input = Console.ReadLine();
            char collumn = input[0];
            int line = int.Parse(input[1] + "");
            return new PositionChess(collumn, line);
        }
        public static void EditCollor(Piece piece)
        {
            if (piece == null)
            {
                Console.Write(" - ");
            }
            else
            {
                if(piece.Collor == Collor.WHITE)
                {
                    ConsoleColor fireground = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(piece);
                    Console.ForegroundColor = fireground;
                }
                else
                {
                    ConsoleColor fireground = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(piece);
                    Console.ForegroundColor = fireground;
                }
            }
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