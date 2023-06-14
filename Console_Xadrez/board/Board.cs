using board;

namespace board
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

        public Piece piece(int line, int colums)// chamando peça por coordenadas
        {
            return Pieces[line, colums];
        }

        public Piece piece(Position position)//Sobrecarga
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
            return piece(position) != null;
        }
    }
}
