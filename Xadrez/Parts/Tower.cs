using System.Drawing;
using Xadrez.Board;
using Xadrez.Pallets;
using System;

namespace Xadrez.Parts
{
    class Tower : Piece
    {
        /// <summary>Construtor.</summary>
        /// <param name="boardChess"></param>
        /// <param name="collor"></param>
        public Tower(BoardChess boardChess, Collor collor) : base(boardChess, collor)
        {
        }
        /// <summary>Movimento caracteristico da peça torre.</summary>
        /// <returns></returns>
        public override bool[,] CharacteringMove()
        {
            bool[,] characteringMoveTower = new bool[BoardChess.Line, BoardChess.Collumn];
            Position quadrant = new Position(0, 0);
            //cima.
            quadrant.QuadrantsToMove(Position.Line - 1, Position.Collumn);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveTower[quadrant.Line, quadrant.Collumn] = true;
                if(BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.Line = quadrant.Line - 1;
            }
            //baixo.
            quadrant.QuadrantsToMove(Position.Line + 1, Position.Collumn);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveTower[quadrant.Line, quadrant.Collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.Line = quadrant.Line + 1;
            }
            //direita.
            quadrant.QuadrantsToMove(Position.Line, Position.Collumn + 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveTower[quadrant.Line, quadrant.Collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.Collumn = quadrant.Collumn + 1;
            }
            //esquerda.
            quadrant.QuadrantsToMove(Position.Line, Position.Collumn - 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveTower[quadrant.Line, quadrant.Collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.Collumn = quadrant.Collumn - 1;
            }
            return characteringMoveTower;
        }
        /// <summary>retorna a imagem unicode da torre, fonte MS Gothic.</summary>
        /// <returns></returns>
        public override string ToString() {
            return image[2];
        }
    }
}
