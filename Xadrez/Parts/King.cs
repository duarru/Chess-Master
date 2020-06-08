using Chess.BoardChess;
using Chess.Pallets;
namespace Chess.Parts
{
    class King : Piece
    {
        /// <summary>Construtor da classe Rei (King).</summary>
        /// <param name="board"></param>
        /// <param name="collor"></param>
        public King(Board board, Collor collor) : base(board, collor)
        {
        }
        /// <summary>Metodo sobrescrito abstrato, caracteristica especifica do movimento do rei.</summary>
        /// <returns></returns>
        public override bool[,] CharacteringMove()
        {
            bool[,] characteringMoveKing = new bool[board.lines, board.collumns];
            Position quadrant = new Position(0, 0);
            //cima.
            quadrant.QuadrantsToMove(position.line - 1, position.collumn);
            if (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            //diagonal superior direita.
            quadrant.QuadrantsToMove(position.line - 1, position.collumn + 1);
            if (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            //direita.
            quadrant.QuadrantsToMove(position.line, position.collumn + 1);
            if (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            //diagonal inferior direita.
            quadrant.QuadrantsToMove(position.line + 1, position.collumn + 1);
            if (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            //baixo.
            quadrant.QuadrantsToMove(position.line + 1, position.collumn);
            if (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            //diagonal inferior esquerda.
            quadrant.QuadrantsToMove(position.line + 1, position.collumn - 1);
            if (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            //esquerda
            quadrant.QuadrantsToMove(position.line, position.collumn - 1);
            if (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            //diagonal superior esquerda.
            quadrant.QuadrantsToMove(position.line - 1, position.collumn - 1);
            if (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveKing[quadrant.line, quadrant.collumn] = true;
            }
            return characteringMoveKing;
        }

        /// <summary>Sobreposição retorna a imagem do rei (King).</summary>
        /// <returns></returns>
        public override string ToString()
        {
            return image[0];
        }
    }
}
