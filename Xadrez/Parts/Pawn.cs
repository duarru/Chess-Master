using System;
using System.Collections.Generic;
using Xadrez.BoardChess;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class Pawn : Piece
    {
        public Pawn(Board board, Collor collor) : base(board, collor)
        {
        }
        /// <summary>Existe inimigo, retorna cor e peça.</summary>
        /// <param name="square"></param>
        /// <returns></returns>
        private bool CaptureRadius(Position square)
        {
            Piece piece = board.Piece(square);
            return piece != null && piece.collor != collor;
        }
        /// <summary>Livre, se for o primeiro movimento.</summary>
        /// <param name="square"></param>
        /// <returns></returns>
        private bool FisrMovement(Position square)
        {
            return board.Piece(square) == null;
        }
        public override string ToString()
        {
            return image[5];
        }
        public override bool[,] CharacteringMove()
        {

            bool[,] movePawn = new bool[board.lines, board.collumns];
            Position square = new Position(0, 0);
            if (collor.Equals(Collor.WHITE))
            {
                //cima.
                square.PieceToSquare(position.line - 1, position.collumn);
                if (board.ExceptionBoardLimit(square) && FisrMovement(square))
                {
                    movePawn[square.line, square.collumn] = true;
                }
                //duas casas para cima.
                square.PieceToSquare(position.line - 2, position.collumn);
                if (board.ExceptionBoardLimit(square) && movement.Equals(0))
                {
                    movePawn[square.line, square.collumn] = true;
                }
                //diagonal de capitura esquerda.
                square.PieceToSquare(position.line - 1, position.collumn - 1);
                if (board.ExceptionBoardLimit(square) && CaptureRadius(square))
                {
                    movePawn[square.line, square.collumn] = true;
                }
                //diagonal de capitura diireita.
                square.PieceToSquare(position.line - 1, position.collumn + 1);
                if (board.ExceptionBoardLimit(square) && CaptureRadius(square))
                {
                    movePawn[square.line, square.collumn] = true;
                }
            }
            else
            {
                if (collor.Equals(Collor.BLACK))
                {
                    //baxo.
                    square.PieceToSquare(position.line + 1, position.collumn);
                    if (board.ExceptionBoardLimit(square) && FisrMovement(square))
                    {
                        movePawn[square.line, square.collumn] = true;
                    }
                    //duas casas para baixo.
                    square.PieceToSquare(position.line + 2, position.collumn);
                    if (board.ExceptionBoardLimit(square) && movement.Equals(0))
                    {
                        movePawn[square.line, square.collumn] = true;
                    }
                    //diagonal de capitura direita.
                    square.PieceToSquare(position.line + 1, position.collumn + 1);
                    if (board.ExceptionBoardLimit(square) && CaptureRadius(square))
                    {
                        movePawn[square.line, square.collumn] = true;
                    }
                    //diagonal de capitura esquerda.
                    square.PieceToSquare(position.line + 1, position.collumn - 1);
                    if (board.ExceptionBoardLimit(square) && CaptureRadius(square))
                    {
                        movePawn[square.line, square.collumn] = true;
                    }
                }
            }
            return movePawn;
        }
    }
}
