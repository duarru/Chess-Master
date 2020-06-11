using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Xml.Serialization;
using Xadrez.BoardChess;
using Xadrez.Exception;
using Xadrez.Manager;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class Pawn : Piece
    {
        private GameManager passant;
        public Pawn(Board board, Collor collor, GameManager passant) : base(board, collor)
        {
            this.passant = passant;
        }
        
        /// <summary>Existe inimigo, retorna cor e peça.</summary>
        /// <param name="square"></param>
        /// <returns></returns>
        private bool CaptureRadius(Position square)
        {
            Piece piece = board.Piece(square);
            return piece != null && piece.collor != collor;
        }
        /// <summary>Livre, se for o primeiro movimento.</summary>
        /// <param name="square"></param>
        /// <returns></returns>
        private bool NothingEnemy(Position square)
        {
            return board.Piece(square) == null;
        }
        public override string ToString()
        {
            return image[5];
        }
        public override bool[,] CharacteringMove()
        {

            bool[,] movePawn = new bool[board.lines, board.collumns];
            Position square = new Position(0, 0);
            if (collor.Equals(Collor.WHITE))
            {
                //cima.
                square.PieceToSquare(position.line - 1, position.collumn);
                if (board.ExceptionBoardLimit(square) && NothingEnemy(square))
                {
                    movePawn[square.line, square.collumn] = true;
                }
                //duas casas para cima.
                square.PieceToSquare(position.line - 2, position.collumn);
                if (board.ExceptionBoardLimit(square) && movement.Equals(0) && NothingEnemy(square))
                {
                    movePawn[square.line, square.collumn] = true;
                }
                //diagonal de capitura esquerda.
                square.PieceToSquare(position.line - 1, position.collumn - 1);
                if (board.ExceptionBoardLimit(square) && CaptureRadius(square))
                {
                    movePawn[square.line, square.collumn] = true;
                }
                //diagonal de capitura diireita.
                square.PieceToSquare(position.line - 1, position.collumn + 1);
                if (board.ExceptionBoardLimit(square) && CaptureRadius(square))
                {
                    movePawn[square.line, square.collumn] = true;
                }
                ///<summary>
                ///Movimento especial en passant.
                /// </summary>
                if (position.line.Equals(3))
                {
                    Position leftSquare = new Position(position.line, position.collumn - 1);
                    if (board.ExceptionBoardLimit(leftSquare)
                        && CaptureRadius(leftSquare)
                        && board.Piece(leftSquare) == passant.en_passant)
                    {
                        movePawn[leftSquare.line - 1, leftSquare.collumn] = true;
                    }

                    Position rightSquare = new Position(position.line, position.collumn + 1);
                    if (board.ExceptionBoardLimit(rightSquare)
                        && CaptureRadius(rightSquare)
                        && board.Piece(rightSquare) == passant.en_passant)
                    {
                        movePawn[rightSquare.line - 1, rightSquare.collumn] = true;
                    }
                }
            }
            else
            {
                if (collor.Equals(Collor.BLACK))
                {
                    //baxo.
                    square.PieceToSquare(position.line + 1, position.collumn);
                    if (board.ExceptionBoardLimit(square) && NothingEnemy(square))
                    {
                        movePawn[square.line, square.collumn] = true;
                    }
                    //duas casas para baixo.
                    square.PieceToSquare(position.line + 2, position.collumn);
                    if (board.ExceptionBoardLimit(square) && movement.Equals(0) && NothingEnemy(square))
                    {
                        movePawn[square.line, square.collumn] = true;
                    }
                    //diagonal de capitura direita.
                    square.PieceToSquare(position.line + 1, position.collumn + 1);
                    if (board.ExceptionBoardLimit(square) && CaptureRadius(square))
                    {
                        movePawn[square.line, square.collumn] = true;
                    }
                    //diagonal de capitura esquerda.
                    square.PieceToSquare(position.line + 1, position.collumn - 1);
                    if (board.ExceptionBoardLimit(square) && CaptureRadius(square))
                    {
                        movePawn[square.line, square.collumn] = true;
                    }
                    ///<summary>
                    ///Movimento especial en passant.
                    /// </summary>
                    if (position.line.Equals(4))
                    {
                        Position leftSquare = new Position(position.line, position.collumn - 1);
                        if (board.ExceptionBoardLimit(leftSquare)
                            && CaptureRadius(leftSquare)
                            && board.Piece(leftSquare) == passant.en_passant)
                        {
                            movePawn[leftSquare.line + 1, leftSquare.collumn] = true;
                        }

                        Position rightSquare = new Position(position.line, position.collumn + 1);
                        if (board.ExceptionBoardLimit(rightSquare)
                            && CaptureRadius(rightSquare)
                            && board.Piece(rightSquare) == passant.en_passant)
                        {
                            movePawn[rightSquare.line + 1, rightSquare.collumn] = true;
                        }
                    }
                }
            }
            return movePawn;
        }
    }
}
