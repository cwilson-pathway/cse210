using System.Runtime.Versioning;

class Throbber
{
    // Runs a throbber animation. _seconds refers to the duration. _hasNewLine refers to functions
    // EnableNewLine and DisableNewLine. The former sets _hasNewLine to true and the latter sets it
    // to false.
    private List<char> _throbberAnimation = new List<char>(['\\', '|', '/', '—']);
    private int _seconds;
    private bool _hasNewLine;

    public Throbber()
    {
        _seconds = 0;
    }

    public Throbber(int seconds)
    {
        _seconds = seconds;
    }

    public void EnableNewLine()
    {
        _hasNewLine = true;
    }

    public void DisableNewLine()
    {
        _hasNewLine = false;
    }

    public void SetSeconds(int seconds)
    {
        _seconds = seconds;
    }

    public void Run()
    {
        DateTime futureTime = DateTime.Now.AddSeconds(_seconds);

        while (DateTime.Now <= futureTime)
        {
            foreach (char frame in _throbberAnimation)
            {
                Console.Write(frame);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }

        if (_hasNewLine)
        {
            Console.WriteLine();
        }
    }
}