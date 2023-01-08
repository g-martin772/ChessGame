namespace Chess;

public enum EGameState
{
	Playing,
	Draw,
	WonByWhite,
	WonByBlack,
	Paused
}

public struct ChessTiming
{
	public TimeOnly time;
	public short gain;
	public ChessTiming(TimeOnly time, short gain = 0)
	{
		this.time = time;
		this.gain = gain;
	}
}

public interface IChessBoard
{
	(TimeOnly player1, TimeOnly player2) Time { get; }
	(Player player1, Player player2) Players { get; }
	(EFigure figure, bool isWhite)[,] Board { get; }
	void Reset();
	void Init(Player player1, Player player2, ChessTiming timing);
	void Start();
	bool Move(Move move);
	Move[] GetMovesFor(string notation);
	(string[] player1, string[] player2) GetMoveLog();
	EGameState GetGameStatus();
}
