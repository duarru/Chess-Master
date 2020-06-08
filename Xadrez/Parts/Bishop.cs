using Chess.BoardChess;
using Chess.Pallets;
namespace Chess.Parts
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
            bool[,] characteringMoveBishop = new bool[board.lines, board.collumns];
            Position quadrant = new Position(0, 0);
            //diagonal esquerda.
            quadrant.QuadrantsToMove(position.line - 1, position.collumn -1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveBishop[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line - 1, quadrant.collumn - 1);
            }
            //diagonal direita.
            quadrant.QuadrantsToMove(position.line - 1, position.collumn + 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveBishop[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line - 1, quadrant.collumn + 1);
            }
            //diagonal direita baixo.
            quadrant.QuadrantsToMove(position.line + 1, position.collumn + 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveBishop[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line + 1, quadrant.collumn + 1);
            }
            //diagonal esquerda baixo.
            quadrant.QuadrantsToMove(position.line + 1, position.collumn - 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveBishop[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.QuadrantsToMove(quadrant.line + 1, quadrant.collumn - 1);
            }
            return characteringMoveBishop;
        }
    }
}
