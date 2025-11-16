class Scripture
{
    private Reference _reference = new Reference("",0,0);
    private List<Word> _words = new List<Word>();
    private List<int> _previousIndices = new List<int>();

    // Constructs new scripture object
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] textArray = text.Split(" ");

        foreach (string word in textArray)
        {
            _words.Add(new Word(word));
        }
    }
    
    // Hides 2 - 5 random words, because the program will sometimes attempt to hide the verse number.
    public void HideRandomWords(int numberToHide)
    {
        _previousIndices.Clear();
        for (int i = 0; i < numberToHide; i++)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, _words.Count);
            Word selectedWord = _words[randomIndex];
            while (selectedWord.IsHidden() == true)
            {
                randomIndex = random.Next(0, _words.Count);
                selectedWord = _words[randomIndex];
            } 
            _previousIndices.Add(randomIndex);
            selectedWord.Hide();
        }
    }

    // Displays whole scripture by formatting _words.
    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + "\n";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText;
    }

    // Checks if the scriputure is completely hidden.
    public bool IsCompletelyHidden()
    {
        int hiddenCounter = 0;
        int verseNumberCounter = 0;
        bool isCompletelyHidden;

        // Increments hiddenCounter for each hidden word. If it encounters a integer, it's likely a verse number.
        // Ergo, it will increment verseNumberCounter.
        foreach (Word word in _words)
        {
            char c = word.GetDisplayText()[0];
            if (word.IsHidden())
            {
                hiddenCounter++;
            }
            else if (Char.IsDigit(c))
            {
                verseNumberCounter++;
            }
        }

        // Compares against _words.Count - verseNumberCounter because the verse number isn't ever supposed to be hidden.
        if (hiddenCounter == _words.Count - verseNumberCounter)
        {
            isCompletelyHidden = true;
        }
        else
        {
            isCompletelyHidden = false;
        }
        return isCompletelyHidden;
    }

    public void ShowAll()
    {
        // Reveals the entire scripture text without exiting the application.
        foreach (Word word in _words)
        {
            word.Show();
        }
    }

    public void ShowPrevious()
    {
        foreach (int i in _previousIndices)
        {
            _words[i].Show();
        }
    }
}