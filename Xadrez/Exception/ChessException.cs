using System;
namespace Xadrez.Exception
{
    /// <summary>retorna mensagem de erro.</summary>
    class ChessException : ApplicationException
    {
        /// <summary>Retorna a mensagem de erro para a base.</summary>
        /// <param name="message"></param>
        public ChessException(string message) : base(message)
        {
        }
    }
}
