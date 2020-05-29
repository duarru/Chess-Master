using Xadrez.Parts;
/// <summary>
/// Representa o tabuleiro do Xadrez.
/// </summary>
namespace Xadrez.Board
{
    class BoardChess
    {
        /// <summary>linha, sequência de casas horizontais.</summary>
        public int Line { get; set; }
        /// <summary>coluna sequência de casas verticais.</summary>
        public int Collumn { get; set; }
        /// <summary>representa as peças do jogo.</summary>
        private Piece[,] Piece;
        public BoardChess(int line, int collumn)
        {
            Line = line;
            Collumn = collumn;
            Piece = new Piece[line, collumn];
        }
        /// <summary>Retorna a posição da peça no tabuleiro.</summary>
        /// <param name="line"></param>
        /// <param name="collum"></param>
        /// <returns>posição da linha e coluna no tabuleiro.</returns>
        public Piece TakePiece(int line, int collum)
        {
            return Piece[line, collum];
        }
        public override string ToString()
        {
            return $"{Line}, {Collumn}";
        }
    }
}
