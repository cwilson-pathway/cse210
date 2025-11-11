class FractionHolder
{
    private int _numerator;
    private int _denominator;

    public void Fraction()
    {
        _numerator = 1;
        _denominator = 1;
        
    }

    public void Fraction(int wholeNumber)
    {
        _numerator = wholeNumber;
        _denominator = 1;
    }

    public void Fraction(int top, int bottom)
    {
        _numerator = top;
        _denominator = bottom;
    }

    public int GetTop()
    {
        return _numerator;
    }

    public void SetTop(int top)
    {
        _numerator = top;
    }

    public int GetBottom()
    {
        return _denominator;
    }

    public void SetBottom(int bottom)
    {
        _denominator = bottom;
    }

    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public double GetDecimalValue()
    {
        return Math.Round((double)_numerator / _denominator, 2);
    }
}