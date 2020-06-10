using Xadrez.Exception;
using Xadrez.Parts;
using System.Collections.Generic;
using System.Reflection;

namespace Xadrez.BoardChess
{
    class Board
    {
        /// <summary>Linha da classe Tabuleiro (Board).</summary>
        public int lines { get; set; }
        /// <summary>Coluna da classe Tabuleiro (Board).</summary>
        public int collumns { get; set; }
        /// <summary>Matriz privativa das peças</summary>
        private Piece[,] pieces;
        /// <summary>Lista das imagens para os metodos de exceção do tabuleiro.</summary>
        public List<string> image = new List<string> { " \u2716  " };


        /// <summary>Constructor do Tabuleiro.</summary>
        /// <param name="lines"></param>
        /// <param name="collumns"></param>
        public Board(int lines, int collumns)
        {
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

        /// <summary>Sobrecarga do metodo da peça, square retorna linha e coluna da matriz peças.</summary>
        /// <param name="square"></param>
        /// <returns></returns>
        public Piece Piece(Position square)
        {
            return pieces[square.line, square.collumn];
        }

        /// <summary>Pega a peça do tabuleiro.</summary>
        /// <param name="square"></param>
        /// <returns>peça</returns>
        public Piece TakePiece(Position square)
        {
            if (Piece(square) == null)
            {
                return null;
            }
            Piece piece = Piece(square);
            piece.position = null;
            pieces[square.line, square.collumn] = null;
            return piece;
        }

        /// <summary>coloca a peça no tabuleiro.</summary>
        /// <param name="piece"></param>
        /// <param name="put"></param>
        public void PutPiece(Piece piece, Position put)
        {
            if (ExistPiece(put))
            {
                throw new ExceptionChess($"{image[0]}You can't do that.");
            }
            pieces[put.line, put.collumn] = piece;
            piece.position = put;
        }

        /// <summary>Retorna verdadeiro ou falso caso um dado esteja fora dos limites do Tabuleiro.</summary>
        /// <param name="square"></param>
        /// <returns>verdadeiro ou falso</returns>
        public bool ExceptionBoardLimit(Position square)
        {
            if (square.line < 0 || square.collumn < 0 || square.line >= lines || square.collumn >= collumns)
            {
                return false;
            }
            return true;
        }
        /// <summary>Verifica se a posição é válida.</summary>
        /// <param name="square"></param>
        public void ExceptionValidedLimit(Position square)
        {
            if (!ExceptionBoardLimit(square))
            {
                throw new ExceptionChess($"{image[0]}invalid square.");
            }
        }

        /// <summary>Verifica se tem alguma peça na casa(square).</summary>
        /// <param name="square"></param>
        /// <returns></returns>
        public bool ExistPiece(Position square)
        {
            ExceptionValidedLimit(square);
            return Piece(square) != null;
        }
    }
}
