using Console_Xadrez.Board;

namespace Chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Rotation { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool EndUp { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Rotation = 1;
            CurrentPlayer = Color.White;
            EndUp = false;
            PutPiece();
        }

        public void MovePiece(Position origin, Position target)
        {
            Piece piece = Board.removePiece(origin);
            piece.IncrementMoviment();
            Piece capturedPiece = Board.removePiece(target);
            Board.PutPiece(piece, target);
        }
        public void PerformingMove(Position origin, Position target)
        {
            MovePiece(origin, target);
            Rotation++;
            ChangePlayer();

        }

        private void ChangePlayer()
        {
            if(CurrentPlayer ==Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else { CurrentPlayer = Color.White; }
        }
        private void PutPiece()
        {
            Board.PutPiece(new Rook(Color.White, Board), new ChessPosition('a', 8).ToPosition());
            Board.PutPiece(new Rook(Color.White, Board), new ChessPosition('h', 8).ToPosition());

        }
    }
}
