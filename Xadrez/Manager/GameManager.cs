using System.Drawing;
using System.Transactions;
using Xadrez.Board;
using Xadrez.Exception;
using Xadrez.Pallets;
using Xadrez.Parts;
using System.Collections.Generic;
using System.Globalization;
using System.Data;

namespace Xadrez.Manager
{
    class GameManager
    {
        /// <summary>Tabuleiro.</summary>
        public BoardChess Chess { get; private set; }
        /// <summary>Turno da jogada.</summary>
        public int Turn { get; private set; }
        /// <summary>Vez do jogador.</summary>
        public Collor CurrentPlayer { get; private set; }
        /// <summary>Conjunto de peças.</summary>
        public HashSet<Piece> Pieces { get; set; }
        /// <summary>Conjuntos de peças capturadas.</summary>
        public HashSet<Piece> Capture { get; set; }
        /// <summary>Vencedor.</summary>
        public bool Winner { get; private set; }
        /// <summary>Imagem do jogador.</summary>
        public string Image { get; private set; }
        /// <summary>Construtor.</summary>
        public GameManager()
        {
            Chess = new BoardChess(8, 8);
            Turn = 1;
            CurrentPlayer = Collor.WHITE;
            Image = "\u2655";
            Pieces = new HashSet<Piece>();
            Capture = new HashSet<Piece>();
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
            if(capture != null)
            {
                Capture.Add(capture);
            }
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
            if (CurrentPlayer == Collor.WHITE)
            {
                CurrentPlayer = Collor.BLACK;
            }
            else
            {
                CurrentPlayer = Collor.WHITE;
            }
            turn++;
        }
        /// <summary>Peças capturadas separadas por cor.</summary>
        /// <param name="collor"></param>
        /// <returns></returns>
        public HashSet<Piece> PiecesCaptureSepareteCollor(Collor collor)
        {
            HashSet<Piece> separetePieceCollor = new HashSet<Piece>();
            foreach (Piece x in Capture)
            {
                if (x.Collor.Equals(collor))
                {
                    separetePieceCollor.Add(x);
                }
            }
            return separetePieceCollor;
        }
        /// <summary>Peças em jogo.</summary>
        /// <param name="collor"></param>
        /// <returns></returns>
        public HashSet<Piece> PiecesOnBoardChess(Collor collor)
        {
            HashSet<Piece> piecesOnBoard = new HashSet<Piece>();
            foreach (Piece x in Capture)
            {
                if (x.Collor.Equals(collor))
                {
                    piecesOnBoard.Add(x);
                }
            }
            piecesOnBoard.ExceptWith(PiecesCaptureSepareteCollor(collor));
            return piecesOnBoard;
        }

        /// <summary>Excecção de movimento.</summary>
        /// <param name="quadrant"></param>
        public void CheckTakeAndMove(Position quadrant)
        {
            if (Chess.Piece(quadrant) == null)
            {
                throw new ChessException("      There is not piece here.");
            }
            if (CurrentPlayer != Chess.Piece(quadrant).Collor)
            {
                throw new ChessException($"      It's the turn of \u27ae {Player()}");
            }
            if (!Chess.Piece(quadrant).IsPossibleTakeMoving())
            {
                throw new ChessException("      There is not movement");
            }
        }
        /// <summary>Exceção para soltar a peça.</summary>
        /// <param name="take"></param>
        /// <param name="put"></param>
        public void CheckPutInTheQuadrant(Position take, Position put)
        {
            if (!Chess.Piece(take).IsPossiblePut(put))
            {
                throw new ChessException("      It's not a valided moving");
            }
        }
        public void PutPieceOnBoard(char collumn, int line, Piece piece)
        {
            Chess.PutPiece(piece, new PositionChess(collumn, line).ToPosition());
            Pieces.Add(piece);
        }
        /// <summary>Posição inicial.</summary>
        private void InitChessPosition()
        {

            PutPieceOnBoard('a', 1, new Tower(Chess, Collor.WHITE));

            PutPieceOnBoard('e', 1, new King(Chess, Collor.WHITE));

            PutPieceOnBoard('h', 1, new Tower(Chess, Collor.WHITE));

            PutPieceOnBoard('a', 8, new Tower(Chess, Collor.BLACK));

            PutPieceOnBoard('d', 8, new King(Chess, Collor.BLACK));

            PutPieceOnBoard('h', 8, new Tower(Chess, Collor.BLACK));

        }
    }
}
