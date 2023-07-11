using Chess;
namespace Console_Xadrez.Board
{
    internal class Screen
    {
        public static void PrintMatch(ChessMatch match)
        {
            
            Console.WriteLine();

            Console.WriteLine("Rotation: " + match.Rotation);
            if (!match.EndUp)
            {
                Console.WriteLine("Waiting for move: " + match.CurrentPlayer);
                Console.WriteLine();
                if (match.Check)
                {
                    Console.WriteLine("Check!");
                }
            }
            else
            {
                Console.WriteLine("Checkmate!");
                Console.WriteLine("Winner: "+match.CurrentPlayer);
            }
            
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
            PrintAggregate(match.CapturedPieces(Color.Black).ToHashSet());
            Console.ForegroundColor = aux;
            

            Console.WriteLine();
            Console.WriteLine();
        }
        public static void PrintAggregate(HashSet<Piece> aggregate)
        {
            Console.Write("[");
            foreach (Piece x in aggregate)
            {
                Console.Write(x + " ");
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
                    PrintPiece(board.Piece(i, j));
                    Console.BackgroundColor = desktopBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = desktopBackground;
        }


        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Line; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Colums; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }


        public static ChessPosition ReadPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }


        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("-");
            }
            else if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }

            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece + "");
                Console.ForegroundColor = aux;
            }
            Console.Write(" ");
        }

    }

}
