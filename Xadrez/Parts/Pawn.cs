using System;
using System.Collections.Generic;
using Chess.BoardChess;
using Chess.Pallets;

namespace Chess.Parts
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
                quadrant.QuadrantsToMove(position.line - 1, position.collumn);
                if (board.CheckBoardLimit(quadrant) && FisrMovement(quadrant))
                {
                    characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                }
                //duas casas para cima.
                quadrant.QuadrantsToMove(position.line - 2, position.collumn);
                if (board.CheckBoardLimit(quadrant) && movement.Equals(0))
                {
                    characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                }
                //diagonal de capitura esquerda.
                quadrant.QuadrantsToMove(position.line - 1, position.collumn - 1);
                if (board.CheckBoardLimit(quadrant) && CaptureRadius(quadrant))
                {
                    characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                }
                //diagonal de capitura diireita.
                quadrant.QuadrantsToMove(position.line - 1, position.collumn + 1);
                if (board.CheckBoardLimit(quadrant) && CaptureRadius(quadrant))
                {
                    characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                }
            }
            else
            {
                if (collor.Equals(Collor.BLACK))
                {
                    //baxo.
                    quadrant.QuadrantsToMove(position.line + 1, position.collumn);
                    if (board.CheckBoardLimit(quadrant) && FisrMovement(quadrant))
                    {
                        characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                    }
                    //duas casas para baixo.
                    quadrant.QuadrantsToMove(position.line + 2, position.collumn);
                    if (board.CheckBoardLimit(quadrant) && movement.Equals(0))
                    {
                        characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                    }
                    //diagonal de capitura direita.
                    quadrant.QuadrantsToMove(position.line + 1, position.collumn + 1);
                    if (board.CheckBoardLimit(quadrant) && CaptureRadius(quadrant))
                    {
                        characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                    }
                    //diagonal de capitura esquerda.
                    quadrant.QuadrantsToMove(position.line + 1, position.collumn - 1);
                    if (board.CheckBoardLimit(quadrant) && CaptureRadius(quadrant))
                    {
                        characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                    }
                }
            }
            return characteringMovePawn;
        }
    }
}
