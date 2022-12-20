using Chess;
using System.Text;

namespace Test;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        var n = new NotationBuilder();
        Move m = new Move();
        m.IsCapture = true;
        m.Piece = EFigure.K;
        m.From = new Square(0, 2);
        m.To = new Square(1, 2);
        Console.WriteLine(n.GetNotation(m));


        IChessBoard board = new ChessBoard();
        board.Reset();
        DrawChessBoard(board.Board);
    }

    public static void DrawChessBoard((EFigure, bool)[,] board)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                (EFigure figure, bool white) = board[j, i];
                if (white)
                    Console.ForegroundColor = ConsoleColor.White;
                else                                            // BackgroundColor fehlt -> mit Modulo
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.Write((char)(int)figure);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }
}
