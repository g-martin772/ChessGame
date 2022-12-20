namespace Chess;

public class ChessBoard : IChessBoard
{
    public TimeOnly Time { get; private set; }

    public (EFigure, bool)[,] Board { get; private set; }

    public void Move(string notation)
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        Time = new TimeOnly();

        Board = new (EFigure, bool)[8, 8];

        for (int i = 0; i < Board.GetLength(0); i++)
        {
            for (int j = 0; j < Board.GetLength(1); j++)
            {
                Board[i, j] = (EFigure.None, true);
            }
        }
        Board[0, 0] = (EFigure.R, true);
        Board[1, 0] = (EFigure.N, true);
        Board[2, 0] = (EFigure.B, true);
        Board[3, 0] = (EFigure.K, true);
        Board[4, 0] = (EFigure.Q, true);
        Board[5, 0] = (EFigure.B, true);
        Board[6, 0] = (EFigure.N, true);
        Board[7, 0] = (EFigure.R, true);

        for (int i = 0; i < Board.GetLength(0); i++)
        {
            Board[i, 1] = (EFigure.P, true);
        }

        Board[0, 7] = (EFigure.R, false);
        Board[1, 7] = (EFigure.N, false);
        Board[2, 7] = (EFigure.B, false);
        Board[3, 7] = (EFigure.K, false);
        Board[4, 7] = (EFigure.Q, false);
        Board[5, 7] = (EFigure.B, false);
        Board[6, 7] = (EFigure.N, false);
        Board[7, 7] = (EFigure.R, false);

        for (int i = 0; i < Board.GetLength(1); i++)
        {
            Board[i, 6] = (EFigure.P, false);
        }
    }
}
