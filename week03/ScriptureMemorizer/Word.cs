class Word
{
    private string _text;
    private bool _isHidden;
    private string _showWord;

    // Constructs Word object
    public Word(string text)
    {
        _text = text;
        _showWord = text;
    }

    // Hides word character by character.
    public void Hide()
    {
        string hiddenText = "";

        // If the character is a newline, punctuation, or number (because the only numbers appearing in the scripture pool are verse numbers), don't hide it.
        // Else, hide the character.
        foreach (char c in _text)
        {
            if (c == '\n' || Char.IsPunctuation(c) || Char.IsNumber(c))
            {
                hiddenText += c;
            }
            else
            {
                hiddenText += "_";
            }
        }
        _text = hiddenText;
    }

    // Restores the word to the state it was before it was hidden.
    public void Show()
    {
        _text = _showWord;
    }

    // Checks if a word is hidden.
    public bool IsHidden()
    {
        // If the first character in the word is newline, check the second for being an underscore. Else, check for an underscore in the first character.
        // If there is no underscore character present in the first/second character, the word is not hidden.
        if (_text[0] == '\n')
        {
            if (_text[1] == '_')
            {
                _isHidden = true;
            }
        }
        else if (_text[0] == '_')
        {
            _isHidden = true;
        }
        else
        {
            _isHidden = false;
        }
        return _isHidden;
    }

    // Returns _text.
    public string GetDisplayText()
    {
        return _text;
    }
}