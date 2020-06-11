using Xadrez.BoardChess;
using Xadrez.Exception;
using Xadrez.Pallets;
using Xadrez.Parts;
using System.Collections.Generic;
using System;
using Microsoft.VisualBasic;
using System.ComponentModel.Design;
using System.Drawing;

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
        public List<string> image = new List<string>() { "\u2654", "\u27ae", " \u2716  " };//{♔, ➮, ✖}
        /// <summary>Check verdadeiro ou falso.</summary>
        public bool check { get; private set; }
        public Piece en_passant { get; private set; }

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
            check = false;
            en_passant = null;
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

            ///<summary>
            /// Torre menor.
            /// </summary>
            if (piece is King && put.collumn == take.collumn + 2)
            {
                Position takeRoke = new Position(take.line, take.collumn + 3);
                Position putRoke = new Position(take.line, take.collumn + 1);
                Piece rock = chess.TakePiece(takeRoke);
                rock.Move();
                chess.PutPiece(rock, putRoke);
            }
            ///<summary>
            /// Torre maior.
            /// </summary>
            if (piece is King && put.collumn == take.collumn - 2)
            {
                Position takeRoke = new Position(take.line, take.collumn - 4);
                Position putRoke = new Position(take.line, take.collumn - 1);
                Piece rock = chess.TakePiece(takeRoke);
                rock.Move();
                chess.PutPiece(rock, putRoke);
            }

            ///<summary>
            ///En passant
            /// </summary>
            if (piece is Pawn)
            {
                if (take.collumn != put.collumn && captured == null)
                {
                    Position pawn;
                    if (piece.collor.Equals(Collor.WHITE))
                    {
                        pawn = new Position(put.line + 1, put.collumn);
                    }
                    else
                    {
                        pawn = new Position(put.line - 1, put.collumn);
                    }
                    captured = chess.TakePiece(pawn);
                    this.captured.Add(captured);
                }
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
            ///<summary>
            /// Torre menor.
            /// </summary>
            if (piece is King && put.collumn == take.collumn + 2)
            {
                Position takeRoke = new Position(take.line, take.collumn + 3);
                Position putRoke = new Position(take.line, take.collumn + 1);
                Piece rock = chess.TakePiece(takeRoke);
                rock.RewindMovement();
                chess.PutPiece(rock, putRoke);
            }
            ///<summary>
            /// Torre maior.
            /// </summary>
            if (piece is King && put.collumn == take.collumn - 2)
            {
                Position takeRoke = new Position(take.line, take.collumn - 4);
                Position putRoke = new Position(take.line, take.collumn - 1);
                Piece rock = chess.TakePiece(putRoke);
                rock.RewindMovement();
                chess.PutPiece(rock, takeRoke);
            }

            ///<summary>
            ///En passant.
            /// </summary>
            if (piece is Pawn)
            {
                if (take.collumn != put.collumn && captured == null)
                {
                    Piece putPawn = chess.TakePiece(put);
                    Position pawn;
                    if (piece.collor.Equals(Collor.WHITE))
                    {
                        pawn = new Position(3, put.collumn);
                    }
                    else
                    {
                        pawn = new Position(4, put.collumn);
                    }
                    chess.PutPiece(piece, pawn);
                }
            }
            chess.PutPiece(piece, take);
        }
        /// <summary>Realiza o movimento.</summary>
        /// <param name="take"></param>
        /// <param name="put"></param>
        public void MovablePerform(Position take, Position put)
        {
            Piece captured = Movable(take, put);
            if (InChedk(currentPlayer))
            {
                RewindMove(take, put, captured);
                throw new ExceptionChess($"{image[2]} Your cannot put yourself in check.");
            }
            Piece putPiece = chess.Piece(put);
            
            ///<summary>
            ///Movimento especial promoção. 
            /// </summary>
            if(putPiece is Piece)
            {
                if (putPiece.collor.Equals(Collor.WHITE) && put.line.Equals(0) ||
                    putPiece.collor.Equals(Collor.BLACK) && put.line.Equals(7))
                {
                    putPiece = chess.Piece(put);
                    putPiece = chess.TakePiece(put);
                    pieces.Remove(putPiece);
                    Piece queen = new Queen(chess, putPiece.collor);
                    chess.PutPiece(queen, put);
                    pieces.Add(queen);
                }
            }
            
            if (InChedk(AnotherPlayer(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }
            if (CheckMate(AnotherPlayer(currentPlayer)))
            {
                winner = true;
            }
            else
            {
                turn++;
                ChangePlayer();
            }

            ///<summary>
            ///En passant
            /// </summary>
            if((putPiece is Pawn) && (put.line.Equals(take.line - 2)) ||
                (putPiece is Pawn) && (put.line.Equals(take.line + 2))){
                en_passant = putPiece;
            }
            else
            {
                en_passant = null;
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
            foreach (Piece fill in pieces)
            {
                if (fill.collor.Equals(collor))
                {
                    piecesOnBoard.Add(fill);
                }
            }
            piecesOnBoard.ExceptWith(PiecesCaptureSepareteCollor(collor));// exceto essa cor.
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
        public bool InChedk(Collor collor)
        {
            Piece king = TheKing(collor);
            if (king == null)
            {
                throw new ExceptionChess($"{image[2]}Not have of collor the king {collor} on board chess.");
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

        public bool CheckMate(Collor collor)
        {
            if (!InChedk(collor))
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
                            bool inXequeMate = InChedk(collor);
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
                throw new ExceptionChess($"{image[2]}There is not piece here.");
            }
            if (currentPlayer != chess.Piece(square).collor)
            {
                throw new ExceptionChess($"{image[2]}It's the turn of {image[1]} {Player()}");
            }
            if (!chess.Piece(square).IsPossibleTakeMoving())
            {
                throw new ExceptionChess($"{image[2]} There is not movement");
            }
        }
        /// <summary>Exceção para soltar a peça.</summary>
        /// <param name="take"></param>
        /// <param name="put"></param>
        public void ExceptionToPut(Position take, Position put)
        {
            if (!chess.Piece(take).IsPossiblePut(put))
            {
                throw new ExceptionChess($"{image[2]}It's not a valided moving");
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
            LoadSquarePiece('e', 1, new King(chess, Collor.WHITE, this));
            LoadSquarePiece('f', 1, new Bishop(chess, Collor.WHITE));
            LoadSquarePiece('g', 1, new Knight(chess, Collor.WHITE));
            LoadSquarePiece('h', 1, new Rock(chess, Collor.WHITE));
            LoadSquarePiece('a', 2, new Pawn(chess, Collor.WHITE,this));
            LoadSquarePiece('b', 2, new Pawn(chess, Collor.WHITE, this));
            LoadSquarePiece('c', 2, new Pawn(chess, Collor.WHITE, this));
            LoadSquarePiece('d', 2, new Pawn(chess, Collor.WHITE, this));
            LoadSquarePiece('e', 2, new Pawn(chess, Collor.WHITE, this));
            LoadSquarePiece('f', 2, new Pawn(chess, Collor.WHITE, this));
            LoadSquarePiece('g', 2, new Pawn(chess, Collor.WHITE, this));
            LoadSquarePiece('h', 2, new Pawn(chess, Collor.WHITE, this));

            LoadSquarePiece('a', 8, new Rock(chess, Collor.BLACK));
            LoadSquarePiece('b', 8, new Knight(chess, Collor.BLACK));
            LoadSquarePiece('c', 8, new Bishop(chess, Collor.BLACK));
            LoadSquarePiece('e', 8, new King(chess, Collor.BLACK, this));
            LoadSquarePiece('d', 8, new Queen(chess, Collor.BLACK));
            LoadSquarePiece('f', 8, new Bishop(chess, Collor.BLACK));
            LoadSquarePiece('g', 8, new Knight(chess, Collor.BLACK));
            LoadSquarePiece('h', 8, new Rock(chess, Collor.BLACK));
            LoadSquarePiece('a', 7, new Pawn(chess, Collor.BLACK, this));
            LoadSquarePiece('b', 7, new Pawn(chess, Collor.BLACK, this));
            LoadSquarePiece('c', 7, new Pawn(chess, Collor.BLACK, this));
            LoadSquarePiece('d', 7, new Pawn(chess, Collor.BLACK, this));
            LoadSquarePiece('e', 7, new Pawn(chess, Collor.BLACK, this));
            LoadSquarePiece('f', 7, new Pawn(chess, Collor.BLACK, this));
            LoadSquarePiece('g', 7, new Pawn(chess, Collor.BLACK, this));
            LoadSquarePiece('h', 7, new Pawn(chess, Collor.BLACK, this));
        }
    }
}
