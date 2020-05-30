using Xadrez.Board;
using Xadrez.Pallets;
namespace Xadrez.Parts
{
    /// <summary>
    /// Representa as peças do Xadrez.
    /// </summary>
    class Piece
    {
        /// <summary>A posição.</summary>
        public Quadrant Position { get; set; }
        /// <summary></summary>
        public Quadrant BoardChess { get; protected set; }
        /// <summary>A cor da peça.</summary>
        public Collor Collor { get; protected set; }
        /// <summary>A quantidade de movimento.</summary>
        public int Movement { get; protected set; }

        public Piece(Quadrant boardChess, Collor collor)
        {
            Position = null;
            BoardChess = boardChess;
            Collor = collor;
            Movement = 0;
        }
    }
}
