using System.Diagnostics;

namespace Chess;

public struct Square
{
    public int x;
    public int y;

    public Square(int x, int y)
    {
        if(x < 0 || y < 0) 
            throw new Exception("Square is out of bounds from the borad");

        if(x > 7 || y > 7) 
            throw new Exception("Square is out of bounds from the borad");

        this.x = x;
        this.y = y;
    }
}

public class Move
{
    public EFigure Piece { get; set; }
    public bool IsCapture { get; set; }
    public Square From { get; set; }
    public Square To { get; set; }
}

public partial class ChessBoard : IChessBoard
{
    public bool Move(Move move)
    {
        // TODO: Verify time is being set correctly
        if(Board[move.From.x, move.From.y].isWhite ? Time.player1.Second > 0 : Time.player2.Second > 0)
                return false;

        if(move.Piece != Board[move.From.x, move.From.y].figure)
            return false;

        if(!CheckMove(move)) 
            return false;

        // TODO: Check for a check
        // TODO: Check if target square was empty, if not add it to the taken list

        (Board[move.From.x, move.From.y], Board[move.To.x, move.To.y]) = ((EFigure.None, false), Board[move.From.x, move.From.y]);

        // TODO: Add to performed moves list or something like that
        // TODO: Check for draw or checkmate

        return true;
    }

    bool CheckMove(Move move)
    {
        switch (move.Piece)
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
        if(to.x - from.x != 1 || to.y - from.y != 1)
            return false;

        return true;
    }

    bool CheckPawnMove(Square from, Square to)
    {
        throw new NotImplementedException();
    }

    bool CheckQueenMove(Square from, Square to)
    {
        throw new NotImplementedException();
    }

    bool CheckRookMove(Square from, Square to)
    {
        throw new NotImplementedException();
    }

    bool CheckBishopMove(Square from, Square to)
    {
        throw new NotImplementedException();
    }

    bool CheckKnightMove(Square from, Square to)
    {
        throw new NotImplementedException();
    }
}