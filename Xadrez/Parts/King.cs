using Xadrez.Board;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class King : Piece
    {
        public King(Quadrant boardChess, Collor collor):base(boardChess, collor)
        {
        }
        public override string ToString()
        {
            return " K ";
        }
    }
}
