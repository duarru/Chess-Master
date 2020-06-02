using Xadrez.Board;
using Xadrez.Exception;
using Xadrez.Pallets;
using Xadrez.Parts;
using System;
using Xadrez.Manager;
using System.ComponentModel.Design;
using System.Runtime.InteropServices.ComTypes;

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
                    Console.Clear();
                    BoardChess.Show(playGame.Chess);
                    Console.WriteLine();
                    Console.Write("Make your play, TAKE your piece:");
                    Quadrant take = BoardChess.Input().ShowPositonChess();
                    BoardChess.Show(playGame.Chess);
                    Console.WriteLine();
                    Console.Write($"Make your play, PUT your piece: ");
                    Quadrant put = BoardChess.Input().ShowPositonChess();

                    playGame.Move(take, put);
                }

            }
            catch (ChessException c)
            {
                Console.WriteLine(c.Message);
            }
        }
    }
}