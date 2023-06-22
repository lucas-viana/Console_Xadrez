using Chess;
namespace Console_Xadrez.Board
{
    internal class Screen
    {
        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.Board);
            Console.WriteLine();
            Cap
            Console.WriteLine("Turno: " + match.Rotation);
            Console.WriteLine("Aguardando jogada: " + match.CurrentPlayer);
        }
        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
           PrintAggregate(match.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = aux;
            PrintAggregate(match.CapturedPieces(Color.Black).ToHashSet());

            Console.WriteLine();
        }
        public static void PrintAggregate(HashSet<Piece> aggregate)
        {
            Console.Write("[");
            foreach(Piece x in aggregate)
            {
                Console.Write(x+" ");
            }
            Console.Write("]");
        }
        public static void PrintBoard(Board board, bool[,] PossiblePosition)
        {
            ConsoleColor desktopBackground = Console.BackgroundColor;
            ConsoleColor desktopChanged = ConsoleColor.DarkGray;
            for (int i = 0; i < board.Line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Colums; j++)
                {
                    if (PossiblePosition[i, j])
                    {
                        Console.BackgroundColor = desktopChanged;
                    }
                    else
                    {
                        Console.BackgroundColor = desktopBackground;
                    }
                    PrintPiece(board.piece(i, j));
                    Console.BackgroundColor = desktopBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = desktopBackground;
        }


        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Colums; j++)
                {
                    PrintPiece(board.piece(i, j));
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
            if (piece == null)
            {
                Console.Write("- ");
            }
            else if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }

            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece + " ");
                Console.ForegroundColor = aux;
            }
            Console.Write(" ");
        }

    }

}
