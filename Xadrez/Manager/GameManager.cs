﻿using System.Drawing;
using System.Transactions;
using Xadrez.Board;
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

        public void InitMove(Position take, Position put)
        {
            Move(take, put);
            Turn++;
            ChangePlayer(CurrentPlayer, Turn);
        }
        public int CountTurn()
        {
            return Turn;
        }
        public Collor Player()
        {
            return CurrentPlayer;
        }
        private void ChangePlayer(Collor current, int turn)
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
        private void InitChessPosition()
        {
            Chess.PutPiece(new Tower(Chess, Collor.WHITE), new PositionChess('a', 1).ToPosition());
            Chess.PutPiece(new Tower(Chess, Collor.WHITE), new PositionChess('h', 1).ToPosition());
            Chess.PutPiece(new King(Chess, Collor.WHITE), new PositionChess('e', 1).ToPosition());
            Chess.PutPiece(new Tower(Chess, Collor.BLACK), new PositionChess('a', 8).ToPosition());
            Chess.PutPiece(new Tower(Chess, Collor.BLACK), new PositionChess('h', 8).ToPosition());
            Chess.PutPiece(new King(Chess, Collor.BLACK), new PositionChess('d', 8).ToPosition());
        }
    }
}
