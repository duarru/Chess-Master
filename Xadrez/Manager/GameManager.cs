using Xadrez.BoardChess;
using Xadrez.Exception;
using Xadrez.Pallets;
using Xadrez.Parts;
using System.Collections.Generic;
namespace Xadrez.Manager
{
    class GameManager
    {
        /// <summary>Tabuleiro da classe GameManager.</summary>
        public Board chess { get; private set; }
        /// <summary>Turno da jogada.</summary>
        public int turn { get; private set; }
        /// <summary>Jogador autal.</summary>
        public Collor currentPlayer { get; private set; }
        /// <summary>Conjunto de peças da classe GameManager.</summary>
        public HashSet<Piece> pieces { get; set; }
        /// <summary>Conjuntos de peças capturadas da classe GamaManager.</summary>
        public HashSet<Piece> captured { get; set; }
        /// <summary>Vencedor verdadeiro ou falso.</summary>
        public bool winner { get; private set; }
        /// <summary>Imagens.</summary>
        public List<string> image = new List<string>() { "\u2654", "\u27ae", " \u2716  " };
        /// <summary>Check verdadeiro ou falso.</summary>
        public bool Check { get; private set; }

        /// <summary>Construtor partida de xadrez.</summary>
        public GameManager()
        {
            chess = new Board(8, 8);
            turn = 1;
            currentPlayer = Collor.WHITE;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            ShowPieces();
            winner = false;
            Check = false;
        }
        public Collor Player()
        {
            return currentPlayer;
        }
        /// <summary>Conta o turno das jogadas.</summary>
        /// <returns></returns>
        public int CountTurn()
        {
            return turn;
        }

