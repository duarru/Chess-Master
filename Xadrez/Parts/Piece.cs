using System;
using Xadrez.Board;
using Xadrez.Pallets;
namespace Xadrez.Parts
{
    /// <summary>
    /// Representa as peças do Xadrez.
    /// </summary>
    abstract class Piece
    {
        /// <summary>A posição.</summary>
        public Position Position { get; set; }
        /// <summary>O tabuleiro.</summary>
        public BoardChess BoardChess { get; protected set; }
        /// <summary>A cor da peça.</summary>
        public Collor Collor { get; protected set; }
        /// <summary>A quantidade de movimento.</summary>
        public int Movement { get; protected set; }
        /// <summary>Constructor da peça.</summary>
        /// <param name="boardChess"></param>
        /// <param name="collor"></param>
        public Piece(BoardChess boardChess, Collor collor)
        {
            Position = null;
            BoardChess = boardChess;
            Collor = collor;
            Movement = 0;
        }
        /// <summary>Movimenta a peça.</summary>
        public void Move()
        {
            Movement++;
        }
        public bool Move(Position quadrant)
        {
            Piece piece = BoardChess.Piece(quadrant);
            return piece == null || piece.Collor != Collor;
        }
        public abstract bool[,] CharacteringMove();
    }
}
