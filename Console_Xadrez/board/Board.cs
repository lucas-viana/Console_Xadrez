using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace board
{
    internal class Board
    {
        public int Line { get; set; }
        public int Colums { get; set; }
        private Piece[,] Piece;

        //Contructs
        public Board(int line, int colums)
        {
            Line = line;
            Colums = colums;
            Piece =new Piece [line, colums];
        }

        //Methods

        public Piece piece(int line, int colums)
        {
            return Piece[line, colums];
        }

        public void PutPiece (Piece piece, Position position)
        {
            Piece[position.Line,position.Column] = piece;
            piece.Position = position;
        }
    }
}
