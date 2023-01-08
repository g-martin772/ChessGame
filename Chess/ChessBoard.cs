namespace Chess;

public partial class ChessBoard : IChessBoard
{
	public (EFigure figure, bool isWhite)[,] Board { get; private set; }

	public (TimeOnly player1, TimeOnly player2) Time { get; private set; }
	public (Player player1, Player player2) Players { get; private set; }

	private ChessTiming timing;
	private EGameState gameState = EGameState.Paused;
	private bool whiteToMove;

	public EGameState GetGameStatus()
	{
		return gameState;
		// TODO: Implement game end system
	}

	public void Player(string player, string player2)
	{

	}

	public (string[] player1, string[] player2) GetMoveLog()
	{
		throw new NotImplementedException();
	}

	public void Init(Player player1, Player player2, ChessTiming timing)
	{
		this.timing = timing;
		Players = (player1, player2);
		Reset();
	}

	public void Reset()
	{
		Board = new (EFigure, bool)[8, 8];

		for (int i = 0; i < Board.GetLength(0); i++)
		{
			for (int j = 0; j < Board.GetLength(1); j++)
			{
				Board[i, j] = (EFigure.None, true);
			}
		}
		Board[0, 0] = (EFigure.Rook, true);
		Board[1, 0] = (EFigure.Knight, true);
		Board[2, 0] = (EFigure.Bishop, true);
		Board[3, 0] = (EFigure.King, true);
		Board[4, 0] = (EFigure.Queen, true);
		Board[5, 0] = (EFigure.Bishop, true);
		Board[6, 0] = (EFigure.Knight, true);
		Board[7, 0] = (EFigure.Rook, true);

		for (int i = 0; i < Board.GetLength(0); i++)
		{
			Board[i, 1] = (EFigure.P, true);
		}

		Board[0, 7] = (EFigure.Rook, false);
		Board[1, 7] = (EFigure.Knight, false);
		Board[2, 7] = (EFigure.Bishop, false);
		Board[3, 7] = (EFigure.King, false);
		Board[4, 7] = (EFigure.Queen, false);
		Board[5, 7] = (EFigure.Bishop, false);
		Board[6, 7] = (EFigure.Knight, false);
		Board[7, 7] = (EFigure.Rook, false);

		for (int i = 0; i < Board.GetLength(1); i++)
		{
			Board[i, 6] = (EFigure.P, false);
		}

		whiteToMove = true;
	}

	public void Start()
	{
		// TODO: Start timing thread
		gameState = EGameState.Playing;
	}
}
