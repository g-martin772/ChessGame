using Chess;
using System.Text;

namespace Test;

internal class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = Encoding.UTF8;

		ChessBoard board = new ChessBoard();
		board.Reset();
		Square pos = new(0, 0);
		Square selection = new(0, 0);
		bool selected = false;

		while (true)
		{
			// Give time for rendering console output before clearing
			Thread.Sleep(50);
			
			DrawChessBoard(board.Board, pos);

			switch (Console.ReadKey().Key)
			{
				case ConsoleKey.Enter:
					if (!selected)
					{
						selected = true;
						selection = pos;
					}
					else
					{
						selected = false;
						board.Move(new Move()
						{
							From = new(selection.x, selection.y),
							To = new(pos.x, pos.y)
						});
					}
					break;
				case ConsoleKey.LeftArrow:
					if(pos.x > 0)
						pos.x--;
					break;
				case ConsoleKey.DownArrow:
					if(pos.y < 7)
						pos.y++;
					break;
				case ConsoleKey.RightArrow:
					if(pos.x < 7)
						pos.x++;
					break;
				case ConsoleKey.UpArrow:
					if(pos.y > 0)
						pos.y--;
					break;
			}

			Console.Clear();
		}
	}

	public static void DrawChessBoard((EFigure, bool)[,] board, Square pos)
	{
		for (int i = 0; i < board.GetLength(0); i++)
		{
			for (int j = 0; j < board.GetLength(1); j++)
			{
				(EFigure figure, bool white) = board[j, i];
				if(pos.x == j && pos.y == i)
					Console.BackgroundColor = ConsoleColor.Red;
				else if (i % 2 == 0 ? j % 2 == 0 : j % 2 == 1)
					Console.BackgroundColor = ConsoleColor.DarkYellow;
				else
					Console.BackgroundColor = ConsoleColor.DarkGray;

				if (white)
					Console.ForegroundColor = ConsoleColor.White;
				else
					Console.ForegroundColor = ConsoleColor.Black;

				Console.Write((char)figure);
				Console.Write(' ');
				Console.ResetColor();
			}
			Console.WriteLine();
		}
	}
}
