using Chess;
namespace Console_Xadrez.Board
{
    internal class Screen
    {
        public static void PrintBoard(Board board)
        {

            for (int i = 0; i < board.Line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Colums; j++)
                {
                    if (board.piece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Screen.PrintPiece(board.piece(i, j));
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public static ChessPosition ReadPosition()
        {
            string s = Console.ReadLine();
            char ch = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(ch, line);
        }
        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece + " ");
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece + " ");
                Console.ForegroundColor = aux;
            }
        }

    }

}
