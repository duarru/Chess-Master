﻿using Xadrez.BoardChess;
using Xadrez.Pallets;
namespace Xadrez.Parts
{
    class Rock : Piece
    {
        /// <summary>Construtor.</summary>
        /// <param name="boardChess"></param>
        /// <param name="collor"></param>
        public Rock(BoardChess.Board boardChess, Collor collor) : base(boardChess, collor)
        {
        }
        /// <summary>Movimento caracteristico da peça torre.</summary>
        /// <returns></returns>
        public override bool[,] CharacteringMove()
        {
            bool[,] characteringMoveRock = new bool[BoardChess.Line, BoardChess.Collumn];
            Position quadrant = new Position(0, 0);
            //cima.
            quadrant.QuadrantsToMove(Position.line - 1, Position.collumn);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveRock[quadrant.line, quadrant.collumn] = true;
                if(BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.line = quadrant.line - 1;
            }
            //baixo.
            quadrant.QuadrantsToMove(Position.line + 1, Position.collumn);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveRock[quadrant.line, quadrant.collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.line = quadrant.line + 1;
            }
            //direita.
            quadrant.QuadrantsToMove(Position.line, Position.collumn + 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveRock[quadrant.line, quadrant.collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.collumn = quadrant.collumn + 1;
            }
            //esquerda.
            quadrant.QuadrantsToMove(Position.line, Position.collumn - 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveRock[quadrant.line, quadrant.collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.collumn = quadrant.collumn - 1;
            }
            return characteringMoveRock;
        }
        /// <summary>retorna a imagem unicode da torre, fonte MS Gothic.</summary>
        /// <returns></returns>
        public override string ToString() {
            return image[2];
        }
    }
}
