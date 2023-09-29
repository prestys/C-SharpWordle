namespace Wordle.Data;

public class Guesses
{
    public string Value { get; set; }
    public List<string> Contained { get; set; } = new List<string>();
    public List<string> ContainedAndPlacement { get; set; } = new List<string>();
}