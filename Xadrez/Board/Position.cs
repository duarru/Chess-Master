/// <summary>
/// Representa o quadrante.
/// </summary>
namespace Xadrez.Board
{
    class Position
    {
        /// <summary>linha, sequência de casas horizontais.</summary>
        public int Line { get; set; }
        /// <summary>coluna sequência de casas verticais.</summary>
        public int Collumn { get; set; }
        
        /// <summary>Constructor</summary>
        /// <param name="line"></param>
        /// <param name="collumn"></param>
        public Position(int line, int collumn)
        {
            Line = line;
            Collumn = collumn;
        }
        /// <summary>Quadrantes de movimentação, define os valores da posição.</summary>
        /// <param name="line"></param>
        /// <param name="collumn"></param>
        public void QuadrantsToMove(int line, int collumn)
        {
            Line = line;
            Collumn = collumn;
        }
        /// <summary>sobescreve com a mensagem da linha e coluna</summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Line},{Collumn}";
        }
       
    }
}