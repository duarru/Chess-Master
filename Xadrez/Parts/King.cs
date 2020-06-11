using Xadrez.BoardChess;
using Xadrez.Manager;
using Xadrez.Pallets;
namespace Xadrez.Parts
{
    class King : Piece
    {
        private GameManager situation;
        /// <summary>Construtor da classe Rei (King).</summary>
        /// <param name="board"></param>
        /// <param name="collor"></param>
        public King(Board board, Collor collor, GameManager situation) : base(board, collor)
        {
            this.situation = situation;
        }
        private bool RockForSquareKing(Position square)
        {
            Piece rock = board.Piece(square);
            return rock != null && rock is Rock && rock.collor == collor && rock.movement == 0;
        }
        /// <summary>Metodo sobrescrito abstrato, caracteristica especifica do movimento do rei.</summary>
        /// <returns></returns>
        public override bool[,] CharacteringMove()
        {
            bool[,] moveKing = new bool[board.lines, board.collumns];
            Position square = new Position(0, 0);
            //cima.
            square.PieceToSquare(position.line - 1, position.collumn);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            //diagonal superior direita.
            square.PieceToSquare(position.line - 1, position.collumn + 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            //direita.
            square.PieceToSquare(position.line, position.collumn + 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            //diagonal inferior direita.
            square.PieceToSquare(position.line + 1, position.collumn + 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            //baixo.
            square.PieceToSquare(position.line + 1, position.collumn);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            //diagonal inferior esquerda.
            square.PieceToSquare(position.line + 1, position.collumn - 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            //esquerda
            square.PieceToSquare(position.line, position.collumn - 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }
            //diagonal superior esquerda.
            square.PieceToSquare(position.line - 1, position.collumn - 1);
            if (board.ExceptionBoardLimit(square) && Move(square))
            {
                moveKing[square.line, square.collumn] = true;
            }

            ///<summary>
            ///Movimento especial do Rei.
            /// </summary>>
            if (movement == 0 && situation.check == false)
            {
                ///<summary>
                /// Torre menor.
                /// </summary>>
                Position smallCastle = new Position(position.line, position.collumn + 3);
                if (RockForSquareKing(smallCastle))
                {
                    Position A = new Position(position.line, position.collumn + 1);
                    Position B = new Position(position.line, position.collumn + 2);
                    if (board.Piece(A) == null && board.Piece(B) == null)
                    {
                        moveKing[position.line, position.collumn + 2] = true;
                    }
                }
                ///<summary>
                ///Torre maior.
                /// </summary>
                Position graaterCastle = new Position(this.position.line, this.position.collumn - 4);
                if (RockForSquareKing(graaterCastle))
                {
                    Position A = new Position(position.line, position.collumn - 1);
                    Position B = new Position(position.line, position.collumn - 2);
                    Position C = new Position(position.line, position.collumn - 3);
                    if (board.Piece(A) == null && board.Piece(B) == null && board.Piece(C) == null)
                    {
                        moveKing[position.line, position.collumn - 2] = true;
                    }
                }
            }

            return moveKing;
        }

        /// <summary>Sobreposição retorna a imagem do rei (King).</summary>
        /// <returns></returns>
        public override string ToString()
        {
            return image[0];
        }
    }
}
