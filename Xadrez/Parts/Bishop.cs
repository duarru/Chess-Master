using Chess.BoardChess;
using Chess.Pallets;
namespace Chess.Parts
{
    class Bishop : Piece
    {
        public Bishop(Board board, Collor collor) : base(board, collor)
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
            bool[,] moveBishop = new bool[board.lines, board.collumns];
            Position square = new Position(0, 0);
            //diagonal esquerda.
            square.SquareToMove(position.line - 1, position.collumn -1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveBishop[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.SquareToMove(square.line - 1, square.collumn - 1);
            }
            //diagonal direita.
            square.SquareToMove(position.line - 1, position.collumn + 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveBishop[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.SquareToMove(square.line - 1, square.collumn + 1);
            }
            //diagonal direita baixo.
            square.SquareToMove(position.line + 1, position.collumn + 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveBishop[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.SquareToMove(square.line + 1, square.collumn + 1);
            }
            //diagonal esquerda baixo.
            square.SquareToMove(position.line + 1, position.collumn - 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveBishop[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.SquareToMove(square.line + 1, square.collumn - 1);
            }
            return moveBishop;
        }
    }
}
