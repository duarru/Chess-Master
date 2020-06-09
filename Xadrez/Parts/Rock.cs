using Xadrez.BoardChess;
using Xadrez.Pallets;
namespace Xadrez.Parts
{
    class Rock : Piece
    {
        /// <summary>Construtor.</summary>
        /// <param name="board"></param>
        /// <param name="collor"></param>
        public Rock(Board board, Collor collor) : base(board, collor)
        {
        }
        /// <summary>Movimento caracteristico da peça torre.</summary>
        /// <returns></returns>
        public override bool[,] CharacteringMove()
        {
            bool[,] characteringMoveRock = new bool[board.lines, board.collumns];
            Position quadrant = new Position(0, 0);
            //cima.
            quadrant.SquareToMove(position.line - 1, position.collumn);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveRock[quadrant.line, quadrant.collumn] = true;
                if(board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.line = quadrant.line - 1;
            }
            //baixo.
            quadrant.SquareToMove(position.line + 1, position.collumn);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveRock[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.line = quadrant.line + 1;
            }
            //direita.
            quadrant.SquareToMove(position.line, position.collumn + 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveRock[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.collumn = quadrant.collumn + 1;
            }
            //esquerda.
            quadrant.SquareToMove(position.line, position.collumn - 1);
            while (board.ExceptionBoardLimit(quadrant) && Move(quadrant))
            {
                characteringMoveRock[quadrant.line, quadrant.collumn] = true;
                if (board.Piece(quadrant) != null && board.Piece(quadrant).collor != collor)
                {
                    break;
                }
                quadrant.collumn = quadrant.collumn - 1;
            }
            return characteringMoveRock;
        }
        /// <summary>Sobreposição retorna a imagem da torre (Rock).</summary>
        /// <returns></returns>
        public override string ToString() {
            return image[2];
        }
    }
}
