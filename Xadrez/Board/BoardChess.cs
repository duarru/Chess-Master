using Xadrez.Exception;
using Xadrez.Parts;

namespace Xadrez.Board
{
    /// <summary>Tabuleiro</summary>
    class BoardChess
    {
        /// <summary>Line e Collumn representa o quadrante da posição.</summary>
        public int Line { get; set; }
        public int Collumn { get; set; }
        /// <summary>Peças do Xadrez, a matriz que representa o quadrante onde a peça está.</summary>
        private Piece[,] Pieces;

        /// <summary>Constructor do Tabuleiro.</summary>
        /// <param name="line"></param>
        /// <param name="collumn"></param>
        public BoardChess(int line, int collumn) {
            Line = line;
            Collumn = collumn;
            Pieces = new Piece[Line, Collumn];
        }

        /// <summary>Retorna a peça no quadrante line e collumn.</summary>
        /// <param name="line"></param>
        /// <param name="collumn"></param>
        /// <returns></returns>
        public Piece Piece(int line, int collumn)
        {
            return Pieces[line, collumn];
        }

        /// <summary>Sobrecarga do metodo da peça, passando apenas o quadrante.</summary>
        /// <param name="quadrant"></param>
        /// <returns></returns>
        public Piece Piece(Position quadrant)
        {
            return Pieces[quadrant.Line, quadrant.Collumn];
        }

        /// <summary>Verifica se tem alguma peça no quadrante.</summary>
        /// <param name="quadrant"></param>
        /// <returns></returns>
        public bool QuadrantIsBusy(Position quadrant)
        {
            ToValidate(quadrant);
            return Piece(quadrant) != null;
        }

        /// <summary>verifica se o jogador entrou com algum dado fora do limite do tabuleiro.</summary>
        /// <param name="quadrant"></param>
        /// <returns>verdadeiro ou falso</returns>
        public bool CheckBoardLimit(Position quadrant)
        {
            if (quadrant.Line < 0 || quadrant.Collumn < 0 || quadrant.Line >= Line || quadrant.Collumn >= Collumn)
            {
                return false;
            }
            return true;
        }
        /// <summary>Invalida o movimento, se a verificação do limite for falso.</summary>
        /// <param name="quadrant"></param>
        public void ToValidate(Position quadrant)
        {
            if (!CheckBoardLimit(quadrant))
            {
                throw new ChessException("      invalid quadrant!");
            }
        }

        /// <summary>coloca a peça no tabuleiro.</summary>
        /// <param name="piece"></param>
        /// <param name="position"></param>
        public void PutPiece(Piece piece, Position position)
        {
            if (QuadrantIsBusy(position))
            {
                throw new ChessException("      You can't do that.");
            }
            Pieces[position.Line, position.Collumn] = piece;
            piece.Position = position;
        }
        /// <summary>Pega a peça do tabuleiro.</summary>
        /// <param name="quadrant"></param>
        /// <returns>peça</returns>
        public Piece TakePart(Position quadrant)
        {
            if (Piece(quadrant) == null)
            {
                return null;
            }
            Piece temp = Piece(quadrant);
            temp.Position = null;
            Pieces[quadrant.Line, quadrant.Collumn] = null;
            return temp;
        }

    }
}
