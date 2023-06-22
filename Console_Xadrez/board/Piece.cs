namespace Console_Xadrez.Board
{
    internal abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int NumMoviment { get; set; }
        public Board Board { get; set; }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            NumMoviment = 0;
        }
        public void IncrementMoviment()
        {
            NumMoviment++;
        }

        public bool TestPossibleMoves()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < Board.Line; i++)
            {
                for(int j = 0; j < Board.Colums; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool TestPossibleMovesTarget(Position target)
        {
            return PossibleMoves()[target.Line, target.Column];
        }
        public abstract bool[,] PossibleMoves();

    }






}
