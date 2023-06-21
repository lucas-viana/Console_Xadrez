﻿namespace Console_Xadrez.Board
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
        public abstract bool[,] PossibleMoves();
        
    }






}
