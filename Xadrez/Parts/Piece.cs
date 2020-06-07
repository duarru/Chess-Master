using System;
using System.Collections.Generic;
using Xadrez.Board;
using Xadrez.Pallets;
namespace Xadrez.Parts
{
    /// <summary>
    /// Representa as peças do Xadrez.
    /// </summary>
    abstract class Piece
    {
        /// <summary>A posição.</summary>
        public Position Position { get; set; }
        /// <summary>O tabuleiro.</summary>
        public BoardChess BoardChess { get; protected set; }
        /// <summary>A cor da peça.</summary>
        public Collor Collor { get; protected set; }
        /// <summary>A quantidade de movimento.</summary>
        public int Movement { get; protected set; }
        /// <summary>Imagens unicode.</summary>
        public List<string> image = new List<string>() { "\u2654 ", "\u2655 ", "\u2656 ", "\u2657 ", "\u2658 ", "\u2659 "};
        public Piece()
        {
        }
        /// <summary> Constructor </summary>
        /// <param name="boardChess"></param>
        /// <param name="collor"></param>
        public Piece(BoardChess boardChess, Collor collor)
        {
            Position = null;
            BoardChess = boardChess;
            Collor = collor;
            Movement = 0;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }
        /// <summary>Movimenta a peça.</summary>
        public void Move()
        {
            Movement++;
        }
        public void MoonWalker()
        {
            Movement--;
        }
        /// <summary>Recebe o movimento.</summary>
        /// <param name="quadrant"></param>
        /// <returns></returns>
        public bool Move(Position quadrant)
        {
            Piece piece = BoardChess.Piece(quadrant);
            return piece == null || piece.Collor != Collor;
        }

        /// <summary>Movimenta se possível. </summary>
        /// <returns></returns>
        public bool IsPossibleTakeMoving()
        {
            bool[,] move = CharacteringMove();
            for (int i = 0; i < BoardChess.Line; i++)
            {
                for (int j = 0; j < BoardChess.Collumn; j++)
                {
                    if (move[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>Coloca a peça se possível.</summary>
        /// <param name="quadrant"></param>
        /// <returns></returns>
        public bool IsPossiblePut(Position quadrant)
        {
            return CharacteringMove()[quadrant.Line, quadrant.Collumn];
        }
        /// <summary>Movimentos possíveis, caracteristicas do movimento.</summary>
        /// <returns></returns>
        public abstract bool[,] CharacteringMove();
    }
}
