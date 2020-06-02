using Xadrez.Board;
using Xadrez.Pallets;
using Xadrez.Parts;

namespace Xadrez.Manager
{
    class GameManager
    {
        public Quadrant Chess{ get; private set; }
        private int Turn;
        private Collor CurrentPlayer;
        public bool Winner { get; private set; }

        public GameManager()
        {
            Chess = new Quadrant(8, 8);
            Turn = 1;
            CurrentPlayer = Collor.DARKRED;
            InitPiece();
            Winner = false;
        }

        public void Move(Quadrant take, Quadrant put)
        {
            Piece piece = Chess.TakePart(take);
            piece.Move();
            Piece capture = Chess.TakePart(put);
            Chess.PutPiece(piece, put);
        }

        public void InitPiece()
        {
            Chess.PutPiece(new Tower(Chess, Collor.WHITE), new Quadrant('a', 1).ShowPositonChess());
            Chess.PutPiece(new Tower(Chess, Collor.WHITE), new Quadrant('h', 1).ShowPositonChess());
            Chess.PutPiece(new King(Chess, Collor.WHITE), new Quadrant('e', 1).ShowPositonChess());
            Chess.PutPiece(new Tower(Chess, Collor.DARKGREY), new Quadrant('a', 8).ShowPositonChess());
            Chess.PutPiece(new Tower(Chess, Collor.DARKGREY), new Quadrant('h', 8).ShowPositonChess());
            Chess.PutPiece(new King(Chess, Collor.DARKGREY), new Quadrant('d', 8).ShowPositonChess());


        }
    }
}
