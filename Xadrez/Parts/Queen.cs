using System;
using Chess.BoardChess;
using Chess.Pallets;

namespace Chess.Parts
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
            bool[,] characteringMoveQueen= new bool[board.lines, board.collumns];
            Position quadrant = new Position(0, 0);
            //diagonal esquerda.
            quadrant.QuadrantsToMove(position.line - 1, position.collumn - 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line - 1, quadrant.collumn - 1);
            }
            //cima.
            quadrant.QuadrantsToMove(position.line - 1, position.collumn);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line - 1, quadrant.collumn);
            }
            //diagonal direita.
            quadrant.QuadrantsToMove(position.line - 1, position.collumn + 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line - 1, quadrant.collumn + 1);
            }
            //direita.
            quadrant.QuadrantsToMove(position.line, position.collumn + 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line, quadrant.collumn + 1);
            }
            //diagonal direita baixo.
            quadrant.QuadrantsToMove(position.line + 1, position.collumn + 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line + 1, quadrant.collumn + 1);
            }
            //baixo.
            quadrant.QuadrantsToMove(position.line + 1, position.collumn);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line + 1, quadrant.collumn);
            }
            //diagonal esquerda baixo.
            quadrant.QuadrantsToMove(position.line + 1, position.collumn - 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line + 1, quadrant.collumn - 1);
            }
            return characteringMoveQueen;
        }
    }
}
