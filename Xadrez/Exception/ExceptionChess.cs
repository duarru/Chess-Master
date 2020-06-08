using System;
namespace Chess.Exception
{
    class ExceptionChess : ApplicationException
    {
        /// <summary>Retorna a mensagem de erro para a base.</summary>
        /// <param name="message"></param>
        public ExceptionChess(string message) : base(message)
        {
        }
    }
}
