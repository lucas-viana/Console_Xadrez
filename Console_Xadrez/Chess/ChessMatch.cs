using Console_Xadrez.Board;
using System.Collections.Generic;

namespace Chess
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Rotation { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool EndUp { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public ChessMatch()
        {
            Board = new Board(8, 8);
            Rotation = 1;
            CurrentPlayer = Color.White;
            EndUp = false;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            PutPiece();
        }

        public void MovePiece(Position origin, Position target)
        {
            Piece piece = Board.removePiece(origin);
            piece.IncrementMoviment();
            Piece capturedPiece = Board.removePiece(target);
            Board.PutPiece(piece, target);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
        }
        public void PerformingMove(Position origin, Position target)
        {
            MovePiece(origin, target);
            Rotation++;
            ChangePlayer();

        }

        public void ValidateOriginPosition(Position origin)
        {
            if (Board.piece(origin) != null)
            {
                throw new BoardException("There is no piece in this position on the board!");
            }
            if (CurrentPlayer != Board.piece(origin).Color)
            {
                throw new BoardException("You cannot move a piece that is not your color!");
            }
            if (!Board.piece(origin).TestPossibleMoves() != true)
            {
                throw new BoardException("There are no possible moves for this piece");
            }
        }
        public void ValidateTargetPosition(Position origin, Position target)
        {
            if (!Board.piece(origin).TestPossibleMovesTarget(target))
            {
                throw new BoardException("Invalid target position");
            }
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in Captured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame (Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }


        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else { CurrentPlayer = Color.White; }
        }
        public void PutNewPiece(char column, int line, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }
        private void PutPiece()
        {
            PutNewPiece('c', 1, new Rook(Color.White, Board));
            PutNewPiece('c', 2, new Rook(Color.White, Board));

        }
    }
}
