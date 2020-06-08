using Chess.BoardChess;
using Chess.Exception;
using Chess.Pallets;
using Chess.Parts;
using System.Collections.Generic;
namespace Chess.Manager
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
        /// <summary>Imagem do jogador.</summary>
        public string image { get; private set; }
        /// <summary>Check verdadeiro ou falso.</summary>
        public bool Check { get; private set; }

        /// <summary>Construtor partida de xadrez.</summary>
        public GameManager()
        {
            chess = new Board(8, 8);
            turn = 1;
            currentPlayer = Collor.WHITE;
            image = "\u2654";
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            InitChessPosition();
            winner = false;
            Check = false;
        }

        /// <summary>Conta o turno das jogadas.</summary>
        /// <returns></returns>
        public int CountTurn()
        {
            return turn++;
        }

        /// <summaty>Apresenta a imagem do jogador.</summary>
        /// <returns></returns>
        public string PlayerImage()
        {
            return image;
        }

        /// <summary>Jogador atual.</summary>
        /// <returns></returns>
        public Collor Player()
        {
            return currentPlayer;
        }

        /// <summary>Executa o movimento, pega as peças.</summary>
        /// <param name="take"></param>
        /// <param name="put"></param>
        public Piece Move(Position take, Position put)
        {
            Piece piece = chess.TakePart(take);
            piece.Move();
            Piece captured = chess.TakePart(put);
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
            Piece piece = chess.TakePart(put);
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
            Piece captured = Move(take, put);
            if (InXeque(Player()))
            {
                RewindMove(take, put, captured);
                throw new ExceptionChess("Your cannot put yourself in check.");
            }

            if (InXeque(AnotherPlayer(Player())))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (XequeMate(AnotherPlayer(Player())))
            {
                winner = true;
            }
            else
            {
                CountTurn();
                ChangePlayer(Player());
            }
        }
        /// <summary>Controla a vez da jogada.</summary>
        /// <param name="current"></param>
        /// <param name="turn"></param>
        /// <param name="image"></param>
        private Collor ChangePlayer(Collor currentPlayer)
        {
            if (Player() == Collor.WHITE)
            {
                currentPlayer = Collor.BLACK;
            }
            else
            {
                currentPlayer = Collor.WHITE;
            }
            return currentPlayer;
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
            if (chess.Piece(quadrant) == null)
            {
                throw new ExceptionChess("      There is not piece here.");
            }
            if (Player() != chess.Piece(quadrant).collor)
            {
                throw new ExceptionChess($"      It's the turn of \u27ae {Player()}");
            }
            if (!chess.Piece(quadrant).IsPossibleTakeMoving())
            {
                throw new ExceptionChess("      There is not movement");
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
        public void PutPieceOnBoard(char collumn, int line, Piece piece)
        {
            chess.PutPiece(piece, new PositionChess(collumn, line).ToPosition());
            pieces.Add(piece);
        }
        /// <summary>Posição inicial.</summary>
        private void InitChessPosition()
        {
            PutPieceOnBoard('a', 1, new Rock(chess, Collor.WHITE));

            PutPieceOnBoard('a', 1, new Rock(chess, Collor.WHITE));
            PutPieceOnBoard('b', 1, new Knight(chess, Collor.WHITE));
            PutPieceOnBoard('c', 1, new Bishop(chess, Collor.WHITE));
            PutPieceOnBoard('d', 1, new Queen(chess, Collor.WHITE));
            PutPieceOnBoard('e', 1, new King(chess, Collor.WHITE));
            PutPieceOnBoard('f', 1, new Bishop(chess, Collor.WHITE));
            PutPieceOnBoard('g', 1, new Knight(chess, Collor.WHITE));
            PutPieceOnBoard('h', 1, new Rock(chess, Collor.WHITE));
            PutPieceOnBoard('a', 2, new Pawn(chess, Collor.WHITE));
            PutPieceOnBoard('b', 2, new Pawn(chess, Collor.WHITE));
            PutPieceOnBoard('c', 2, new Pawn(chess, Collor.WHITE));
            PutPieceOnBoard('d', 2, new Pawn(chess, Collor.WHITE));
            PutPieceOnBoard('e', 2, new Pawn(chess, Collor.WHITE));
            PutPieceOnBoard('f', 2, new Pawn(chess, Collor.WHITE));
            PutPieceOnBoard('g', 2, new Pawn(chess, Collor.WHITE));
            PutPieceOnBoard('h', 2, new Pawn(chess, Collor.WHITE));

            PutPieceOnBoard('a', 8, new Rock(chess, Collor.BLACK));
            PutPieceOnBoard('b', 8, new Knight(chess, Collor.BLACK));
            PutPieceOnBoard('c', 8, new Bishop(chess, Collor.BLACK));
            PutPieceOnBoard('d', 8, new King(chess, Collor.BLACK));
            PutPieceOnBoard('e', 8, new Queen(chess, Collor.BLACK));
            PutPieceOnBoard('f', 8, new Bishop(chess, Collor.BLACK));
            PutPieceOnBoard('g', 8, new Knight(chess, Collor.BLACK));
            PutPieceOnBoard('h', 8, new Rock(chess, Collor.BLACK));
            PutPieceOnBoard('a', 7, new Pawn(chess, Collor.BLACK));
            PutPieceOnBoard('b', 7, new Pawn(chess, Collor.BLACK));
            PutPieceOnBoard('c', 7, new Pawn(chess, Collor.BLACK));
            PutPieceOnBoard('d', 7, new Pawn(chess, Collor.BLACK));
            PutPieceOnBoard('e', 7, new Pawn(chess, Collor.BLACK));
            PutPieceOnBoard('f', 7, new Pawn(chess, Collor.BLACK));
            PutPieceOnBoard('g', 7, new Pawn(chess, Collor.BLACK));
            PutPieceOnBoard('h', 7, new Pawn(chess, Collor.BLACK));


        }
    }
}
