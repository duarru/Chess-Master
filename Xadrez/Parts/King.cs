using Xadrez.Board;
using Xadrez.Pallets;
namespace Xadrez.Parts
{
    /// <summary>O Rei.</summary>
    class King : Piece
    {
        /// <summary>Construtor.</summary>
        /// <param name="boardChess"></param>
        /// <param name="collor"></param>
        public King(BoardChess boardChess, Collor collor) : base(boardChess, collor)
        {
        }
        /// <summary>Metodo sobrescrito abstrato, caracteristica especifica do movimento do rei.</summary>
        /// <returns></returns>
        public override bool[,] CharacteringMove()
        {
            bool[,] characteringMoveKing = new bool[BoardChess.Line, BoardChess.Collumn];
            Position quadrant = new Position(0, 0);
            //cima.
            quadrant.QuadrantsToMove(Position.Line - 1, Position.Collumn);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.Line, quadrant.Collumn] = true;
            }
            //diagonal superior direita.
            quadrant.QuadrantsToMove(Position.Line - 1, Position.Collumn + 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.Line, quadrant.Collumn] = true;
            }
            //direita.
            quadrant.QuadrantsToMove(Position.Line, Position.Collumn + 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.Line, quadrant.Collumn] = true;
            }
            //diagonal inferior direita.
            quadrant.QuadrantsToMove(Position.Line + 1, Position.Collumn + 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.Line, quadrant.Collumn] = true;
            }
            //baixo.
            quadrant.QuadrantsToMove(Position.Line + 1, Position.Collumn);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.Line, quadrant.Collumn] = true;
            }
            //diagonal inferior esquerda.
            quadrant.QuadrantsToMove(Position.Line + 1, Position.Collumn - 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.Line, quadrant.Collumn] = true;
            }
            //esquerda
            quadrant.QuadrantsToMove(Position.Line, Position.Collumn - 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.Line, quadrant.Collumn] = true;
            }
            //diagonal superior esquerda.
            quadrant.QuadrantsToMove(Position.Line - 1, Position.Collumn - 1);
            if (BoardChess.CheckBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.Line, quadrant.Collumn] = true;
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
