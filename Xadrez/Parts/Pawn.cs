using System;
using System.Collections.Generic;
using Chess.BoardChess;
using Chess.Pallets;

namespace Chess.Parts
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
            Position squarePawn = new Position(0, 0);
            if (collor.Equals(Collor.WHITE))
            {
                //cima.
                squarePawn.SquareToMove(position.line - 1, position.collumn);
                if (board.ExceptionBoardLimit(squarePawn) && FisrMovement(squarePawn))
                {
                    movePawn[squarePawn.line, squarePawn.collumn] = true;
                }
                //duas casas para cima.
                squarePawn.SquareToMove(position.line - 2, position.collumn);
                if (board.ExceptionBoardLimit(squarePawn) && movement.Equals(0))
                {
                    movePawn[squarePawn.line, squarePawn.collumn] = true;
                }
                //diagonal de capitura esquerda.
                squarePawn.SquareToMove(position.line - 1, position.collumn - 1);
                if (board.ExceptionBoardLimit(squarePawn) && CaptureRadius(squarePawn))
                {
                    movePawn[squarePawn.line, squarePawn.collumn] = true;
                }
                //diagonal de capitura diireita.
                squarePawn.SquareToMove(position.line - 1, position.collumn + 1);
                if (board.ExceptionBoardLimit(squarePawn) && CaptureRadius(squarePawn))
                {
                    movePawn[squarePawn.line, squarePawn.collumn] = true;
                }
            }
            else
            {
                if (collor.Equals(Collor.BLACK))
                {
                    //baxo.
                    squarePawn.SquareToMove(position.line + 1, position.collumn);
                    if (board.ExceptionBoardLimit(squarePawn) && FisrMovement(squarePawn))
                    {
                        movePawn[squarePawn.line, squarePawn.collumn] = true;
                    }
                    //duas casas para baixo.
                    squarePawn.SquareToMove(position.line + 2, position.collumn);
                    if (board.ExceptionBoardLimit(squarePawn) && movement.Equals(0))
                    {
                        movePawn[squarePawn.line, squarePawn.collumn] = true;
                    }
                    //diagonal de capitura direita.
                    squarePawn.SquareToMove(position.line + 1, position.collumn + 1);
                    if (board.ExceptionBoardLimit(squarePawn) && CaptureRadius(squarePawn))
                    {
                        movePawn[squarePawn.line, squarePawn.collumn] = true;
                    }
                    //diagonal de capitura esquerda.
                    squarePawn.SquareToMove(position.line + 1, position.collumn - 1);
                    if (board.ExceptionBoardLimit(squarePawn) && CaptureRadius(squarePawn))
                    {
                        movePawn[squarePawn.line, squarePawn.collumn] = true;
                    }
                }
            }
            return movePawn;
        }
    }
}
