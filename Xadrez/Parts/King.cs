﻿using Chess.BoardChess;
using Chess.Pallets;
namespace Chess.Parts
{
    class King : Piece
    {
        /// <summary>Construtor da classe Rei (King).</summary>
        /// <param name="board"></param>
        /// <param name="collor"></param>
        public King(Board board, Collor collor) : base(board, collor)
        {
        }
        /// <summary>Metodo sobrescrito abstrato, caracteristica especifica do movimento do rei.</summary>
        /// <returns></returns>
        public override bool[,] CharacteringMove()
        {
            bool[,] moveKing = new bool[board.lines, board.collumns];
            Position square = new Position(0, 0);
            //cima.
            square.SquareToMove(position.line - 1, position.collumn);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            //diagonal superior direita.
            square.SquareToMove(position.line - 1, position.collumn + 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            //direita.
            square.SquareToMove(position.line, position.collumn + 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            //diagonal inferior direita.
            square.SquareToMove(position.line + 1, position.collumn + 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            //baixo.
            square.SquareToMove(position.line + 1, position.collumn);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            //diagonal inferior esquerda.
            square.SquareToMove(position.line + 1, position.collumn - 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            //esquerda
            square.SquareToMove(position.line, position.collumn - 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            //diagonal superior esquerda.
            square.SquareToMove(position.line - 1, position.collumn - 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            return moveKing;
        }

        /// <summary>Sobreposição retorna a imagem do rei (King).</summary>
        /// <returns></returns>
        public override string ToString()
        {
            return image[0];
        }
    }
}
