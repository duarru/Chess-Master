using Xadrez.Board;
using Xadrez.Exception;
using Xadrez.Pallets;
using Xadrez.Parts;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.ComponentModel;

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
        public HashSet<Piece> Captured { get; set; }
        /// <summary>Vencedor.</summary>
        public bool Winner { get; private set; }
        /// <summary>Imagem do jogador.</summary>
        public string Image { get; private set; }
        public bool Xeque { get; private set; }

        /// <summary>Construtor partida de xadrez.</summary>
        public GameManager()
        {
            Chess = new BoardChess(8, 8);
            Turn = 1;
            CurrentPlayer = Collor.WHITE;
            Image = "\u2655";
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            InitChessPosition();
            Winner = false;
            Xeque = false;
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
        /// <summary>Executa o movimento, pega as peças.</summary>
        /// <param name="take"></param>
        /// <param name="put"></param>
        public Piece Move(Position take, Position put)
        {
            Piece piece = Chess.TakePart(take);
            piece.Move();
            Piece captured = Chess.TakePart(put);
            Chess.PutPiece(piece, put);
            if (captured != null)
            {
                Captured.Add(captured);
            }
            return captured;
        }
        /// <summary>vDesfaze o movimento e devolve uma eventual peça capturada</summary>
        /// <param name="take"></param>
        /// <param name="put"></param>
        /// <param name="captured"></param>
        public void RewindMove(Position take, Position put, Piece captured)
        {
            Piece piece = Chess.TakePart(put);
            piece.MoonWalker();
            if (captured != null)
            {
                Chess.PutPiece(captured, put);
                Captured.Remove(captured);
            }
            Chess.PutPiece(piece, take);
        }
        /// <summary>Realiza o movimento, </summary>
        /// <param name="take"></param>
        /// <param name="put"></param>
        public void PerformMotion(Position take, Position put)
        {
            Piece captured = Move(take, put);
            if (InXeque(Player()))
            {
                RewindMove(take, put, captured);
                throw new ChessException("Your cannot put yourself in check.");
            }

            if (InXeque(AnotherPlayer(Player())))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if (XequeMate(AnotherPlayer(Player())))
            {
                Winner = true;
            }
            else
            {
                Turn++;
                ChangePlayer(Player(), Turn, Image);
            }
        }
        /// <summary>Controla a vez da jogada.</summary>
        /// <param name="current"></param>
        /// <param name="turn"></param>
        /// <param name="image"></param>
        private void ChangePlayer(Collor current, int turn, string image)
        {
            if (Player() == Collor.WHITE)
            {
                CurrentPlayer = Collor.BLACK;
            }
            else
            {
                CurrentPlayer = Collor.WHITE;
            }
            turn++;
        }
        /// <summary>Conjunto das peças capturadas separadas por cor.</summary>
        /// <param name="collor"></param>
        /// <returns></returns>
        public HashSet<Piece> PiecesCaptureSepareteCollor(Collor collor)
        {
            HashSet<Piece> separetePieceCollor = new HashSet<Piece>();
            foreach (Piece x in Captured)
            {
                if (x.Collor.Equals(collor))
                {
                    separetePieceCollor.Add(x);
                }
            }
            return separetePieceCollor;
        }
        /// <summary>Conjunto das peças em jogo.</summary>
        /// <param name="collor"></param>
        /// <returns></returns>
        public HashSet<Piece> PiecesOnBoardChess(Collor collor)
        {
            HashSet<Piece> piecesOnBoard = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Collor.Equals(collor))
                {
                    piecesOnBoard.Add(x);
                }
            }
            piecesOnBoard.ExceptWith(PiecesCaptureSepareteCollor(collor));
            return piecesOnBoard;
        }
        /// <summary>Peça adverçaria.</summary>
        /// <param name="collor"></param>
        /// <returns></returns>
        private Collor AnotherPlayer(Collor collor)
        {
            if (collor == Collor.WHITE)
            {
                return Collor.BLACK;
            }
            else
            {
                return Collor.WHITE;
            }
        }
        /// <summary>Devolve o rei de dada cor.</summary>
        /// <param name="collor"></param>
        /// <returns>null se não existir rei.</returns>
        private Piece TheKing(Collor collor)
        {
            foreach (Piece found in PiecesOnBoardChess(collor))
            {
                if (found is King)
                {
                    return found;
                }
            }
            return null;
        }
        /// <summary>Está em xeque.</summary>
        /// <param name="collor"></param>
        /// <returns></returns>
        public bool InXeque(Collor collor)
        {
            Piece king = TheKing(collor);
            if (king == null)
            {
                throw new ChessException($"Not have of collor the king {collor} on board chess.");
            }
            foreach (Piece move in PiecesOnBoardChess(AnotherPlayer(collor)))
            {
                bool[,] movePossible = move.CharacteringMove();
                if (movePossible[king.Position.Line, king.Position.Collumn])
                {
                    return true;
                }
            }
            return false;
        }

        public bool XequeMate(Collor collor)
        {
            if (!InXeque(collor))
            {
                return false;
            }
            foreach (Piece xequeMate in PiecesOnBoardChess(collor))
            {
                bool[,] xeque = xequeMate.CharacteringMove();
                for (int i = 0; i < Chess.Line; i++)
                {
                    for (int j = 0; j < Chess.Collumn; j++)
                    {
                        if (xeque[i, j])
                        {
                            Position take = xequeMate.Position;
                            Position put = new Position(i, j);
                            Piece captured = Move(take, put);
                            bool inXequeMate = InXeque(collor);
                            RewindMove(take, put, captured);

                            if (!inXequeMate)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>Excecção de movimento.</summary>
        /// <param name="quadrant"></param>
        public void CheckTakeAndMove(Position quadrant)
        {
            if (Chess.Piece(quadrant) == null)
            {
                throw new ChessException("      There is not piece here.");
            }
            if (Player() != Chess.Piece(quadrant).Collor)
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
        /// <summary>Coloca uma nova peça.</summary>
        /// <param name="collumn"></param>
        /// <param name="line"></param>
        /// <param name="piece"></param>
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
