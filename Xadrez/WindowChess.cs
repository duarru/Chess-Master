using System;
using System.Collections.Generic;
using Xadrez.BoardChess;
using Xadrez.Manager;
using Xadrez.Pallets;
using Xadrez.Parts;
namespace Xadrez
{
    class WindowChess
    {
        public static List<string> image = new List<string>() { " \u2717  ", "\u2620", "\u3010", " \u3011" };//{✗, ☠, 【, 】}
        public static List<string> alphabet = new List<string>() { "    \u24b6", "  \u24b7", "  \u24b8", "  \u24b9",
                                                                   "  \u24ba", "  \u24bb", "  \u24bc", "  \u24bd" };//a,b,c,d,e,f,g,h
        public static List<string> numbers = new List<string>() { "\u2780", "\u2781", "\u2782", "\u2783",
                                                                   "\u2784", "\u2785", "\u2786", "\u2787" };//1,2,3,4,5,6,7,8
        public static List<string> checkMate = new List<string>() { "\u24b8", "\u24bd", "\u24ba", "\u24c0",
                                                                    "\u24c2", "\u24b6", "\u24c9", "\u24ba" };//C,H,E,K,M,A,T,E
        /// <summary>Imprime a partida, 
        /// cria a tela de apresentação, inicia a partida.</summary>
        /// <param name="playGame"></param>
        public static void StartChessMatch(GameManager playGame)
        {
            BoardShow(playGame.chess);
            Console.WriteLine();
            /// Current player: WHITE
            Console.Write(" Current player: ");
            Console.WriteLine($"{playGame.image[0]} {playGame.image[1]} {playGame.Player()}");
            /// Turn 1
            Console.Write($" Turn {playGame.CountTurn()}");
            if (!playGame.winner)
            {
                if (playGame.check)
                {
                    ConsoleColor foreground = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($" {checkMate[0]}{checkMate[1]}{checkMate[2]}{checkMate[0]}{checkMate[3]}");
                    Console.ForegroundColor = foreground;
                }
                Console.WriteLine();
                Console.Write(" Dead " + playGame.currentPlayer + " pieces: ");/// Dead WHITE pieces: []
                SetCapturedPiece(playGame.PiecesCaptureSepareteCollor(playGame.currentPlayer), playGame);
                Console.WriteLine();
            }
            else
            {
                ConsoleColor foreground = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($" {checkMate[0]}{checkMate[1]}{ checkMate[2]}{checkMate[0]}{ checkMate[3]}" +
                    $"{checkMate[4]}{checkMate[5]}{checkMate[6]}{checkMate[7]}\n" +
                    $" WINNER IS {playGame.currentPlayer}");
                Console.ForegroundColor = foreground;
            }
        }
        /// <summary>Imprime o conjunto de peças.</summary>
        /// <param name="conjuntoCapetured"></param>
        /// <param name="playGame"></param>
        public static void SetCapturedPiece(HashSet<Piece> conjuntoCapetured, GameManager playGame)
        {
            ConsoleColor foreground = Console.ForegroundColor;
            if (playGame.currentPlayer == Collor.WHITE)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(image[1] + "" + image[2]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(image[1] + "" + image[2]);
            }
            foreach (Piece capture in conjuntoCapetured)
            {
                Console.Write(capture + " ");
            }
            Console.Write(image[3]);
            Console.ForegroundColor = foreground;
        }

        /// <summary>Imprime o tabuleiro.</summary>
        /// <param name="board"></param>
        public static void BoardShow(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write($" {numbers[7 - i]} ");
                for (int j = 0; j < board.collumns; j++)
                {
                    EditCollor(board.Piece(i, j), i, j);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"{ alphabet[0]}{ alphabet[1]}{ alphabet[2]}{ alphabet[3]}" +
                $"{ alphabet[4]}{ alphabet[5]}{ alphabet[6]}{ alphabet[7]}");
            Console.WriteLine();
        }
        /// <summary>Re imprime o tabuleiro com os movimentos possiveis.</summary>
        /// <param name="board"></param>
        /// <param name="squareToMove"></param>
        public static void BoardShow(Board board, bool[,] squareToMove)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write($" {numbers[7 - i]} ");
                for (int j = 0; j < board.collumns; j++)
                {
                    EditCollor(board.Piece(i, j), i, j, squareToMove);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"{ alphabet[0]}{ alphabet[1]}{ alphabet[2]}{ alphabet[3]}" +
                            $"{ alphabet[4]}{ alphabet[5]}{ alphabet[6]}{ alphabet[7]}");
            Console.WriteLine();
        }
        /// <summary>Edita as cores das peças.</summary>
        /// <param name="piece"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
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
                Console.Write("    ");
            }
            else
            {
                if (piece.collor == Collor.WHITE)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue; // mude a cor aqui
                    if (i % 2 == 0 && j % 2 == 0 || !(i % 2 == 0) && !(j % 2 == 0))
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;

                    }
                }
                else if (piece.collor == Collor.BLACK)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; // mude a cor aqui
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
            Console.BackgroundColor = background;
            Console.ForegroundColor = fireground;
        }
        /// <summary>Edita cor da peça, para os movimentos possiveis das peças.</summary>
        /// <param name="piece"></param>
        public static void EditCollor(Piece piece, int i, int j, bool[,] squareToMove)
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
                if (squareToMove[i, j])
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(image[0]);
                }
                else
                {
                    Console.Write("    ");
                }
            }
            else
            {
                if (piece.collor == Collor.WHITE)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue; // mude a cor aqui
                    if (i % 2 == 0 && j % 2 == 0 || !(i % 2 == 0) && !(j % 2 == 0))
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;

                    }
                }
                else if (piece.collor == Collor.BLACK)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed; // mude a cor aqui
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
            Console.BackgroundColor = background;
            Console.ForegroundColor = fireground;
        }
        /// <summary>Leitura dos dados de entrada para linha e coluna.</summary>
        /// <returns></returns>
        public static PositionChess InputRead()
        {
            string input = Console.ReadLine();
            char collumn = input[0];
            int line = int.Parse(input[1] + "");
            return new PositionChess(collumn, line);
        }

    }
}