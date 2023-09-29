using Microsoft.AspNetCore.Components;
using Wordle.Data;

namespace Wordle.Pages.IndexComponent;

public class IndexComponent : ComponentBase
{
    private Words WordsService = new Words();

    public IList<Guesses> Guesses { get; set; } = new List<Guesses>();
    public Guesses Guess { get; set; } = new Guesses();
    public string Answer { get; set; }
    public bool Won { get; set; } = false;
    public bool Loss { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        await Load();
    }

    public async Task Load()
    {
        Answer = WordsService.GetRandomWord();
    }

    public async Task GuessRequest()
    {
        if (Guess.Value == Answer)
        {
            Won = true;
            return;
        }

        var i = 0;
        foreach (var letter in Guess.Value)
        {
            if (Answer.Contains(letter))
            {
                Guess.Contained.Add(letter.ToString());
                if (Answer[i] == letter)
                {
                    Guess.Contained.Remove(letter.ToString());
                    Guess.ContainedAndPlacement.Add(letter.ToString());
                }
            }

            i++;
        }
        Guesses.Add(Guess);
    }
}

