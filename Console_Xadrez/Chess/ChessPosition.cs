using board;

namespace Chess
{
    internal class ChessPosition
    {
        public char Column { get; set; }
        public int Line { get; set; }

        public ChessPosition(char colum, int line)
        {
            Line = line;
            Column = colum;
        }

        public Position ToPosition()
        {
            return new Position(8 - Line, Column - 'a');
        }
        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}
