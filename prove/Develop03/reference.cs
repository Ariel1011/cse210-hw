public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

public Reference(string book, int chapter, int verse)
{
    _book = book;
    _chapter = chapter;
    _verse = verse;
    _endVerse = verse; 
}

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

public static Reference Parse(string referenceText)
{
    string[] parts = referenceText.Split(':');
    if (parts.Length != 2)
    {
        throw new ArgumentException("Invalid reference format");
    }

    string bookChapterPart = parts[0];
    string versePart = parts[1];

    string[] bookChapterParts = bookChapterPart.Split(' ');
    if (bookChapterParts.Length != 2)
    {
        throw new ArgumentException("Invalid reference format");
    }

    string book = bookChapterParts[0];
    int chapter;
    if (!int.TryParse(bookChapterParts[1], out chapter))
    {
        throw new ArgumentException("Invalid chapter format");
    }

    int startVerse;
    int endVerse;

    if (versePart.Contains("-"))
    {
        string[] verseParts = versePart.Split('-');
        if (verseParts.Length != 2 ||
            !int.TryParse(verseParts[0], out startVerse) ||
            !int.TryParse(verseParts[1], out endVerse))
        {
            throw new ArgumentException("Invalid verse range format");
        }
    }
    else
    {
        if (!int.TryParse(versePart, out startVerse))
        {
            throw new ArgumentException("Invalid verse format");
        }

        endVerse = startVerse;
    }

    return new Reference(book, chapter, startVerse, endVerse);
    
}

    public string GetDisplayText()
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}
