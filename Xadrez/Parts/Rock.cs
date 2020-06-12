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
        
        /// <summary>
        /// Movimento caracteristico da peça torre.
        /// </summary>
        /// <returns></returns>
        public override bool[,] CharacteringMove()
        {
            bool[,] moveRock = new bool[board.lines, board.collumns];
            Position square = new Position(0, 0);
            
            ///<summary>
            ///cima.
            ///</summary>>
            square.PieceToSquare(position.line - 1, position.collumn);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveRock[square.line, square.collumn] = true;
                if(board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.line = square.line - 1;
            }
            
            ///<summary>
            ///baixo.
            ///</summary>
            square.PieceToSquare(position.line + 1, position.collumn);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveRock[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.line = square.line + 1;
            }
            
            ///<summary>
            ///direita.
            ///</summary>
            square.PieceToSquare(position.line, position.collumn + 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveRock[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.collumn = square.collumn + 1;
            }
            
            ///<summary>
            ///esquerda.
            ///</summary>
            square.PieceToSquare(position.line, position.collumn - 1);
            while (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveRock[square.line, square.collumn] = true;
                if (board.Piece(square) != null && board.Piece(square).collor != collor)
                {
                    break;
                }
                square.collumn = square.collumn - 1;
            }
            return moveRock;
        }
        /// <summary>
        /// Sobreposição retorna a imagem da torre (Rock).
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return image[2];
        }
    }
}
