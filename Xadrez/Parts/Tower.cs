using System.Drawing;
using Xadrez.Board;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class Tower : Piece
    {
        public Tower(Quadrant boardChess, Collor collor) : base(boardChess, collor)
        {
        }

        public bool Move(Quadrant quadrant)
        {
            Piece piece = BoardChess.TakePart(quadrant);
            return piece == null || piece.Collor != Collor;
        }
        public override bool[,] CharacteringMove()
        {
            bool[,] boardTower = new bool[BoardChess.Line, BoardChess.Collumn];
            Quadrant quadrant = new Quadrant(0, 0);
            //cima.
            quadrant.QuadrantsToMove(BoardChess.Line - 1, BoardChess.Collumn);
            while (BoardChess.CheckException(quadrant) && Move(quadrant))
            {
                boardTower[quadrant.Line, quadrant.Collumn] = true;
                if(BoardChess.PieceOnTheBoard(quadrant) != null && BoardChess.PieceOnTheBoard(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.Line = quadrant.Line - 1;
            }
            //baixo.
            quadrant.QuadrantsToMove(BoardChess.Line + 1, BoardChess.Collumn);
            while (BoardChess.CheckException(quadrant) && Move(quadrant))
            {
                boardTower[quadrant.Line, quadrant.Collumn] = true;
                if (BoardChess.PieceOnTheBoard(quadrant) != null && BoardChess.PieceOnTheBoard(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.Line = quadrant.Line + 1;
            }
            //direita.
            quadrant.QuadrantsToMove(BoardChess.Line, BoardChess.Collumn + 1);
            while (BoardChess.CheckException(quadrant) && Move(quadrant))
            {
                boardTower[quadrant.Line, quadrant.Collumn] = true;
                if (BoardChess.PieceOnTheBoard(quadrant) != null && BoardChess.PieceOnTheBoard(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.Collumn = quadrant.Collumn + 1;
            }
            //esquerda.
            quadrant.QuadrantsToMove(BoardChess.Line, BoardChess.Collumn - 1);
            while (BoardChess.CheckException(quadrant) && Move(quadrant))
            {
                boardTower[quadrant.Line, quadrant.Collumn] = true;
                if (BoardChess.PieceOnTheBoard(quadrant) != null && BoardChess.PieceOnTheBoard(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.Collumn = quadrant.Collumn - 1;
            }
            return boardTower;
        }

        public override string ToString()
        {
            return " T ";
        }
    }
}
