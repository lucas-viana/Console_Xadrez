using board;
using Chess;

namespace Console_Xadrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChessPosition position = new ChessPosition('c',7);
            Console.WriteLine(position);
            Console.WriteLine(position.ToPosition());
        }
    }
}/* try
            {
                Board board = new Board(8, 8);

                board.PutPiece(new Rook(Color.Black, board), new Position(0, 0));
                board.PutPiece(new Rook(Color.Black, board), new Position(0, 9));
                board.PutPiece(new Horse(Color.Black, board), new Position(0, 1));
                board.PutPiece(new Horse(Color.Black, board), new Position(0, 6));
                board.PutPiece(new Bishop(Color.Black, board), new Position(0, 2));
                board.PutPiece(new Bishop(Color.Black, board), new Position(0, 5));
                board.PutPiece(new King(Color.Black, board), new Position(0, 3));
                board.PutPiece(new Queen(Color.Black, board), new Position(0, 4));
                for (int i = 0; i < 8; i++)
                {
                    board.PutPiece(new Pawn(Color.Black, board), new Position(1, i));
                }

                board.PutPiece(new Rook(Color.Black, board), new Position(7, 0));
                board.PutPiece(new Rook(Color.Black, board), new Position(7, 7));
                board.PutPiece(new Horse(Color.Black, board), new Position(7, 1));
                board.PutPiece(new Horse(Color.Black, board), new Position(7, 6));
                board.PutPiece(new Bishop(Color.Black, board), new Position(7, 2));
                board.PutPiece(new Bishop(Color.Black, board), new Position(7, 5));
                board.PutPiece(new King(Color.Black, board), new Position(7, 3));
                board.PutPiece(new Queen(Color.Black, board), new Position(7, 4));
                for (int i = 0; i < 8; i++)
                {
                    board.PutPiece(new Pawn(Color.Black, board), new Position(6, i));
                }

                Screen.printBoard(board);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }*/