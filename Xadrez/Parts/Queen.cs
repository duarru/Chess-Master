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
            bool[,] characteringMoveQueen= new bool[board.lines, board.collumns];
            Position quadrant = new Position(0, 0);
            //diagonal esquerda.
            quadrant.SquareToMove(position.line - 1, position.collumn - 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.SquareToMove(quadrant.line - 1, quadrant.collumn - 1);
            }
            //cima.
            quadrant.SquareToMove(position.line - 1, position.collumn);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.SquareToMove(quadrant.line - 1, quadrant.collumn);
            }
            //diagonal direita.
            quadrant.SquareToMove(position.line - 1, position.collumn + 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.SquareToMove(quadrant.line - 1, quadrant.collumn + 1);
            }
            //direita.
            quadrant.SquareToMove(position.line, position.collumn + 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.SquareToMove(quadrant.line, quadrant.collumn + 1);
            }
            //diagonal direita baixo.
            quadrant.SquareToMove(position.line + 1, position.collumn + 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.SquareToMove(quadrant.line + 1, quadrant.collumn + 1);
            }
            //baixo.
            quadrant.SquareToMove(position.line + 1, position.collumn);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.SquareToMove(quadrant.line + 1, quadrant.collumn);
            }
            //diagonal esquerda baixo.
            quadrant.SquareToMove(position.line + 1, position.collumn - 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveQueen[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.SquareToMove(quadrant.line + 1, quadrant.collumn - 1);
            }
            return characteringMoveQueen;
        }
    }
}
