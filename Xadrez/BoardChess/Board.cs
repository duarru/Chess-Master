using Chess.Exception;
using Chess.Parts;
namespace Chess.BoardChess
{
    class Board
    {
        /// <summary>Linha da classe Tabuleiro (Board).</summary>
        public int lines { get; set; }
        /// <summary>Coluna da classe Tabuleiro (Board).</summary>
        public int collumns { get; set; }
        /// <summary>Matriz privativa das peças</summary>
        private Piece[,] pieces;

        /// <summary>Constructor do Tabuleiro.</summary>
        /// <param name="lines"></param>
        /// <param name="collumns"></param>
        public Board(int lines, int collumns) {
            this.lines = lines;
            this.collumns = collumns;
            pieces = new Piece[lines, collumns];
        }

        /// <summary>Retorna a matriz peças.</summary>
        /// <param name="line"></param>
        /// <param name="collumn"></param>
        /// <returns>matriz peça.</returns>
        public Piece Piece(int line, int collumn)
        {
            return pieces[line, collumn];
        }

        /// <summary>Sobrecarga do metodo da peça, passando apenas o quadrante.</summary>
        /// <param name="quadrant"></param>
        /// <returns></returns>
        public Piece Piece(Position quadrant)
        {
            return pieces[quadrant.line, quadrant.collumn];
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
            if (quadrant.line < 0 || quadrant.collumn < 0 || quadrant.line >= lines || quadrant.collumn >= collumns)
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
            pieces[position.line, position.collumn] = piece;
            piece.position = position;
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
            temp.position = null;
            pieces[quadrant.line, quadrant.collumn] = null;
            return temp;
        }

    }
}
