class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Constructor for if there is only one verse.
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }
    
    // Constructor for if there is a verse range.
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    // Returns a formatted Reference object.
    public string GetDisplayText()
    {
        // If _endVerse has a value, display like "Book 1:1-2". Else, display like "Book 1:1".
        string referenceText;

        if (_endVerse != 0)
        {
            referenceText = $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        else
        {
            referenceText = $"{_book} {_chapter}:{_verse}";
        }
        return referenceText;
    }
}