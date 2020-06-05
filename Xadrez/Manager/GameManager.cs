using System.Drawing;
using System.Transactions;
using Xadrez.Board;
using Xadrez.Exception;
using Xadrez.Pallets;
using Xadrez.Parts;

namespace Xadrez.Manager
{
    class GameManager
    {
        public BoardChess Chess{ get; private set; }
        public int Turn { get; private set; }
        public Collor CurrentPlayer { get; private set; }
        public bool Winner { get; private set; }
        public string Image { get; private set; }
        /// <summary>Construtor.</summary>
        public GameManager()
        {
            Chess = new BoardChess(8, 8);
            Turn = 1;
            CurrentPlayer = Collor.WHITE;
            Image = "\u2655";
            InitChessPosition();
            Winner = false;
        }
        /// <summary>Pega a peça e coloca.</summary>
        /// <param name="take"></param>
        /// <param name="put"></param>
        public void Move(Position take, Position put)
        {
            Piece piece = Chess.TakePart(take);
            piece.Move();
            Piece capture = Chess.TakePart(put);
            Chess.PutPiece(piece, put);
        }
        /// <summary>Posição das peças iniciais.</summary>
        /// <param name="take"></param>
        /// <param name="put"></param>
        public void InitMove(Position take, Position put)
        {
            Move(take, put);
            Turn++;
            ChangePlayer(CurrentPlayer, Turn, Image);
        }
        /// <summary>Conta o turno das jogadas.</summary>
        /// <returns></returns>
        public int CountTurn()
        {
            return Turn;
        }
        /// <summaty>Apresenta a imagem do jogador.</summary>
        /// <returns></returns>
        public string PlayerImage()
        {
            return Image;
        }
        /// <summary>Jogador atual.</summary>
        /// <returns></returns>
        public Collor Player()
        {
            return CurrentPlayer;
        }
        /// <summary>Controla a vez da jogada.</summary>
        /// <param name="current"></param>
        /// <param name="turn"></param>
        /// <param name="image"></param>
        private void ChangePlayer(Collor current, int turn, string image)
        {
            if(CurrentPlayer == Collor.WHITE)
            {
                CurrentPlayer = Collor.BLACK;
            }
            else
            {
                CurrentPlayer = Collor.WHITE;
            }
            turn++;
        }
        public void CheckTakeAndMove(Position quadrant)
        {
            if(Chess.Piece(quadrant) == null)
            {
                throw new ChessException("      There is not piece here.");
            }
            if (CurrentPlayer != Chess.Piece(quadrant).Collor)
            {
                throw new ChessException($"      It's the turn of \u27ae {Player()}");
            }
            if (!Chess.Piece(quadrant).IsPossibleTakeMoving()){
                throw new ChessException("      There is not movement");
            }
        }
        public void CheckPutInTheQuadrant(Position take, Position put)
        {
            if (!Chess.Piece(take).IsPossiblePut(put))
            {
                throw new ChessException("      It's not a valided moving");
            }
        }
        /// <summary>Posição inicial.</summary>
        private void InitChessPosition()
        {
            Chess.PutPiece(new Tower(Chess, Collor.WHITE), new PositionChess('a', 1).ToPosition());
            Chess.PutPiece(new Tower(Chess, Collor.WHITE), new PositionChess('h', 1).ToPosition());
            Chess.PutPiece(new King(Chess, Collor.WHITE), new PositionChess('e', 1).ToPosition());
            Chess.PutPiece(new King(Chess, Collor.WHITE), new PositionChess('d', 1).ToPosition());
            Chess.PutPiece(new King(Chess, Collor.WHITE), new PositionChess('f', 1).ToPosition());
            Chess.PutPiece(new King(Chess, Collor.WHITE), new PositionChess('e', 2).ToPosition());
            Chess.PutPiece(new King(Chess, Collor.WHITE), new PositionChess('d', 2).ToPosition());
            Chess.PutPiece(new King(Chess, Collor.WHITE), new PositionChess('f', 2).ToPosition());


            Chess.PutPiece(new Tower(Chess, Collor.BLACK), new PositionChess('a', 8).ToPosition());
            Chess.PutPiece(new Tower(Chess, Collor.BLACK), new PositionChess('h', 8).ToPosition());
            Chess.PutPiece(new King(Chess, Collor.BLACK), new PositionChess('d', 8).ToPosition());
        }
    }
}
