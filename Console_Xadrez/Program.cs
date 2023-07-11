using Chess;
using Console_Xadrez.Board;
namespace Console_Xadrez
{

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();


                while (!match.EndUp)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintBoard(match.Board);
                        Console.WriteLine();
                        Screen.PrintCapturedPieces(match);
                        Screen.PrintMatch(match);
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadPosition().ToPosition();
                        match.ValidateOriginPosition(origin);
                        bool[,] PossiblePosition = match.Board.Piece(origin).PossibleMoves();
                        Console.Clear();
                        Screen.PrintBoard(match.Board, PossiblePosition);

                        Console.Write("Target: ");
                        Position target = Screen.ReadPosition().ToPosition();
                        match.ValidateTargetPosition(origin, target);
                        match.PerformingMove(origin, target);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }

                }
                Console.Clear();
                Screen.PrintMatch(match);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            /*Position position = new 
            ChessPosition position = new ChessPosition('c',7);
            Console.WriteLine(position);
            Console.WriteLine(position.ToPosition());*/
        }
    }
}