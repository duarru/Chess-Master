using Xadrez.BoardChess;
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
                while (!playGame.winner)
                {
                    try
                    {
                        Console.Clear();
                        WindowChess.StartChessMatch(playGame);

                        Console.Write(" Make your move ");
                        Position take = WindowChess.InputRead().ToPosition();
                        playGame.ExceptionTakeMove(take);
                        bool[,] movablePiece = playGame.chess.Piece(take).CharacteringMove();

                        Console.Clear();

                        WindowChess.BoardShow(playGame.chess, movablePiece);
                        Console.Write(" Drop your move ");

                        Position putPiece = WindowChess.InputRead().ToPosition();
                        playGame.ExceptionToPut(take, putPiece);
                        playGame.MovablePerform(take, putPiece);
                    }
                    catch (ExceptionChess e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                WindowChess.StartChessMatch(playGame);
            }
            catch (ExceptionChess e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}