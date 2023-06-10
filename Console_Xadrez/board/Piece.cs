namespace board
{
    internal class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public  int NumMoviment { get; set; }
        public Board Board { get; set; }
        
        public Piece (Position position, Color color,Board board)
        {
            Position = position;
            Color = color;
            Board = board;
            NumMoviment = 0;
        }
    }

    

    //Contructs

   
}
