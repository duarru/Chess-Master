using System.Drawing;
using Xadrez.Board;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class Tower : Piece
    {
        public Tower(Quadrant boardChess, Collor collor) : base(boardChess, collor)
        {
        }
        public override string ToString()
        {
            return " T ";
        }
    }
}
