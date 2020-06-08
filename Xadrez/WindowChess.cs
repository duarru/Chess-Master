using System;
using System.Collections.Generic;
using Chess.BoardChess;
using Chess.Manager;
using Chess.Pallets;
using Chess.Parts;
namespace Chess
{
    /// <summary>
    /// Classe representa a tela do Xadrez.
    /// </summary>
    class WindowChess
    {
        public static List<string> image = new List<string>() { "\u2717", "\u2620", "\u3010", " \u3011" };

        /// <summary>Imprime a partida, cria a tela de apresentação.</summary>
        /// <param name="playGame"></param>
        public static void StartChessMatch(GameManager playGame)
        {
            BoardShow(playGame.chess);
            Console.WriteLine();
            Console.Write(" Current player: ");/// Current player: WHITE
            Console.WriteLine($"{playGame.PlayerImage()} \u27ae {playGame.Player()}");
            Console.Write($" Turn {playGame.CountTurn()}");/// Turn 1
            if (!playGame.winner)
            {
                if (playGame.Check)
                {
                    ConsoleColor foreground = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" YOUR ARE IN XEQUE!");
                    Console.ForegroundColor = foreground;
                }
                Console.WriteLine();
                Console.Write(" Dead " + playGame.Player() + " pieces: ");/// Dead WHITE pieces: []
                SetCapturedPiece(playGame.PiecesCaptureSepareteCollor(playGame.Player()), playGame);
            }
            else
            {
                ConsoleColor foreground = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($" XEQUEMATE \n" +
                    $" WINNER IS {playGame.Player()}");
                Console.ForegroundColor = foreground;
            }
        }
        /// <summary>Imprime o conjunto de peças.</summary>
        /// <param name="conjuntoCapetured"></param>
        /// <param name="playGame"></param>
        public static void SetCapturedPiece(HashSet<Piece> conjuntoCapetured, GameManager playGame)
        {
            ConsoleColor foreground = Console.ForegroundColor;
            if (playGame.Player() == Collor.WHITE)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(image[1]+""+image[2]);
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
            Console.WriteLine();
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write($" {8 - i} ");
                for (int j = 0; j < board.collumns; j++)
                {
                    EditCollor(board.Piece(i, j),i,j);
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a   b   c   d   e   f   g   h");
            Console.WriteLine();
        }
        /// <summary>Re imprime o tabuleiro com os movimentos possiveis.</summary>
        /// <param name="board"></param>
        /// <param name="quadrantsToMove"></param>
        public static void BoardShow(BoardChess.Board board, bool[,] quadrantsToMove)
        {
            Console.WriteLine();
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < board.collumns; j++)
                {
                    EditCollor(board.Piece(i, j), i, j, quadrantsToMove);
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a   b   c   d   e   f   g   h");
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
            }
            Console.BackgroundColor = background;
            Console.ForegroundColor = fireground;
            Console.Write(piece);
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
                    Console.Write(image[0]);
                }
                else
                {
                    Console.Write("   ");
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
            }
            Console.BackgroundColor = background;
            Console.ForegroundColor = fireground;
            Console.Write(piece);
        }
        /// <summary>Leitura dos dados de entrada para linha e coluna.</summary>
        /// <returns></returns>
        public static PositionChess ReadSquare()
        {
            string input = Console.ReadLine();
            char collumn = input[0];
            int line = int.Parse(input[1] + "");
            return new PositionChess(collumn, line);
        }
        
    }
}