        /// <summary>Executa o movimento, pega as peças.</summary>
        /// <param name="take"></param>
        /// <param name="put"></param>
        public Piece Movable(Position take, Position put)
        {
            Piece piece = chess.TakePiece(take);
            piece.Move();
            Piece captured = chess.TakePiece(put);
            chess.PutPiece(piece, put);
            if (captured != null)
            {
                this.captured.Add(captured);
            }
            return captured;
        }
        /// <summary>vDesfaze o movimento e devolve uma eventual peça capturada</summary>
        /// <param name="take"></param>
        /// <param name="put"></param>
        /// <param name="captured"></param>
        public void RewindMove(Position take, Position put, Piece captured)
        {
            Piece piece = chess.TakePiece(put);
            piece.RewindMovement();
            if (captured != null)
            {
                chess.PutPiece(captured, put);
                this.captured.Remove(captured);
            }
            chess.PutPiece(piece, take);
        }
        /// <summary>Realiza o movimento.</summary>
        /// <param name="take"></param>
        /// <param name="put"></param>
        public void PerformMotion(Position take, Position put)
        {
            Piece captured = Movable(take, put);
            if (InXeque(currentPlayer))
            {
                RewindMove(take, put, captured);
                throw new ExceptionChess($"{image[2]} Your cannot put yourself in check.");
            }

            if (InXeque(AnotherPlayer(currentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (XequeMate(AnotherPlayer(currentPlayer)))
            {
                winner = true;
            }
            else
            {
                turn++;
                ChangePlayer();
            }
        }
        /// <summary>Muda o jogador,controla a vez de cada um.</summary>
        /// <param name="current"></param>
        /// <param name="turn"></param>
        /// <param name="image"></param>
        private void ChangePlayer()
        {
            if (currentPlayer == Collor.WHITE)
            {
                currentPlayer = Collor.BLACK;
            }
            else
            {
                currentPlayer = Collor.WHITE;
            }
        }
        /// <summary>Conjunto das peças capturadas separadas por cor.</summary>
        /// <param name="collor"></param>
        /// <returns></returns>
        public HashSet<Piece> PiecesCaptureSepareteCollor(Collor collor)
        {
            HashSet<Piece> separetePieceCollor = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.collor.Equals(collor))
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
            foreach (Piece x in pieces)
            {
                if (x.collor.Equals(collor))
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
                throw new ExceptionChess($"Not have of collor the king {collor} on board chess.");
            }
            foreach (Piece move in PiecesOnBoardChess(AnotherPlayer(collor)))
            {
                bool[,] movePossible = move.CharacteringMove();
                if (movePossible[king.position.line, king.position.collumn])
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
                for (int i = 0; i < chess.lines; i++)
                {
                    for (int j = 0; j < chess.collumns; j++)
                    {
                        if (xeque[i, j])
                        {
                            Position take = xequeMate.position;
                            Position put = new Position(i, j);
                            Piece captured = Movable(take, put);
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
        /// <param name="square"></param>
        public void ExceptionTakeMove(Position square)
        {
            chess.ExceptionValidedLimit(square);
            if (chess.Piece(square) == null)
            {
                throw new ExceptionChess($" {image[2]} There is not piece here.");
            }
            if (currentPlayer != chess.Piece(square).collor)
            {
                throw new ExceptionChess($" It's the turn of {image[1]} {Player()}");
            }
            if (!chess.Piece(square).IsPossibleTakeMoving())
            {
                throw new ExceptionChess($" {image[2]} There is not movement");
            }
        }
        /// <summary>Exceção para soltar a peça.</summary>
        /// <param name="take"></param>
        /// <param name="put"></param>
        public void CheckPutInTheQuadrant(Position take, Position put)
        {
            if (!chess.Piece(take).IsPossiblePut(put))
            {
                throw new ExceptionChess("      It's not a valided moving");
            }
        }
        /// <summary>Coloca uma nova peça.</summary>
        /// <param name="collumn"></param>
        /// <param name="line"></param>
        /// <param name="piece"></param>
        public void LoadSquarePiece(char collumn, int line, Piece piece)
        {
            chess.PutPiece(piece, new PositionChess(collumn, line).ToPosition());
            pieces.Add(piece);
        }
        /// <summary>Posição inicial.</summary>
        private void ShowPieces()
        {
            LoadSquarePiece('a', 1, new Rock(chess, Collor.WHITE));
            LoadSquarePiece('b', 1, new Knight(chess, Collor.WHITE));
            LoadSquarePiece('c', 1, new Bishop(chess, Collor.WHITE));
            LoadSquarePiece('d', 1, new Queen(chess, Collor.WHITE));
            LoadSquarePiece('e', 1, new King(chess, Collor.WHITE));
            LoadSquarePiece('f', 1, new Bishop(chess, Collor.WHITE));
            LoadSquarePiece('g', 1, new Knight(chess, Collor.WHITE));
            LoadSquarePiece('h', 1, new Rock(chess, Collor.WHITE));
            LoadSquarePiece('a', 2, new Pawn(chess, Collor.WHITE));
            LoadSquarePiece('b', 2, new Pawn(chess, Collor.WHITE));
            LoadSquarePiece('c', 2, new Pawn(chess, Collor.WHITE));
            LoadSquarePiece('d', 2, new Pawn(chess, Collor.WHITE));
            LoadSquarePiece('e', 2, new Pawn(chess, Collor.WHITE));
            LoadSquarePiece('f', 2, new Pawn(chess, Collor.WHITE));
            LoadSquarePiece('g', 2, new Pawn(chess, Collor.WHITE));
            LoadSquarePiece('h', 2, new Pawn(chess, Collor.WHITE));

            LoadSquarePiece('a', 8, new Rock(chess, Collor.BLACK));
            LoadSquarePiece('b', 8, new Knight(chess, Collor.BLACK));
            LoadSquarePiece('c', 8, new Bishop(chess, Collor.BLACK));
            LoadSquarePiece('d', 8, new King(chess, Collor.BLACK));
            LoadSquarePiece('e', 8, new Queen(chess, Collor.BLACK));
            LoadSquarePiece('f', 8, new Bishop(chess, Collor.BLACK));
            LoadSquarePiece('g', 8, new Knight(chess, Collor.BLACK));
            LoadSquarePiece('h', 8, new Rock(chess, Collor.BLACK));
            LoadSquarePiece('a', 7, new Pawn(chess, Collor.BLACK));
            LoadSquarePiece('b', 7, new Pawn(chess, Collor.BLACK));
            LoadSquarePiece('c', 7, new Pawn(chess, Collor.BLACK));
            LoadSquarePiece('d', 7, new Pawn(chess, Collor.BLACK));
            LoadSquarePiece('e', 7, new Pawn(chess, Collor.BLACK));
            LoadSquarePiece('f', 7, new Pawn(chess, Collor.BLACK));
            LoadSquarePiece('g', 7, new Pawn(chess, Collor.BLACK));
            LoadSquarePiece('h', 7, new Pawn(chess, Collor.BLACK));
        }
    }
}
