using System;
namespace Xadrez.Exception
{
    /// <summary>retorna mensagem de erro.</summary>
    class ChessException : ApplicationException
    {
        public ChessException(string message) : base(message)
        {
        }
    }
}
