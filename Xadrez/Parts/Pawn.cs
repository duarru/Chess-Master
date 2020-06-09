using System;
using System.Collections.Generic;
using Xadrez.BoardChess;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class Pawn : Piece
    {
        public Pawn(BoardChess.Board boardChess, Collor collor) : base(boardChess, collor)
        {
        }
        /// <summary>Existe inimigo, retorna cor e peça.</summary>
        /// <param name="quadrant"></param>
        /// <returns></returns>
        private bool CaptureRadius(Position quadrant)
        {
            Piece piece = board.Piece(quadrant);
            return piece != null && piece.collor != collor;
        }
        /// <summary>Livre, se for o primeiro movimento.</summary>
        /// <param name="quadrant"></param>
        /// <returns></returns>
        private bool FisrMovement(Position quadrant)
        {
            return board.Piece(quadrant) == null;
        }
        public override string ToString()
        {
            return image[5];
        }
        public override bool[,] CharacteringMove()
        {
            
                bool[,] characteringMovePawn = new bool[board.lines, board.collumns];
                Position quadrant = new Position(0, 0);
            if (collor.Equals(Collor.WHITE))
            {
                //cima.
                quadrant.SquareToMove(position.line - 1, position.collumn);
                if (board.ExceptionBoardLimit(quadrant) && FisrMovement(quadrant))
                {
                    characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                }
                //duas casas para cima.
                quadrant.SquareToMove(position.line - 2, position.collumn);
                if (board.ExceptionBoardLimit(quadrant) && movement.Equals(0))
                {
                    characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                }
                //diagonal de capitura esquerda.
                quadrant.SquareToMove(position.line - 1, position.collumn - 1);
                if (board.ExceptionBoardLimit(quadrant) && CaptureRadius(quadrant))
                {
                    characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                }
                //diagonal de capitura diireita.
                quadrant.SquareToMove(position.line - 1, position.collumn + 1);
                if (board.ExceptionBoardLimit(quadrant) && CaptureRadius(quadrant))
                {
                    characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                }
            }
            else
            {
                if (collor.Equals(Collor.BLACK))
                {
                    //baxo.
                    quadrant.SquareToMove(position.line + 1, position.collumn);
                    if (board.ExceptionBoardLimit(quadrant) && FisrMovement(quadrant))
                    {
                        characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                    }
                    //duas casas para baixo.
                    quadrant.SquareToMove(position.line + 2, position.collumn);
                    if (board.ExceptionBoardLimit(quadrant) && movement.Equals(0))
                    {
                        characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                    }
                    //diagonal de capitura direita.
                    quadrant.SquareToMove(position.line + 1, position.collumn + 1);
                    if (board.ExceptionBoardLimit(quadrant) && CaptureRadius(quadrant))
                    {
                        characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                    }
                    //diagonal de capitura esquerda.
                    quadrant.SquareToMove(position.line + 1, position.collumn - 1);
                    if (board.ExceptionBoardLimit(quadrant) && CaptureRadius(quadrant))
                    {
                        characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                    }
                }
            }
            return characteringMovePawn;
        }
    }
}
