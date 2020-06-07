using System;
using System.Collections.Generic;
using Xadrez.Board;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class Pawn : Piece
    {
        public Pawn(BoardChess boardChess, Collor collor) : base(boardChess, collor)
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
                quadrant.QuadrantsToMove(Position.Line - 1, Position.Collumn);
                if (BoardChess.CheckBoardLimit(quadrant) && FisrMovement(quadrant))
                {
                    characteringMovePawn[quadrant.Line, quadrant.Collumn] = true;
                }
                //duas casas para cima.
                quadrant.QuadrantsToMove(Position.Line - 2, Position.Collumn);
                if (BoardChess.CheckBoardLimit(quadrant) && Movement.Equals(0))
                {
                    characteringMovePawn[quadrant.Line, quadrant.Collumn] = true;
                }
                //diagonal de capitura esquerda.
                quadrant.QuadrantsToMove(Position.Line - 1, Position.Collumn - 1);
                if (BoardChess.CheckBoardLimit(quadrant) && CaptureRadius(quadrant))
                {
                    characteringMovePawn[quadrant.Line, quadrant.Collumn] = true;
                }
                //diagonal de capitura diireita.
                quadrant.QuadrantsToMove(Position.Line - 1, Position.Collumn + 1);
                if (BoardChess.CheckBoardLimit(quadrant) && CaptureRadius(quadrant))
                {
                    characteringMovePawn[quadrant.Line, quadrant.Collumn] = true;
                }
            }
            else
            {
                if (Collor.Equals(Collor.BLACK))
                {
                    //baxo.
                    quadrant.QuadrantsToMove(Position.Line + 1, Position.Collumn);
                    if (BoardChess.CheckBoardLimit(quadrant) && FisrMovement(quadrant))
                    {
                        characteringMovePawn[quadrant.Line, quadrant.Collumn] = true;
                    }
                    //duas casas para baixo.
                    quadrant.QuadrantsToMove(Position.Line + 2, Position.Collumn);
                    if (BoardChess.CheckBoardLimit(quadrant) && Movement.Equals(0))
                    {
                        characteringMovePawn[quadrant.Line, quadrant.Collumn] = true;
                    }
                    //diagonal de capitura direita.
                    quadrant.QuadrantsToMove(Position.Line + 1, Position.Collumn + 1);
                    if (BoardChess.CheckBoardLimit(quadrant) && CaptureRadius(quadrant))
                    {
                        characteringMovePawn[quadrant.Line, quadrant.Collumn] = true;
                    }
                    //diagonal de capitura esquerda.
                    quadrant.QuadrantsToMove(Position.Line + 1, Position.Collumn - 1);
                    if (BoardChess.CheckBoardLimit(quadrant) && CaptureRadius(quadrant))
                    {
                        characteringMovePawn[quadrant.Line, quadrant.Collumn] = true;
                    }
                }
            }
            return characteringMovePawn;
        }
    }
}
