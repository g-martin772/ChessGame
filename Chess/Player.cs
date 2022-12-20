namespace Chess;

public class Player
{
    public string Name { get; private set; }
    public int Elo { get; private set; }
    public int Age { get; private set; }
    public string Nationality { get; private set; }
    public int Wins { get; private set; }

    public Player(string name = "player", int elo = 100, int age = 10, string nationality = "austria", int wins = 0)
    {
        Name = name;
        Elo = elo;
        Age = age;
        Nationality = nationality;
        Wins = wins;
    }
}