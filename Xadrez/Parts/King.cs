using Xadrez.Board;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class King : Piece
    {
        public King(Quadrant boardChess, Collor collor):base(boardChess, collor)
        {
        }
        public bool Move(Quadrant quadrant)
        {
            Piece piece = BoardChess.TakePart(quadrant);
            return piece == null || piece.Collor != Collor;
        }
        public override bool[,] CharacteringMove()
        {
            bool[,] boardKing = new bool[BoardChess.Line, BoardChess.Collumn];
            Quadrant quadrant = new Quadrant(0, 0);
            //cima.
            quadrant.QuadrantsToMove(BoardChess.Line - 1, BoardChess.Collumn);
            if (BoardChess.CheckException(quadrant) && Move(quadrant)){
                boardKing[quadrant.Line, quadrant.Collumn] = true;
            }
            //diagonal superior direita.
            quadrant.QuadrantsToMove(BoardChess.Line - 1, BoardChess.Collumn +1);
            if (BoardChess.CheckException(quadrant) && Move(quadrant)){
                boardKing[quadrant.Line, quadrant.Collumn] = true;
            }
            //direita.
            quadrant.QuadrantsToMove(BoardChess.Line, BoardChess.Collumn+1);
            if (BoardChess.CheckException(quadrant) && Move(quadrant)){
                boardKing[quadrant.Line, quadrant.Collumn] = true;
            }
            //diagonal inferior direita.
            quadrant.QuadrantsToMove(BoardChess.Line + 1, BoardChess.Collumn +1);
            if (BoardChess.CheckException(quadrant) && Move(quadrant)){
                boardKing[quadrant.Line, quadrant.Collumn] = true;
            }
            //baixo.
            quadrant.QuadrantsToMove(BoardChess.Line + 1, BoardChess.Collumn);
            if (BoardChess.CheckException(quadrant) && Move(quadrant)){
                boardKing[quadrant.Line, quadrant.Collumn] = true;
            }
            //diagonal inferior esquerda.
            quadrant.QuadrantsToMove(BoardChess.Line + 1, BoardChess.Collumn -1);
            if (BoardChess.CheckException(quadrant) && Move(quadrant)){
                boardKing[quadrant.Line, quadrant.Collumn] = true;
            }
            //esquerda
            quadrant.QuadrantsToMove(BoardChess.Line-1, BoardChess.Collumn-1);
            if (BoardChess.CheckException(quadrant) && Move(quadrant)){
                boardKing[quadrant.Line, quadrant.Collumn] = true;
            }
            //diagonal superior esquerda.
            quadrant.QuadrantsToMove(BoardChess.Line - 1, BoardChess.Collumn-1);
            if (BoardChess.CheckException(quadrant) && Move(quadrant)){
                boardKing[quadrant.Line, quadrant.Collumn] = true;
            }
            return boardKing;
        }

        public override string ToString()
        {
            return " K ";
        }
    }
}
