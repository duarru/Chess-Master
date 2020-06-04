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
                    WindowChess.Show(playGame.Chess);

                    Console.WriteLine();
                    Console.Write("     Make your play, TAKE your piece: ");
                    Position take = WindowChess.ReadPosition().ToPosition();
                    bool[,] quadrantsToMove = playGame.Chess.Piece(take).CharacteringMove();
                    
                    Console.Clear();
                    WindowChess.Show(playGame.Chess, quadrantsToMove);
                    Console.WriteLine();
                    Console.Write("     Make your play, PUT your piece: ");
                    Position put = WindowChess.ReadPosition().ToPosition();

                    playGame.Move(take, put);
                }

            }
            catch (ChessException c)
            {
                Console.WriteLine(c.Message);
            }
            Console.ReadLine();
        }
    }
}