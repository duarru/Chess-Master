namespace Xadrez.Board
{
    /// <summary>Posição do quadrante.</summary>
    class PositionChess
    {
        /// <summary>Coluna.</summary>
        public char Collumn { get; set; }
        /// <summary>Linha.</summary>
        public int Line { get; set; }

        /// <summary>Constructor.</summary>
        /// <param name="collumn"></param>
        /// <param name="line"></param>
        public PositionChess(char collumn, int line)
        {
            Collumn = collumn;
            Line = line;
        }

        /// <summary>Posição em relação ao Xadrez.</summary>
        /// <returns></returns>
        public Position ToPosition()
        {
            return new Position(8 - Line, Collumn - 'a');
        }
        /// <summary>sobrescreve a mensagem coluna linha um do lado do outro ex:(a1)</summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "" + Collumn + Line;
        }
    }
}
