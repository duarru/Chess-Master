namespace Chess.BoardChess
{
    class PositionChess
    {
        /// <summary>Coluna da classe Posição do Xadrez.</summary>
        public char collumn { get; set; }
        /// <summary>Linha da classe Posição do Xadrez.</summary>
        public int line { get; set; }

        /// <summary>Constructor da classe Posição do Xadrez.</summary>
        /// <param name="collumn"></param>
        /// <param name="line"></param>
        public PositionChess(char collumn, int line)
        {
            this.collumn = collumn;
            this.line = line;
        }

        /// <summary>Posição em relação ao Xadrez.</summary>
        /// <returns>mensagem linha, coluna.</returns>
        public Position ToPosition()
        {
            return new Position(8 - line, collumn - 'a');
        }

        /// <summary>Sobreposição retorna mensagem coluna e linha.</summary>
        /// <returns>mensagem ('a1').</returns>
        public override string ToString()
        {
            return "" + collumn + line;
        }
    }
}
