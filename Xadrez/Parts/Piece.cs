using System;
using System.Collections.Generic;
using System.Text;
using Xadrez.Board;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class Piece
    {
        public BoardChess Position { get; set; }
        public BoardChess BoardChess { get; protected set; }
        public Collor Collor { get; protected set; }
        public int Movement { get; protected set; }

        public Piece(BoardChess position, BoardChess boardChess, Collor collor)
        {
            Position = position;
            BoardChess = boardChess;
            Collor = collor;
            Movement = 0;
        }
    }
}
