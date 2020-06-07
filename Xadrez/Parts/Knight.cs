using Xadrez.Board;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class Knight : Piece
    {
        public Knight(BoardChess boardChess, Collor collor) : base(boardChess, collor)
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
            bool[,] characteringMoveKnight = new bool[BoardChess.Line, BoardChess.Collumn];
            Position quadrant = new Position(0, 0);
            //1 para cima 2 lado esquerdo. ok
            quadrant.QuadrantsToMove(Position.Line - 1, Position.Collumn - 2);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.Line, quadrant.Collumn] = true;
            }
            //2 para cima 1 lado esquerdo. ok
            quadrant.QuadrantsToMove(Position.Line - 2, Position.Collumn - 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.Line, quadrant.Collumn] = true;
            }
            //2 para cima 1 lado direito. ok
            quadrant.QuadrantsToMove(Position.Line - 2, Position.Collumn + 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.Line, quadrant.Collumn] = true;
            }
            //1 para cima 2 lado direito. ok
            quadrant.QuadrantsToMove(Position.Line - 1, Position.Collumn + 2);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.Line, quadrant.Collumn] = true;
            }
            //1 lado direito 2 para cima. ok
            quadrant.QuadrantsToMove(Position.Line + 1, Position.Collumn + 2);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.Line, quadrant.Collumn] = true;
            }
            //2 lado direito 1 para cima. ok
            quadrant.QuadrantsToMove(Position.Line + 2, Position.Collumn + 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.Line, quadrant.Collumn] = true;
            }
            //2 lado direito 1 para baixo ok
            quadrant.QuadrantsToMove(Position.Line + 2, Position.Collumn -1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.Line, quadrant.Collumn] = true;
            }
            //1 para direita 2 para baixo ok 
            quadrant.QuadrantsToMove(Position.Line + 1, Position.Collumn - 2);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKnight[quadrant.Line, quadrant.Collumn] = true;
            }
            return characteringMoveKnight;
        }
    }
}
