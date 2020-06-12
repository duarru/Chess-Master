using System;
using Xadrez.BoardChess;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class Queen : Piece
    {
        public Queen(Board board, Collor collor) : base(board, collor)
        {
        }

        /// <summary>
        /// Imagem da rainha.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return image[1];
        }

        /// <summary>
        /// Caracteristica do movimento da rainha.
        /// </summary>
        /// <returns></returns>
        public override bool[,] CharacteringMove()
        {
            bool[,] moveQueen = new bool[board.lines, board.collumns];
            Position square = new Position(0, 0);

            ///<summary>
            ///diagonal esquerda cima.
            /// </summary>
            square.PieceToSquare(position.line - 1, position.collumn - 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.PieceToSquare(square.line - 1, square.collumn - 1);
            }

            ///<summary>
            ///cima.
            /// </summary>
            square.PieceToSquare(position.line - 1, position.collumn);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.PieceToSquare(square.line - 1, square.collumn);
            }

            ///<summary>
            ///diagonal direita.
            ///</summary>
            square.PieceToSquare(position.line - 1, position.collumn + 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.PieceToSquare(square.line - 1, square.collumn + 1);
            }
            
            ///<summary>
            ///direita.
            ///</summary>
            square.PieceToSquare(position.line, position.collumn + 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.PieceToSquare(square.line, square.collumn + 1);
            }
            
            ///<summary>
            ///diagonal direita baixo.
            ///</summary>summary>
            square.PieceToSquare(position.line + 1, position.collumn + 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.PieceToSquare(square.line + 1, square.collumn + 1);
            }
            
            ///<summary>
            ///baixo.
            ///</summary>
            square.PieceToSquare(position.line + 1, position.collumn);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.PieceToSquare(square.line + 1, square.collumn);
            }
            
            ///<summary>
            ///diagonal esquerda baixo.
            ///</summary>>
            square.PieceToSquare(position.line + 1, position.collumn - 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.PieceToSquare(square.line + 1, square.collumn - 1);
            }
            
            ///<summary>
            ///esquerda.
            ///</summary>>
            square.PieceToSquare(position.line, position.collumn - 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.PieceToSquare(square.line, square.collumn - 1);
            }
            return moveQueen;
        }
    }
}
