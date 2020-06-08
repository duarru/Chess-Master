using System;
using Xadrez.BoardChess;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class Queen : Piece
    {
        public Queen(BoardChess.Board boardChess, Collor collor) : base(boardChess, collor)
        {
        }
        public override string ToString()
        {
            return image[1];
        }
        public override bool[,] CharacteringMove()
        {
            bool[,] characteringMoveQueen= new bool[BoardChess.Line, BoardChess.Collumn];
            Position quadrant = new Position(0, 0);
            //diagonal esquerda.
            quadrant.QuadrantsToMove(Position.line - 1, Position.collumn - 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line - 1, quadrant.collumn - 1);
            }
            //cima.
            quadrant.QuadrantsToMove(Position.line - 1, Position.collumn);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line - 1, quadrant.collumn);
            }
            //diagonal direita.
            quadrant.QuadrantsToMove(Position.line - 1, Position.collumn + 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line - 1, quadrant.collumn + 1);
            }
            //direita.
            quadrant.QuadrantsToMove(Position.line, Position.collumn + 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line, quadrant.collumn + 1);
            }
            //diagonal direita baixo.
            quadrant.QuadrantsToMove(Position.line + 1, Position.collumn + 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line + 1, quadrant.collumn + 1);
            }
            //baixo.
            quadrant.QuadrantsToMove(Position.line + 1, Position.collumn);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line + 1, quadrant.collumn);
            }
            //diagonal esquerda baixo.
            quadrant.QuadrantsToMove(Position.line + 1, Position.collumn - 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line + 1, quadrant.collumn - 1);
            }
            return characteringMoveQueen;
        }
    }
}
