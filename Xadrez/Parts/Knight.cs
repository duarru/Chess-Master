using Chess.BoardChess;
using Chess.Pallets;

namespace Chess.Parts
{
    class Knight : Piece
    {
        public Knight(Board board, Collor collor) : base(board, collor)
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
            bool[,] moveKnight = new bool[board.lines, board.collumns];
            Position square = new Position(0, 0);
            //1 para cima 2 lado esquerdo. ok
            square.SquareToMove(position.line - 1, position.collumn - 2);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }
            //2 para cima 1 lado esquerdo. ok
            square.SquareToMove(position.line - 2, position.collumn - 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }
            //2 para cima 1 lado direito. ok
            square.SquareToMove(position.line - 2, position.collumn + 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }
            //1 para cima 2 lado direito. ok
            square.SquareToMove(position.line - 1, position.collumn + 2);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }
            //1 lado direito 2 para cima. ok
            square.SquareToMove(position.line + 1, position.collumn + 2);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }
            //2 lado direito 1 para cima. ok
            square.SquareToMove(position.line + 2, position.collumn + 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }
            //2 lado direito 1 para baixo ok
            square.SquareToMove(position.line + 2, position.collumn -1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }
            //1 para direita 2 para baixo ok 
            square.SquareToMove(position.line + 1, position.collumn - 2);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKnight[square.line, square.collumn] = true;
            }
            return moveKnight;
        }
    }
}
