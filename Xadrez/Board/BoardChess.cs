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
        /// <summary>peças do jogo.</summary>
        private Piece[,] Pieces;
        public BoardChess(int line, int collumn)
        {
            Line = line;
            Collumn = collumn;
            Pieces = new Piece[line, collumn];
        }
        public override string ToString()
        {
            return $"{Line}, {Collumn}";
        }
    }
}
