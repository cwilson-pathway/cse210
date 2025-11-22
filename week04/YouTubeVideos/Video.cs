using System.Globalization;
using System.Transactions;

class Video
{
    private string _author;
    private string _title;
    private int _lengthSeconds;
    private int _numberOfComments;
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
    }

    public string GetVideoSpec()
    {
        // Grab number of comments
        _numberOfComments = _comments.Count;
    
        // Print all spec.
        return $"Title: {_title} \nAuthor: {_author} \nLength (in seconds): {_lengthSeconds} \nNumber of Comments: {_numberOfComments}";
    }

    public string GetAllComments()
    {
        // Grab all comments and store them in a string
        string commentString = "";
        foreach (Comment comment in _comments)
        {
            commentString += $"\n{comment.GetDisplayText()}";
        }

        return commentString;
    }

    public void AddComment(string name, string text)
    {
        _comments.Add(new Comment(name, text));
    }

}