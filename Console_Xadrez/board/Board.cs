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

        public Board(int line, int colums)
        {
            Line = line;
            Colums = colums;
            Piece =new Piece [line, colums];
        }
    }
}
