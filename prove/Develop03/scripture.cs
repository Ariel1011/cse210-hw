public class Scripture

{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, List<Word> words)
    {
        _reference = reference;
        _words = words;
    }

    public void HideRandomWords(int numberToHide)
    {
        
    }

    public string GetDisplayText()
    {

        return string.Join(" ", _words.Where(word => !word.IsHidden()).Select(word => word.GetDisplayText()));
    }

    public bool IsCompletelyHidden()
    {

        return _words.All(word => word.IsHidden());
    }
}