using System;
using Xadrez.Board;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class Queen : Piece
    {
        public Queen(BoardChess boardChess, Collor collor) : base(boardChess, collor)
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
            quadrant.QuadrantsToMove(Position.Line - 1, Position.Collumn - 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.Line, quadrant.Collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.Line - 1, quadrant.Collumn - 1);
            }
            //cima.
            quadrant.QuadrantsToMove(Position.Line - 1, Position.Collumn);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.Line, quadrant.Collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.Line - 1, quadrant.Collumn);
            }
            //diagonal direita.
            quadrant.QuadrantsToMove(Position.Line - 1, Position.Collumn + 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.Line, quadrant.Collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.Line - 1, quadrant.Collumn + 1);
            }
            //direita.
            quadrant.QuadrantsToMove(Position.Line, Position.Collumn + 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.Line, quadrant.Collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.Line, quadrant.Collumn + 1);
            }
            //diagonal direita baixo.
            quadrant.QuadrantsToMove(Position.Line + 1, Position.Collumn + 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.Line, quadrant.Collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.Line + 1, quadrant.Collumn + 1);
            }
            //baixo.
            quadrant.QuadrantsToMove(Position.Line + 1, Position.Collumn);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.Line, quadrant.Collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.Line + 1, quadrant.Collumn);
            }
            //diagonal esquerda baixo.
            quadrant.QuadrantsToMove(Position.Line + 1, Position.Collumn - 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.Line, quadrant.Collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.Line + 1, quadrant.Collumn - 1);
            }
            return characteringMoveQueen;
        }
    }
}
