using Chess.BoardChess;
using Chess.Pallets;

namespace Chess.Parts
{
    class Knight : Piece
    {
        public Knight(BoardChess.Board boardChess, Collor collor) : base(boardChess, collor)
        {
        }
        /// <summary>Unicode para imagem do cavalo, fonte MS Gothic.</summary>
        /// <returns></returns>
        public override string ToString()
        {
            return image[4];
        }
        public override bool[,] CharacteringMove()
        {
            bool[,] characteringMoveKnight = new bool[board.lines, board.collumns];
            Position quadrant = new Position(0, 0);
            //1 para cima 2 lado esquerdo. ok
            quadrant.QuadrantsToMove(position.line - 1, position.collumn - 2);
            if (board.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.line, quadrant.collumn] = true;
            }
            //2 para cima 1 lado esquerdo. ok
            quadrant.QuadrantsToMove(position.line - 2, position.collumn - 1);
            if (board.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.line, quadrant.collumn] = true;
            }
            //2 para cima 1 lado direito. ok
            quadrant.QuadrantsToMove(position.line - 2, position.collumn + 1);
            if (board.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.line, quadrant.collumn] = true;
            }
            //1 para cima 2 lado direito. ok
            quadrant.QuadrantsToMove(position.line - 1, position.collumn + 2);
            if (board.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.line, quadrant.collumn] = true;
            }
            //1 lado direito 2 para cima. ok
            quadrant.QuadrantsToMove(position.line + 1, position.collumn + 2);
            if (board.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.line, quadrant.collumn] = true;
            }
            //2 lado direito 1 para cima. ok
            quadrant.QuadrantsToMove(position.line + 2, position.collumn + 1);
            if (board.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.line, quadrant.collumn] = true;
            }
            //2 lado direito 1 para baixo ok
            quadrant.QuadrantsToMove(position.line + 2, position.collumn -1);
            if (board.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.line, quadrant.collumn] = true;
            }
            //1 para direita 2 para baixo ok 
            quadrant.QuadrantsToMove(position.line + 1, position.collumn - 2);
            if (board.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.line, quadrant.collumn] = true;
            }
            return characteringMoveKnight;
        }
    }
}
