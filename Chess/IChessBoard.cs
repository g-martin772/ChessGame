namespace Chess;

public enum EGameState
{
    Playing,
    Draw,
    WonByWhite,
    WonByBlack
}

public class Player
{
    public string Name { get; private set; }
    public int Elo { get; private set; }
    public int Age { get; private set; }
    public string Nationality { get; private set; }
    public int Wins { get; private set; }

    public Player()
    {
        try
        {
            Console.WriteLine("Name: ");
            Name = Console.ReadLine();
            Console.WriteLine("Alter: ");
            Age = Convert.ToInt32(Console.ReadLine());
            if (Age <= 0)
                throw new Exception("Alter kann nicht kleiner gleich null sein!");
            Console.WriteLine("Nationalität: "); 
            Nationality = Console.ReadLine();
            //Hardcode vorerst
            Console.WriteLine("Elo: ");
            Elo = Convert.ToInt32(Console.ReadLine());
            if (Elo < 0)
                throw new Exception("Elo kann nicht kleiner als null sein!");
            Console.WriteLine("Gewinne: ");
            Wins = Convert.ToInt32(Console.ReadLine());
            if (Wins < 0)
                throw new Exception("Gewinne können nicht kleiner als null sein!");

        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

public interface IChessBoard
{
    TimeOnly Time { get; }
    (EFigure, bool)[,] Board { get; }
    void Reset();
    // void Init(Player player1, Player player2, TimeOnly timing);
    void Move(string notation);
    // (int x, int y)[] GetMovesFor(string notation);
    // (string[], string[]) GetMoveLog();
    // event CheckHandler Check;
    // event EventHandler GameEnd;
}

public delegate void CheckHandler(bool player);
public delegate void GameEndHandler(EGameState state);