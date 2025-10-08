namespace TennisTracker.Models;

public class MatchItem
{
    public string Opponent { get; set; }
    public string Score { get; set; }
    public string Notes { get; set; }

    public MatchItem(string opponent, string score, string notes)
    {
        Opponent = opponent;
        Score = score;
        Notes = notes;
    }
}