﻿using Xadrez.BoardChess;
using Xadrez.Pallets;
namespace Xadrez.Parts
{
    /// <summary>O Rei.</summary>
    class King : Piece
    {
        /// <summary>Construtor.</summary>
        /// <param name="boardChess"></param>
        /// <param name="collor"></param>
        public King(BoardChess.Board boardChess, Collor collor) : base(boardChess, collor)
        {
        }
        /// <summary>Metodo sobrescrito abstrato, caracteristica especifica do movimento do rei.</summary>
        /// <returns></returns>
        public override bool[,] CharacteringMove()
        {
            bool[,] characteringMoveKing = new bool[BoardChess.Line, BoardChess.Collumn];
            Position quadrant = new Position(0, 0);
            //cima.
            quadrant.QuadrantsToMove(Position.line - 1, Position.collumn);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            //diagonal superior direita.
            quadrant.QuadrantsToMove(Position.line - 1, Position.collumn + 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            //direita.
            quadrant.QuadrantsToMove(Position.line, Position.collumn + 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            //diagonal inferior direita.
            quadrant.QuadrantsToMove(Position.line + 1, Position.collumn + 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            //baixo.
            quadrant.QuadrantsToMove(Position.line + 1, Position.collumn);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            //diagonal inferior esquerda.
            quadrant.QuadrantsToMove(Position.line + 1, Position.collumn - 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            //esquerda
            quadrant.QuadrantsToMove(Position.line, Position.collumn - 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            //diagonal superior esquerda.
            quadrant.QuadrantsToMove(Position.line - 1, Position.collumn - 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            return characteringMoveKing;
        }

        /// <summary>Unicode para imagem do rei, fonte MS Gothic.</summary>
        /// <returns></returns>
        public override string ToString()
        {
            return image[0];
        }
    }
}
