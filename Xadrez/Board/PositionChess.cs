using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Xadrez.Board
{
    class PositionChess
    {
        public char Collumn { get; set; }
        public int Line { get; set; }

        public PositionChess(char collumn, int line)
        {
            Collumn = collumn;
            Line = line;
        }

        public Position ToPosition()
        {
            return new Position(8 - Line, Collumn - 'a');
        }
        public override string ToString()
        {
            return "" + Collumn + Line;
        }
    }
}
