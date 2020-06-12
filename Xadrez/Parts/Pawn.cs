using System;
using System.Collections.Generic;
using Xadrez.BoardChess;
using Xadrez.Exception;
using Xadrez.Manager;
using Xadrez.Pallets;

namespace Xadrez.Parts
{
    class Pawn : Piece
    {
        /// <summary>
        /// Acesso a classe GameManager.
        /// </summary>
        private GameManager passant;
        public Pawn(Board board, Collor collor, GameManager passant) : base(board, collor)
        {
            this.passant = passant;
        }
        
        /// <summary>
        /// Existe inimigo, retorna cor e peça.
        /// </summary>
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

        /// <summary>
        /// Imagem do peão.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return image[5];
        }

        /// <summary>
        /// Caracterista do movimento do peão.
        /// </summary>
        /// <returns></returns>
        public override bool[,] CharacteringMove()
        {
            bool[,] movePawn = new bool[board.lines, board.collumns];
            Position square = new Position(0, 0);
            
            ///<summary>
            ///Peças brancas do tabuleiro.
            ///</sumarry>
            if (collor.Equals(Collor.WHITE))
            {
                ///<summary>
                ///cima.
                ///</summary>
                square.PieceToSquare(position.line - 1, position.collumn);
                if (board.ExceptionBoardLimit(square) && NothingEnemy(square))
                {
                    movePawn[square.line, square.collumn] = true;
                }

                ///<summary>
                ///duas casas para cima.
                ///</summary>
                square.PieceToSquare(position.line - 2, position.collumn);
                if (board.ExceptionBoardLimit(square) && movement.Equals(0) && NothingEnemy(square))
                {
                    movePawn[square.line, square.collumn] = true;
                }
                
                ///<summary>
                ///diagonal de capitura esquerda.
                ///</summary>
                square.PieceToSquare(position.line - 1, position.collumn - 1);
                if (board.ExceptionBoardLimit(square) && CaptureRadius(square))
                {
                    movePawn[square.line, square.collumn] = true;
                }

                ///<summary>
                ///diagonal de capitura diireita.
                ///</summary>
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
                    ///<summary>
                    ///captura a esquerda.
                    ///</summary>
                    Position leftSquare = new Position(position.line, position.collumn - 1);
                    if (board.ExceptionBoardLimit(leftSquare)
                        && CaptureRadius(leftSquare)
                        && board.Piece(leftSquare) == passant.en_passant)
                    {
                        movePawn[leftSquare.line - 1, leftSquare.collumn] = true;
                    }
                    
                    ///<summary>
                    ///captura a direita.
                    ///</summary>
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
                ///<summary>
                ///Peças pretas do tabuleiro.
                ///</summary>
                if (collor.Equals(Collor.BLACK))
                {
                    ///<summary>
                    ///baxo.
                    ///</summary>
                    square.PieceToSquare(position.line + 1, position.collumn);
                    if (board.ExceptionBoardLimit(square) && NothingEnemy(square))
                    {
                        movePawn[square.line, square.collumn] = true;
                    }

                    ///<summary>
                    ///duas casas para baixo.
                    ///</summary>
                    square.PieceToSquare(position.line + 2, position.collumn);
                    if (board.ExceptionBoardLimit(square) && movement.Equals(0) && NothingEnemy(square))
                    {
                        movePawn[square.line, square.collumn] = true;
                    }

                    ///<summary>
                    ///diagonal de capitura direita.
                    ///</summary>
                    square.PieceToSquare(position.line + 1, position.collumn + 1);
                    if (board.ExceptionBoardLimit(square) && CaptureRadius(square))
                    {
                        movePawn[square.line, square.collumn] = true;
                    }

                    ///<summary>
                    ///diagonal de capitura esquerda.
                    ///</summary>
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
                        ///<summary>
                        ///diagonal de captura esquerda.
                        ///</summary>
                        Position leftSquare = new Position(position.line, position.collumn - 1);
                        if (board.ExceptionBoardLimit(leftSquare)
                            && CaptureRadius(leftSquare)
                            && board.Piece(leftSquare) == passant.en_passant)
                        {
                            movePawn[leftSquare.line + 1, leftSquare.collumn] = true;
                        }

                        ///<summary>
                        ///diagonal de captura direita
                        /// </summary>
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
