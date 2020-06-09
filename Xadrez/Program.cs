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
                GameManager playerGame = new GameManager();
                while (!playerGame.winner)
                {
                    Console.Clear();
                    WindowChess.StartChessMatch(playerGame);
                    Console.WriteLine("Make your move ");
                    Position takePiece = WindowChess.InputRead().ToPosition();
                }
            }
            catch (ExceptionChess e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}