namespace Console_Xadrez.Board
{
    internal class Board
    {
        public int Line { get; set; }
        public int Colums { get; set; }
        private Piece[,] Pieces;

        //Contructs
        public Board(int line, int colums)
        {
            Line = line;
            Colums = colums;
            Pieces = new Piece[line, colums];
        }



        //Methods

        public Piece Piece(int line, int colums)// chamando peça por coordenadas
        {
            return Pieces[line, colums];
        }

        public Piece Piece(Position position)//Sobrecarga
        {
            return Pieces[position.Line, position.Column];
        }

        public void PutPiece(Piece piece, Position position)
        {
            if (OcuppiedPosition(position))
            {
                throw new BoardException("Invalid Position");
            }
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece (Position position)
        {
            if (Piece(position) == null)
            {
                return null;
            }
            Piece aux = Piece(position);
            aux.Position = null;
            Pieces[position.Line, position.Column] = null;
            return aux;
        }


        public bool ValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Line || position.Column < 0 || position.Column >= Colums)
            {
                return false;
            }
            return true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid Posiotion!");
            }
        }
        public bool OcuppiedPosition(Position position) // teste para saber se a posição contém alguma peça a ocupando
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }
    }
}
