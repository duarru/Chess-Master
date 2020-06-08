using System;
using Chess.BoardChess;
using Chess.Pallets;

namespace Chess.Parts
{
    class Queen : Piece
    {
        public Queen(Board board, Collor collor) : base(board, collor)
        {
        }
        public override string ToString()
        {
            return image[1];
        }
        public override bool[,] CharacteringMove()
        {
            bool[,] moveQueen= new bool[board.lines, board.collumns];
            Position square = new Position(0, 0);
            //diagonal esquerda.
            square.SquareToMove(position.line - 1, position.collumn - 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.SquareToMove(square.line - 1, square.collumn - 1);
            }
            //cima.
            square.SquareToMove(position.line - 1, position.collumn);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.SquareToMove(square.line - 1, square.collumn);
            }
            //diagonal direita.
            square.SquareToMove(position.line - 1, position.collumn + 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.SquareToMove(square.line - 1, square.collumn + 1);
            }
            //direita.
            square.SquareToMove(position.line, position.collumn + 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.SquareToMove(square.line, square.collumn + 1);
            }
            //diagonal direita baixo.
            square.SquareToMove(position.line + 1, position.collumn + 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.SquareToMove(square.line + 1, square.collumn + 1);
            }
            //baixo.
            square.SquareToMove(position.line + 1, position.collumn);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.SquareToMove(square.line + 1, square.collumn);
            }
            //diagonal esquerda baixo.
            square.SquareToMove(position.line + 1, position.collumn - 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.SquareToMove(square.line + 1, square.collumn - 1);
            }
            //esquerda.
            square.SquareToMove(position.line, position.collumn - 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveQueen[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.SquareToMove(square.line - 1, square.collumn - 1);
            }
            return moveQueen;
        }
    }
}
