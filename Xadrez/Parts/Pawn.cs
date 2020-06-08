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
            Piece piece = BoardChess.Piece(quadrant);
            return piece != null && piece.Collor != Collor;
        }
        /// <summary>Livre, se for o primeiro movimento.</summary>
        /// <param name="quadrant"></param>
        /// <returns></returns>
        private bool FisrMovement(Position quadrant)
        {
            return BoardChess.Piece(quadrant) == null;
        }
        public override string ToString()
        {
            return image[5];
        }
        public override bool[,] CharacteringMove()
        {
            
                bool[,] characteringMovePawn = new bool[BoardChess.Line, BoardChess.Collumn];
                Position quadrant = new Position(0, 0);
            if (Collor.Equals(Collor.WHITE))
            {
                //cima.
                quadrant.QuadrantsToMove(Position.line - 1, Position.collumn);
                if (BoardChess.CheckBoardLimit(quadrant) && FisrMovement(quadrant))
                {
                    characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                }
                //duas casas para cima.
                quadrant.QuadrantsToMove(Position.line - 2, Position.collumn);
                if (BoardChess.CheckBoardLimit(quadrant) && Movement.Equals(0))
                {
                    characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                }
                //diagonal de capitura esquerda.
                quadrant.QuadrantsToMove(Position.line - 1, Position.collumn - 1);
                if (BoardChess.CheckBoardLimit(quadrant) && CaptureRadius(quadrant))
                {
                    characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                }
                //diagonal de capitura diireita.
                quadrant.QuadrantsToMove(Position.line - 1, Position.collumn + 1);
                if (BoardChess.CheckBoardLimit(quadrant) && CaptureRadius(quadrant))
                {
                    characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                }
            }
            else
            {
                if (Collor.Equals(Collor.BLACK))
                {
                    //baxo.
                    quadrant.QuadrantsToMove(Position.line + 1, Position.collumn);
                    if (BoardChess.CheckBoardLimit(quadrant) && FisrMovement(quadrant))
                    {
                        characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                    }
                    //duas casas para baixo.
                    quadrant.QuadrantsToMove(Position.line + 2, Position.collumn);
                    if (BoardChess.CheckBoardLimit(quadrant) && Movement.Equals(0))
                    {
                        characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                    }
                    //diagonal de capitura direita.
                    quadrant.QuadrantsToMove(Position.line + 1, Position.collumn + 1);
                    if (BoardChess.CheckBoardLimit(quadrant) && CaptureRadius(quadrant))
                    {
                        characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                    }
                    //diagonal de capitura esquerda.
                    quadrant.QuadrantsToMove(Position.line + 1, Position.collumn - 1);
                    if (BoardChess.CheckBoardLimit(quadrant) && CaptureRadius(quadrant))
                    {
                        characteringMovePawn[quadrant.line, quadrant.collumn] = true;
                    }
                }
            }
            return characteringMovePawn;
        }
    }
}
