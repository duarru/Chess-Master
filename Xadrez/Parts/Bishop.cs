using Xadrez.BoardChess;
using Xadrez.Pallets;
namespace Xadrez.Parts
{
    class Bishop : Piece
    {
        public Bishop(BoardChess.Board boardChess, Collor collor) : base(boardChess, collor)
        {
        }
        /// <summary>Unicode para imagem do bispo, fonte MS Gothic.</summary>
        /// <returns></returns>
        public override string ToString()
        {
            return image[3];
        }
        /// <summary>Movimentos possiveis, caracteristicos da peça.</summary>
        /// <returns></returns>
        public override bool[,] CharacteringMove()
        {
            bool[,] characteringMoveBishop = new bool[BoardChess.Line, BoardChess.Collumn];
            Position quadrant = new Position(0, 0);
            //diagonal esquerda.
            quadrant.QuadrantsToMove(Position.line - 1, Position.collumn -1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveBishop[quadrant.line, quadrant.collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line - 1, quadrant.collumn - 1);
            }
            //diagonal direita.
            quadrant.QuadrantsToMove(Position.line - 1, Position.collumn + 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveBishop[quadrant.line, quadrant.collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line - 1, quadrant.collumn + 1);
            }
            //diagonal direita baixo.
            quadrant.QuadrantsToMove(Position.line + 1, Position.collumn + 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveBishop[quadrant.line, quadrant.collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line + 1, quadrant.collumn + 1);
            }
            //diagonal esquerda baixo.
            quadrant.QuadrantsToMove(Position.line + 1, Position.collumn - 1);
            while (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveBishop[quadrant.line, quadrant.collumn] = true;
                if (BoardChess.Piece(quadrant) != null && BoardChess.Piece(quadrant).Collor != Collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line + 1, quadrant.collumn - 1);
            }
            return characteringMoveBishop;
        }
    }
}
