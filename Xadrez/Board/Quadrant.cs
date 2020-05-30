using System.ComponentModel.Design;
using System.Xml;
using Xadrez.Exception;
using Xadrez.Parts;
/// <summary>
/// Representa o tabuleiro do Xadrez.
/// </summary>
namespace Xadrez.Board
{
    class Quadrant
    {
        /// <summary>linha, sequência de casas horizontais.</summary>
        public int Line { get; set; }
        /// <summary>coluna sequência de casas verticais.</summary>
        public int Collumn { get; set; }
        /// <summary>representa as peças do jogo.</summary>
        private Piece[,] Piece;
        public Quadrant(int line, int collumn)
        {
            Line = line;
            Collumn = collumn;
            Piece = new Piece[line, collumn];
        }
        /// <summary>Retorna a posição da peça no tabuleiro.</summary>
        /// <param name="line"></param>
        /// <param name="collum"></param>
        /// <returns>posição da linha e coluna no tabuleiro.</returns>
        public Piece PieceOnTheBoard(int line, int collum)
        {
            return Piece[line, collum];
        }

        public Piece PieceOnTheBoard(Quadrant quadrant)
        {
            return Piece[quadrant.Line, quadrant.Collumn];
        }

        public void PutPiece(Piece piece, Quadrant position)
        {
            if (CheckException(position))
            {
                throw new ChessException("You can't do that.");
            }
            Piece[position.Line, position.Collumn] = piece;
            piece.Position = position;
        }

        public bool CheckException(Quadrant quadrant)
        {
            if(quadrant.Line<0 || quadrant.Collumn < 0 || quadrant.Line >= Line || quadrant.Collumn >= Collumn)
            {
                throw new ChessException("invalid movement!");
            }
            return PieceOnTheBoard(quadrant) != null;
        }
        public override string ToString()
        {
            return $"{Line}, {Collumn}";
        }
    }
}
