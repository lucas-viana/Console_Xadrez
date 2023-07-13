using Console_Xadrez.Board;

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
        public bool Check { get; private set; }
        public Piece VulnerablePassing { get; private set; }


        public ChessMatch()
        {
            Board = new Board(8, 8);
            Rotation = 1;
            CurrentPlayer = Color.White;
            EndUp = false;
            Check = false;
            VulnerablePassing = null;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();

            PutPiece();
        }



        public Piece MovePiece(Position origin, Position target)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncrementMoviment();
            Piece capturedPiece = Board.RemovePiece(target);
            Board.PutPiece(piece, target);
            if (capturedPiece != null)
            {
                Captured.Add(capturedPiece);
            }
            // #SpecialMove castling small
            if (piece is King && target.Column == origin.Column + 2)
            {
                Position originK = new Position(origin.Line, origin.Column + 3);
                Position targetK = new Position(origin.Line, origin.Column + 1);
                Piece K = Board.RemovePiece(originK);
                K.IncrementMoviment();
                Board.PutPiece(K, targetK);
            }

            // #SpecialMove castling big
            if (piece is King && target.Column == origin.Column - 2)
            {
                Position originK = new Position(origin.Line, origin.Column - 4);
                Position targetK = new Position(origin.Line, origin.Column - 1);
                Piece K = Board.RemovePiece(originK);
                K.IncrementMoviment();
                Board.PutPiece(K, targetK);
            }

            //#SpecialMove En passant
            if (piece is Pawn)
            {
                if (origin.Column != target.Column && capturedPiece == null)
                {
                    Position positionPawn;
                    if (piece.Color == Color.White)
                    {
                        positionPawn = new Position(target.Line + 1, target.Column);
                    }
                    else
                    {
                        positionPawn = new Position(target.Line - 1, target.Column);
                    }
                    capturedPiece = Board.RemovePiece(positionPawn);
                    Captured.Add(capturedPiece);
                }
            }

            return piece;
        }

        public void PerformingMove(Position origin, Position target)
        {
            Piece capturedPiece = MovePiece(origin, target);
            if (InCheck(CurrentPlayer))
            {
                UndoMoviment(origin, target, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }
            
            Piece piece = Board.Piece(target);

            //#SpecialMove promotion
            if(piece is Pawn)
            {
                if((piece.Color == Color.White && target.Line == 0) || (piece.Color == Color.Black && target.Line == 7))
                {
                    piece = Board.RemovePiece(target);
                    Pieces.Remove(piece);
                    Piece quenn = new Queen(piece.Color, Board);
                    Board.PutPiece(quenn, target);
                    Pieces.Add(quenn);
                }
            }

            if (InCheck(Adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
            if (TestCheckmate(Adversary(CurrentPlayer)))
            {
                EndUp = true;
            }

            else
            {
                Rotation++;
                ChangePlayer();
            }
            

            // #SpecialMove en passsant
            if (piece is Pawn && (target.Line == origin.Line - 2 || target.Line == origin.Line + 2))
            {
                VulnerablePassing = piece;
            }
            else
            {
                VulnerablePassing = null;
            }

        }
        public void UndoMoviment(Position origin, Position target, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(target);
            piece.DecrementMoviment();
            if (capturedPiece != null)
            {
                Board.PutPiece(capturedPiece, target);
                Captured.Remove(capturedPiece);
            }
            Board.PutPiece(piece, origin);

            // #SpecialMove castling small
            if (piece is King && target.Column == origin.Column + 2)
            {
                Position originK = new Position(origin.Line, origin.Column + 3);
                Position targetK = new Position(origin.Line, origin.Column + 1);
                Piece K = Board.RemovePiece(targetK);
                K.DecrementMoviment();
                Board.PutPiece(K, originK);
            }

            // #SpecialMove castling big
            if (piece is King && target.Column == origin.Column - 2)
            {
                Position originK = new Position(origin.Line, origin.Column - 4);
                Position targetK = new Position(origin.Line, origin.Column - 1);
                Piece K = Board.RemovePiece(targetK);
                K.DecrementMoviment();
                Board.PutPiece(K, originK);
            }

            // #SpecialMove En passant
            if(piece is Pawn)
            {
                if(target.Column!= target.Column && capturedPiece == VulnerablePassing)
                {
                    Piece pawn = Board.RemovePiece(target);
                    Position positionPawn;
                    if(piece.Color == Color.White)
                    {
                        positionPawn = new Position(3, target.Column);
                    }
                    else
                    {
                        positionPawn = new Position(4, target.Column);
                    }
                    Board.PutPiece(pawn, positionPawn);
                }
            }
        }


        public void ValidateOriginPosition(Position origin)
        {
            if (Board.Piece(origin) == null)
            {
                throw new BoardException("There is no piece in this position on the board!");
            }
            if (CurrentPlayer != Board.Piece(origin).Color)
            {
                throw new BoardException("You cannot move a piece that is not your color!");
            }
            if (!Board.Piece(origin).TestPossibleMoves())
            {
                throw new BoardException("There are no possible moves for this piece");
            }
        }
        public void ValidateTargetPosition(Position origin, Position target)
        {
            if (!Board.Piece(origin).TestPossibleMovesTarget(target))
            {
                throw new BoardException("Invalid target position");
            }
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
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

        private static Color Adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }
        private Piece King(Color color)
        {
            foreach (Piece x in PiecesInGame(color))
            {
                if (x is King)
                {
                    return (x);
                }
            }
            return null;
        }

        public bool InCheck(Color color)
        {
            Piece K = King(color);
            if (K == null)
            {
                throw new BoardException("There is no " + color + " king on the board");
            }
            foreach (Piece x in PiecesInGame(Adversary(color)))
            {
                bool[,] mat = x.PossibleMoves();
                if (mat[K.Position.Line, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TestCheckmate(Color color)
        {
            if (!InCheck(color))
            {
                return false;
            }
            foreach (Piece x in PiecesInGame(color))
            {
                bool[,] mat = x.PossibleMoves();
                for (int i = 0; i < Board.Line; i++)
                {
                    for (int j = 0; j < Board.Colums; j++)
                    {
                        if (mat[i, j])
                        {
                            Position Origin = x.Position;
                            Position Target = new Position(i, j);
                            Piece CapturedPiece = MovePiece(Origin, Target);
                            bool TestCheck = InCheck(color);
                            UndoMoviment(Origin, Target, CapturedPiece);
                            if (!TestCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void PutNewPiece(char column, int line, Piece piece)
        {
            Board.PutPiece(piece, new ChessPosition(column, line).ToPosition());
            Pieces.Add(piece);
        }


        private void PutPiece()
        {

            //White
            PutNewPiece('a', 1, new Rook(Color.White, Board));
            PutNewPiece('b', 1, new Horse(Color.White, Board));
            PutNewPiece('c', 1, new Bishop(Color.White, Board));
            PutNewPiece('d', 1, new Queen(Color.White, Board));
            PutNewPiece('e', 1, new King(Color.White, Board, this));
            PutNewPiece('f', 1, new Bishop(Color.White, Board));
            PutNewPiece('g', 1, new Horse(Color.White, Board));
            PutNewPiece('h', 1, new Rook(Color.White, Board));

            PutNewPiece('a', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('b', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('c', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('d', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('e', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('f', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('g', 2, new Pawn(Color.White, Board, this));
            PutNewPiece('h', 2, new Pawn(Color.White, Board, this));

            //Black
            PutNewPiece('a', 8, new Rook(Color.Black, Board));
            PutNewPiece('b', 8, new Horse(Color.Black, Board));
            PutNewPiece('c', 8, new Bishop(Color.Black, Board));
            PutNewPiece('d', 8, new Queen(Color.Black, Board));
            PutNewPiece('e', 8, new King(Color.Black, Board, this));
            PutNewPiece('f', 8, new Bishop(Color.Black, Board));
            PutNewPiece('g', 8, new Horse(Color.Black, Board));
            PutNewPiece('h', 8, new Rook(Color.Black, Board));

            PutNewPiece('a', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('b', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('c', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('d', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('e', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('f', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('g', 7, new Pawn(Color.Black, Board, this));
            PutNewPiece('h', 7, new Pawn(Color.Black, Board, this));


        }
    }
}
