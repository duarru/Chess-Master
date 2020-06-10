using Xadrez.BoardChess;
using Xadrez.Pallets;
namespace Xadrez.Parts
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
            bool[,] MoveBishop = new bool[board.lines, board.collumns];
            Position square = new Position(0, 0);
            //diagonal esquerda.
            square.PieceToSquare(position.line - 1, position.collumn -1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                MoveBishop[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.PieceToSquare(square.line - 1, square.collumn - 1);
            }
            //diagonal direita.
            square.PieceToSquare(position.line - 1, position.collumn + 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                MoveBishop[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.PieceToSquare(square.line - 1, square.collumn + 1);
            }
            //diagonal direita baixo.
            square.PieceToSquare(position.line + 1, position.collumn + 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                MoveBishop[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.PieceToSquare(square.line + 1, square.collumn + 1);
            }
            //diagonal esquerda baixo.
            square.PieceToSquare(position.line + 1, position.collumn - 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                MoveBishop[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.PieceToSquare(square.line + 1, square.collumn - 1);
            }
            return MoveBishop;
        }
    }
}
