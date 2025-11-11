using System;

class Program
{
    static void Main(string[] args)
    {
        FractionHolder fraction = new FractionHolder();
        fraction.Fraction();
        Console.WriteLine(fraction.GetFractionString());

        fraction.Fraction(6);
        Console.WriteLine(fraction.GetFractionString());

        fraction.Fraction(6, 7);
        Console.WriteLine(fraction.GetFractionString());

        fraction.SetTop(3);
        Console.WriteLine(fraction.GetTop());

        fraction.SetBottom(4);
        Console.WriteLine(fraction.GetBottom());

        Console.WriteLine($"{fraction.GetFractionString()} is equal to {fraction.GetDecimalValue()}");
    }
}