using System.Diagnostics;
using System.Security.Cryptography;

namespace Chess;

public struct Square
{
	public int x;
	public int y;

	public Square(int x, int y)
	{
		if (x < 0 || y < 0)
			throw new Exception("Square is out of bounds from the borad");

		if (x > 7 || y > 7)
			throw new Exception("Square is out of bounds from the borad");

		this.x = x;
		this.y = y;
	}
}

public class Move
{
	public Square From { get; set; }
	public Square To { get; set; }
}

public partial class ChessBoard : IChessBoard
{
	public bool Move(Move move)
	{
		// TODO: Verify time is being set correctly
		//if (Board[move.From.x, move.From.y].isWhite ? Time.player1.Second > 0 : Time.player2.Second > 0)
		//    return false;

		if (!CheckMove(move))
			return false;

		// TODO: Check for a check
		if (Board[move.To.x, move.To.y].isWhite == Board[move.From.x, move.From.y].isWhite && Board[move.To.x, move.To.y].figure != EFigure.None)
			return false;

		(Board[move.From.x, move.From.y], Board[move.To.x, move.To.y]) = ((EFigure.None, false), Board[move.From.x, move.From.y]);

		// TODO: Add to performed moves list or something like that
		// TODO: Check for draw or checkmate

		return true;
	}

	bool CheckMove(Move move)
	{
		switch (Board[move.From.x, move.From.y].figure)
		{
			case EFigure.None: return false;
			case EFigure.King: return CheckKingMove(move.From, move.To);
			case EFigure.Queen: return CheckQueenMove(move.From, move.To);
			case EFigure.Rook: return CheckRookMove(move.From, move.To);
			case EFigure.Knight: return CheckKnightMove(move.From, move.To);
			case EFigure.Bishop: return CheckBishopMove(move.From, move.To);
			case EFigure.Pawn: return CheckPawnMove(move.From, move.To);
			default: throw new UnreachableException();
		}
	}

	public Move[] GetMovesFor(string notation)
	{
		throw new NotImplementedException();
	}

	bool CheckKingMove(Square from, Square to)
	{
		if (to.x - from.x > 1 || to.y - from.y > 1)
			return false;

		return true;
	}

	bool CheckPawnMove(Square from, Square to)
	{
		if (Board[from.x, from.y] == (EFigure.Pawn, true))
		{
			if (from.x == to.x && from.y == to.y - 1 && Board[to.x, to.y].figure == EFigure.None)
				return true;

			if (from.y == 1 && from.x == to.x && from.y == to.y - 2 && Board[to.x, to.y].figure == EFigure.None)
				return true;

			if ((from.x == to.x + 1 || from.x == to.x - 1) && from.y == to.y - 1 && !Board[to.x, to.y].isWhite)
				return true;
		}
		else
		{
			if (from.x == to.x && from.y == to.y + 1 && Board[to.x, to.y].figure == EFigure.None)
				return true;

			if (from.y == 6 && from.x == to.x && from.y == to.y + 2 && Board[to.x, to.y].figure == EFigure.None)
				return true;

			if ((from.x == to.x + 1 || from.x == to.x - 1) && from.y == to.y + 1 && Board[to.x, to.y].isWhite)
				return true;
		}

		return false;
	}

	bool CheckQueenMove(Square from, Square to)
	{
		// Wagrecht
		if (from.y == to.y)
		{
			int shiftX = to.x > from.x ? 1 : -1;
			for (int i = from.x + shiftX; i != to.x; i += shiftX)
			{
				if (Board[i, to.y].figure != EFigure.None)
					return false;
			}
			return true;
		}

		// Senkrecht
		if (from.x == to.x)
		{
			int shiftY = to.y > from.y ? 1 : -1;
			for (int i = from.y + shiftY; i != to.y; i += shiftY)
			{
				if (Board[to.x, i].figure != EFigure.None)
					return false;
			}
			return true;
		}

		// Diagonal
		if (from.x - from.y == to.x - to.y || from.y + from.x == to.x + to.y)
		{
			int shiftX = to.x > from.x ? 1 : -1;
			int shiftY = to.y > from.y ? 1 : -1;
			for (Square check = new Square(from.x + shiftX, from.y + shiftY); check.x != to.x;)
			{
				if (Board[check.x, check.y].figure != EFigure.None)
					return false;
				check.x += shiftX;
				check.y += shiftY;
			}
			return true;
		}

		return false;
	}

	bool CheckRookMove(Square from, Square to)
	{
		if (from.x == to.x)
		{
			int shiftY = to.y > from.y ? 1 : -1;
			for (int i = from.y + shiftY; i != to.y; i += shiftY)
			{
				if (Board[to.x, i].figure != EFigure.None)
					return false;
			}
			return true;
		}

		if (from.y == to.y)
		{
			int shiftX = to.x > from.x ? 1 : -1;
			for (int i = from.x + shiftX; i != to.x; i += shiftX)
			{
				if (Board[i, to.y].figure != EFigure.None)
					return false;
			}
			return true;
		}

		return false;
	}

	bool CheckBishopMove(Square from, Square to)
	{
		if (from.x - from.y == to.x - to.y || from.y + from.x == to.x + to.y)
		{
			int shiftX = to.x > from.x ? 1 : -1;
			int shiftY = to.y > from.y ? 1 : -1;
			for (Square check = new Square(from.x + shiftX, from.y + shiftY); check.x != to.x;)
			{
				if (Board[check.x, check.y].figure != EFigure.None)
					return false;
				check.x += shiftX;
				check.y += shiftY;
			}
			return true;
		}

		return false;
	}

	bool CheckKnightMove(Square from, Square to)
	{
		int shiftX = to.x > from.x ? -1 : 1;
		int shiftY = to.y > from.y ? -1 : 1;
		if ((from.x - to.x) == shiftX * 2 && (from.y - to.y) == shiftY 
			|| (from.x - to.x) == shiftX && (from.y - to.y) == shiftY * 2)
			return true;
		return false;
	}
}
