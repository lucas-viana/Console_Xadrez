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

                    Console.Clear();
                    Screen.PrintBoard(match.Board);
                    Console.WriteLine();
                    Console.WriteLine("Turno: + "+match.Rotation);
                    Console.WriteLine("Aguardando jogada"+match.CurrentPlayer);
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadPosition().ToPosition();

                    bool[,] PossiblePosition = match.Board.piece(origin).PossibleMoves();
                    Console.Clear();
                    Screen.PrintBoard(match.Board,PossiblePosition);

                    Console.Write("Target: ");
                    Position target = Screen.ReadPosition().ToPosition();
                    match.PerformingMove(origin, target);

                }


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