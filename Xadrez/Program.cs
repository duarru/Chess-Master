using Xadrez.Board;
using Xadrez.Exception;
using Xadrez.Pallets;
using Xadrez.Parts;
using System;
namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Quadrant quadrant = new Quadrant(8, 8);
                quadrant.PutPiece(new Tower(quadrant, Collor.BLACK), new Quadrant(0, 0));
                quadrant.PutPiece(new Tower(quadrant, Collor.BLACK), new Quadrant(1, 3));
                quadrant.PutPiece(new King(quadrant, Collor.BLACK), new Quadrant(0, 2));
                quadrant.PutPiece(new Tower(quadrant, Collor.WHITE), new Quadrant(3, 5));

                BoardChess.Show(quadrant);
            }
            catch (ChessException c)
            {
                Console.WriteLine(c.Message);
            }
        }
    }
}
