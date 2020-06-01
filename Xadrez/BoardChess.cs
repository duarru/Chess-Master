using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;
using Xadrez.Board;
using Xadrez.Manager;
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
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Collumn; j++)
                {
                    if (board.PieceOnTheBoard(i, j) == null)
                    {
                        if (i % 2 == 0 && j % 2 == 0)
                        {
                            ConsoleColor background = Console.BackgroundColor;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("   ");
                            Console.BackgroundColor = background;
                        }
                        else if (!(i % 2 == 0) && !(j % 2 == 0))
                        {
                            ConsoleColor background = Console.BackgroundColor;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("   ");
                            Console.BackgroundColor = background;
                        }
                        else
                        {
                            ConsoleColor background = Console.BackgroundColor;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Write("   ");
                            Console.BackgroundColor = background;
                        }
                    }
                    else
                    {
                        if (i % 2 == 0 && j % 2 == 0)
                        {
                            ConsoleColor background = Console.BackgroundColor;
                            Console.BackgroundColor = ConsoleColor.White;
                            EditCollor(board.PieceOnTheBoard(i, j));
                            Console.BackgroundColor = background;
                        }
                        else if (!(i % 2 == 0) && !(j % 2 == 0))
                        {
                            ConsoleColor background = Console.BackgroundColor;
                            Console.BackgroundColor = ConsoleColor.White;
                            EditCollor(board.PieceOnTheBoard(i, j));
                            Console.BackgroundColor = background;
                        }
                        else
                        {
                            ConsoleColor background = Console.BackgroundColor;
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            EditCollor(board.PieceOnTheBoard(i, j));
                            Console.BackgroundColor = background;
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a  b  c  d  e  f  g  h");
        }
        public static Quadrant Input()
        {
            string input = Console.ReadLine();
            char collumn = input[0];
            int line = int.Parse(input[1] + "");
            return new Quadrant(collumn,line);
        }
        /// <summary>Edita a cor do texto.</summary>
        /// <param name="piece"></param>
        public static void EditCollor(Piece piece)
        {
            if(piece.Collor == Collor.WHITE)
            {
                ConsoleColor fireground = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(piece);
                Console.ForegroundColor = fireground;
            }
            else if(piece.Collor == Collor.DARKGREY)
            {
                ConsoleColor fireground = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(piece);
                Console.ForegroundColor = fireground;
            }
        }
    }
}
