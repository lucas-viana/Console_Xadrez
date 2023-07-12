using Console_Xadrez.Board;

namespace Chess
{
    internal class Pawn : Piece
    {
        private ChessMatch Match;
        public Pawn(Color color, Board board, ChessMatch match) : base(color, board)
        {
            Match = match;
        }

        public override string? ToString()
        {
            return "P";
        }

        private bool ExistEnemy(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece != null && piece.Color != Color;
        }

        private bool Free(Position position)
        {
            return Board.Piece(position) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Line, Board.Colums];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.SetValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValues(Position.Line - 2, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos) && NumMoviment == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #SpecialMove en passant

                if (Position.Line == 3)
                {
                    Position Left = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(Left) && ExistEnemy(Left) && Board.Piece(Left)== Match.VulnerablePassing)
                    {
                        mat[Left.Line-1, Left.Column] = true;
                    }

                    Position Rigth = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(Rigth) && ExistEnemy(Rigth) && Board.Piece(Rigth) == Match.VulnerablePassing)
                    {
                        mat[Rigth.Line-1, Rigth.Column] = true;
                    }
                }
            }
            else
            {

                pos.SetValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }


                pos.SetValues(Position.Line + 2, Position.Column);
                if (Board.ValidPosition(pos) && Free(pos) && NumMoviment == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                pos.SetValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(pos) && ExistEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #SpecialMove en passant

                if (Position.Line == 4)
                {
                    Position Left = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(Left) && ExistEnemy(Left) && Board.Piece(Left) == Match.VulnerablePassing)
                    {
                        mat[Left.Line+1, Left.Column] = true;
                    }

                    Position Rigth = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(Rigth) && ExistEnemy(Rigth) && Board.Piece(Rigth) == Match.VulnerablePassing)
                    {
                        mat[Rigth.Line+1, Rigth.Column] = true;
                    }
                }
            }
            return mat;
        }
    }
}
