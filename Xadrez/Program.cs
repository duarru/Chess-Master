using System;
using Xadrez.Board;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardChess boardChess = new BoardChess(8,8);
            Chess.Show(boardChess);
        }
    }
}
