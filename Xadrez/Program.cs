using Xadrez.Board;
using Xadrez.Exception;
using System;
using Xadrez.Manager;
namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GameManager playGame = new GameManager();
                while (!playGame.Winner)
                {
                    try
                    {
                        Console.Clear();
                        WindowChess.StartChessMatch(playGame);
                        
                        Console.WriteLine();
                        Console.Write(" Make your play, TAKE your piece: ");
                        Position take = WindowChess.ReadPosition().ToPosition();
                        playGame.CheckTakeAndMove(take);
                        bool[,] quadrantsToMove = playGame.Chess.Piece(take).CharacteringMove();
                        Console.Clear();

                        WindowChess.Show(playGame.Chess, quadrantsToMove);
                        Console.WriteLine();
                        Console.Write($" Turn {playGame.CountTurn()}\n" +
                            $" Current player: {playGame.PlayerImage()} \u27ae {playGame.Player()}");
                        Console.WriteLine();
                        Console.Write(" Make your play, PUT your piece: ");
                        Position put = WindowChess.ReadPosition().ToPosition();
                        playGame.CheckPutInTheQuadrant(take, put);

                        playGame.PerformMotion(take, put);
                    }catch(ChessException error)
                    {
                        Console.WriteLine(error.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                WindowChess.StartChessMatch(playGame);
            }
            catch (ChessException c)
            {
                Console.WriteLine(c.Message);
            }
            Console.ReadLine();
        }
    }
}