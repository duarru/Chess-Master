using Xadrez.Board;
using Xadrez.Pallets;
using Xadrez.Parts;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Quadrant quadrant = new Quadrant(8,8);
            quadrant.PutPiece(new Tower(quadrant, Collor.BLACK), new Quadrant(0, 0));
            quadrant.PutPiece(new Tower(quadrant, Collor.BLACK), new Quadrant(1, 3));
            quadrant.PutPiece(new King(quadrant, Collor.BLACK), new Quadrant(2, 4));

            BoardChess.Show(quadrant);
        }
    }
}
