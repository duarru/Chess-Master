using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;
using Xadrez.Exception;
using Xadrez.Parts;
/// <summary>
/// Representa o quadrante.
/// </summary>
namespace Xadrez.Board
{
    class Quadrant
    {
        /// <summary>linha, sequência de casas horizontais.</summary>
        public int Line { get; set; }
        /// <summary>coluna sequência de casas verticais.</summary>
        public int Collumn { get; set; }
        /// <summary>coluna sequencia de casas verticais em caracteres.</summary>
        public char CollumnChar { get; set; }
        /// <summary>para a posição da peça no tabuleiro.</summary>
        private Piece[,] Piece;
        public Quadrant(int line, int collumn)
        {
            Line = line;
            Collumn = collumn;
            Piece = new Piece[line, collumn];
        }
        public Quadrant(char collumnChar, int line)
        {
            CollumnChar = collumnChar;
            Line = line;
        }
        /// <summary>retorna a posição da peça no tabuleiro.</summary>
        /// <param name="line"></param>
        /// <param name="collum"></param>
        /// <returns>posição da linha e coluna no tabuleiro.</returns>
        public Piece PieceOnTheBoard(int line, int collum)
        {
            return Piece[line, collum];
        }
        /// <summary>peça está no tabuleiro.</summary>
        /// <param name="quadrant"></param>
        /// <returns>retorna sua posição(peça) no tabuleiro.</returns>
        public Piece PieceOnTheBoard(Quadrant quadrant)
        {
            return Piece[quadrant.Line, quadrant.Collumn];
        }
        /// <summary>pega a peça e a coloca no tabuleiro.</summary>
        /// <param name="piece"></param>
        /// <param name="position"></param>
        public void PutPiece(Piece piece, Quadrant position)
        {
            if (CheckException(position))
            {
                throw new ChessException("You can't do that.");
            }
            Piece[position.Line, position.Collumn] = piece;
            piece.Position = position;
        }
        /// <summary>verifica se o jogador entrou com algum dado fora do contexto do tabuleiro.</summary>
        /// <param name="quadrant"></param>
        /// <returns>mensagem de erro.</returns>
        public bool CheckException(Quadrant quadrant)
        {
            if (quadrant.Line < 0 || quadrant.Collumn < 0 || quadrant.Line >= Line || quadrant.Collumn >= Collumn)
            {
                throw new ChessException("invalid movement!");
            }
            return PieceOnTheBoard(quadrant) != null;
        }
        /// <summary>sobescreve com a mensagem da linha e coluna</summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Line},{Collumn}";
        }
        /// <summary>apresenta a mensagem no formato do xadrez.</summary>
        /// <returns>coluna em caracter e a linha</returns>
        public virtual string Message()
        {
            return $" {CollumnChar}{Line}";
        }
        /// <summary>calculo para subtrair linha e coluna, garantindo o limite do tabuleiro.</summary>
        /// <returns></returns>
        public Quadrant MessagePosition()
        {
            return new Quadrant(8 - Line, CollumnChar - 'a'); ;
        }
    }
}