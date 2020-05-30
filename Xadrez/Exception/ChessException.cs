using System;
namespace Xadrez.Exception
{
    class ChessException : ApplicationException
    {
        public ChessException(string message) : base(message)
        {
        }
    }
}
