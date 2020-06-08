using Chess.BoardChess;
using Chess.Exception;
using System;
using Chess.Manager;
namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GameManager playGame = new GameManager();
                while (!playGame.winner)
                {
                    try
                    {
                        Console.Clear();
                        WindowChess.StartChessMatch(playGame);
                        
                        Console.WriteLine();
                        Console.Write(" Make your play, TAKE your piece: ");
                        Position take = WindowChess.ReadSquare().ToPosition();
                        playGame.CheckTakeAndMove(take);
                        bool[,] quadrantsToMove = playGame.chess.Piece(take).CharacteringMove();
                        Console.Clear();

                        WindowChess.BoardShow(playGame.chess, quadrantsToMove);
                        Console.WriteLine();
                        Console.Write($" Turn {playGame.CountTurn()}\n" +
                            $" Current player: {playGame.PlayerImage()} \u27ae {playGame.Player()}");
                        Console.WriteLine();
                        Console.Write(" Make your play, PUT your piece: ");
                        Position put = WindowChess.ReadSquare().ToPosition();
                        playGame.CheckPutInTheQuadrant(take, put);

                        playGame.PerformMotion(take, put);
                    }catch(ExceptionChess error)
                    {
                        Console.WriteLine(error.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                WindowChess.StartChessMatch(playGame);
            }
            catch (ExceptionChess c)
            {
                Console.WriteLine(c.Message);
            }
            Console.ReadLine();
        }
    }
}