using Console_Xadrez.Board;

namespace Chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        private int Rotation;
        private Color CurrentPlayer;
        public bool EndUp { get; private set; }
        public ChessMatch()
        {
            Board = new Board(8,8);
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
        private void PutPiece()
        {
            Board.PutPiece(new Rook(Color.White, Board), new ChessPosition('a', 8).ToPosition());
            Board.PutPiece(new Rook(Color.White, Board), new ChessPosition('h', 8).ToPosition());
            
        }
    }
}
