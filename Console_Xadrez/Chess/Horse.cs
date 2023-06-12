using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Horse : Piece
    {
        public Horse(Color color, Board board) : base(color, board)
        {
        }

        public override string? ToString()
        {
            return "H";
        }
    }
}
