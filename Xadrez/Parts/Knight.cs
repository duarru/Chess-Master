﻿using Xadrez.BoardChess;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class Knight : Piece
    {
        public Knight(Board board, Collor collor) : base(board, collor)
        {
        }
        /// <summary>
        /// Unicode para imagem do cavalo, fonte MS Gothic.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return image[4];
        }

        /// <summary>
        /// Caracteristica do movimento do cacalo.
        /// </summary>
        /// <returns></returns>
        public override bool[,] CharacteringMove()
        {
            bool[,] moveKnight = new bool[board.lines, board.collumns];
            Position square = new Position(0, 0);
           
            ///<summary>
            ///1 para cima 2 lado esquerdo/ 2 lado esquerdo 1 para cima.
            ///</summary>
            square.PieceToSquare(position.line - 1, position.collumn - 2);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }
            
            ///<summary>
            ///2 para cima 1 lado esquerdo / 1 lado esquerdo 2 para cima.
            ///</summary>
            square.PieceToSquare(position.line - 2, position.collumn - 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }
            
            ///<summary>
            ///2 para cima 1 lado direito / 1 lado esquerdo 2 para cima.
            ///</summary>
            square.PieceToSquare(position.line - 2, position.collumn + 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }

            ///<summary>
            ///1 para cima 2 lado direito/ 2 lado direito 1 para cima.
            ///</summary>>
            square.PieceToSquare(position.line - 1, position.collumn + 2);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }

            ///<summary>
            ///1 para baixo 2 lado direita / 2 lado direito 1 para baixo.
            ///</summary>
            square.PieceToSquare(position.line + 1, position.collumn + 2);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }

            ///<summary>
            ///2 para baixo 1 lado direito // 1 lado direito 2 para baixo.
            ///</summary>
            square.PieceToSquare(position.line + 2, position.collumn + 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }

            ///<summary>
            ///2 para baixo 1 para esquerda / 1 lado esquerdo 2 lado esquerdo.
            ///</summary>
            square.PieceToSquare(position.line + 2, position.collumn -1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }
            
            ///<summary>
            ///1 para baixo 2 para esquerda baixo / 2 para esquerda baixo 1 para baixo.
            ///</summary>
            square.PieceToSquare(position.line + 1, position.collumn - 2);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }
            return moveKnight;
        }
    }
}
