using System;
namespace Xadrez.Exception
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
