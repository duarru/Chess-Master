namespace Chess.BoardChess
{
    class Position
    {
        /// <summary>Linha da classe Posicão.</summary>
        public int line { get; set; }
        /// <summary>Coluna da classe Posicão.</summary>
        public int collumn { get; set; }
        
        /// <summary>Constructor da classe Posição.</summary>
        /// <param name="line"></param>
        /// <param name="collumn"></param>
        public Position(int line, int collumn)
        {
            this.line = line;
            this.collumn = collumn;
        }
        /// <summary>Quadrantes de movimentação, define os valores da posição.</summary>
        /// <param name="line"></param>
        /// <param name="collumn"></param>
        public void QuadrantsToMove(int line, int collumn)
        {
            this.line = line;
            this.collumn = collumn;
        }
        /// <summary>Sobreposição mensagem linha, coluna.</summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{line},{collumn}";
        }
       
    }
}