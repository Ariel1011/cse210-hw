public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Reference Reference { get { return _reference; } }

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public bool HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        if (visibleWords.Count == 0)
        {
            // No more words to hide.
            return false;
        }

        for (int i = 0; i < numberToHide && i < visibleWords.Count; i++)
        {
            int index = random.Next(0, visibleWords.Count);
            visibleWords[index].Hide();
        }

        return true;
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public string GetDisplayText()
    {
        string verseText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {verseText}";
    }

    public string GetChallengeText(bool wordsHidden)
    {
        if (wordsHidden)
        {
        
            return string.Join(" ", _words.Select(word => word.IsHidden() ? "_______" : word.GetDisplayText()));
        }
        else
        {
           
            return string.Join(" ", _words.Select(word => word.GetDisplayText()));
        }
    }
}
