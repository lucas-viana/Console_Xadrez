using Console_Xadrez.Board;

namespace Chess
{
    internal class Rook : Piece
    {
        public Rook(Color color, Board board) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "R";
        }
        private bool CanMove(Position position)
        {
            Piece piece = Board.piece(position);
            return piece == null || piece.Color != Color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Line, Board.Colums];
            Position pos = new Position(0, 0);

            // Up
            pos.SetValues(Position.Line - 1, Position.Column);
            while(Board.ValidPosition(pos)&& CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) == null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line--;
            }

            // Rigth
            pos.SetValues(Position.Line, Position.Column+1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) == null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column++;
            }

            // Down
            pos.SetValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) == null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line++;
            }

            // Left
            pos.SetValues(Position.Line, Position.Column-1);
            while (Board.ValidPosition(pos) && CanMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.piece(pos) == null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Column--;
            }

            return mat;
        }
    }
}
