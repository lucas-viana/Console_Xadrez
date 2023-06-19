using Chess;
using Console_Xadrez.Board;
namespace Console_Xadrez.Board
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
                    Console.Write("Origin: "); 
                    Position origin = Screen.ReadPosition().ToPosition();
                    Console.Write("Target");
                    Position target = Screen.ReadPosition().ToPosition();
                    match.MovePiece(origin, target);

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