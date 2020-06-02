using Xadrez.Board;
using Xadrez.Pallets;
using Xadrez.Parts;

namespace Xadrez.Manager
{
    class GameManager
    {
        public BoardChess Chess{ get; private set; }
        private int Turn;
        private Collor CurrentPlayer;
        public bool Winner { get; private set; }

        public GameManager()
        {
            Chess = new BoardChess(8, 8);
            Turn = 1;
            CurrentPlayer = Collor.WHITE;
            InitChessPosition();
            Winner = false;
        }

        public void Move(Position take, Position put)
        {
            Piece piece = Chess.TakePart(take);
            piece.Move();
            Piece capture = Chess.TakePart(put);
            Chess.PutPiece(piece, put);
        }

        private void InitChessPosition()
        {
            Chess.PutPiece(new Tower(Chess, Collor.WHITE), new PositionChess('a', 1).ToPosition());
            Chess.PutPiece(new Tower(Chess, Collor.WHITE), new PositionChess('h', 1).ToPosition());
            Chess.PutPiece(new King(Chess, Collor.WHITE), new PositionChess('e', 1).ToPosition());
            Chess.PutPiece(new Tower(Chess, Collor.DARKGREY), new PositionChess('a', 8).ToPosition());
            Chess.PutPiece(new Tower(Chess, Collor.DARKGREY), new PositionChess('h', 8).ToPosition());
            Chess.PutPiece(new King(Chess, Collor.DARKGREY), new PositionChess('d', 8).ToPosition());
        }
    }
}
