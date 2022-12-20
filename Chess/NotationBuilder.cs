﻿namespace Chess;


public class NotationBuilder
{
    private const string RANKS = "12345678";
    private const string FILES = "abcdefgh";

    public string GetNotation(Move move)
    {
        string notation = move.Piece.ToString().ToLower();

        if (move.IsCapture)
        {
            notation += "x";
        }

        notation += FILES[move.To.x] + RANKS[move.To.y];

        //if (move.IsPromotion)
        //{
        //    notation += "=" + move.PromotionPiece.ToString().ToLower();
        //}

        return notation;
    }
}
