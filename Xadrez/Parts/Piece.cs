﻿using System;
using System.Collections.Generic;
using Xadrez.BoardChess;
using Xadrez.Pallets;
namespace Xadrez.Parts
{
    abstract class Piece
    {
        /// <summary>
        /// Posicao da classe Peça.
        /// </summary>
        public Position position { get; set; }
        /// <summary>
        /// Tabuleiro da classe Peça.
        /// </summary>
        public Board board { get; protected set; }
        /// <summary>
        /// Cor da classe Peça.
        /// </summary>
        public Collor collor { get; protected set; }
        /// <summary>
        /// A quantidade de movimento.
        /// </summary>
        public int movement { get; protected set; }
        /// <summary>Imagens lista unicode.
        /// ♔, ♕, ♖, ♗, ♘, ♙ 
        /// </summary>
        public List<string> image = new List<string>() { " \u2654  ", " \u2655  ", " \u2656  "
                                                       , " \u2657  ", " \u2658  ", " \u2659  "};

        /// <summary>
        /// Construtor vazio.
        /// </summary>
        public Piece()
        {
        }

        /// <summary> Constructor da classe Peça.</summary>
        /// <param name="board"></param>
        /// <param name="collor"></param>
        public Piece(Board board, Collor collor)
        {
            position = null;
            this.board = board;
            this.collor = collor;
            movement = 0;
            Console.OutputEncoding = System.Text.Encoding.Unicode; // para as imagens das peças.
        }
        /// <summary>
        /// Incrementa o movimento.
        /// </summary>
        public void Move()
        {
            movement++;
        }

        /// <summary>
        /// Decrementa o movimento.
        /// </summary>
        public void RewindMovement()
        {
            movement--;
        }
        
        /// <summary>Recebe o movimento.</summary>
        /// <param name="square"></param>
        /// <returns></returns>
        public bool Move(Position square)
        {
            Piece piece = board.Piece(square);
            return piece == null || piece.collor != collor;
        }

        /// <summary>Movimenta se possível. </summary>
        /// <returns></returns>
        public bool IsPossibleTakeMoving()
        {
            bool[,] move = CharacteringMove();
            for (int i = 0; i < board.lines; i++)
            {
                for (int j = 0; j < board.collumns; j++)
                {
                    if (move[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
      
        /// <summary>Coloca a peça se possível.</summary>
        /// <param name="square"></param>
        /// <returns></returns>
        public bool IsPossiblePut(Position square)
        {
            return CharacteringMove()[square.line, square.collumn];
        }
       
        /// <summary>Movimentos possíveis, caracteristicas do movimento.</summary>
        /// <returns></returns>
        public abstract bool[,] CharacteringMove();
    }
}
