using System;

public struct Fraction
{
    private long mNumerator; //чисельник
    private long mDenominator; //знаменник
    public Fraction(long aNumerator, long aDenominator)
    {
        // Cancel the fraction and make the denominator positive
        long gcd = GreatestCommonDivisor(aNumerator, aDenominator);
        mNumerator = aNumerator / gcd;
        mDenominator = aDenominator / gcd;
        if (mDenominator < 0)
        {
            mNumerator = -mNumerator;
            mDenominator = -mDenominator;
        }
    }
    private static long GreatestCommonDivisor(long aNumber1, long aNumber2)
    {
        aNumber1 = Math.Abs(aNumber1);
        aNumber2 = Math.Abs(aNumber2); while (aNumber1 > 0)
        {
            long newNumber1 = aNumber2 % aNumber1; aNumber2 = aNumber1;
            aNumber1 = newNumber1;
        }
        return aNumber2;
    }
    public static Fraction operator +(Fraction aF1, Fraction aF2)
    {
        long num = aF1.mNumerator * aF2.mDenominator + aF2.mNumerator * aF1.mDenominator;
        long denom = aF1.mDenominator * aF2.mDenominator;
        return new Fraction(num, denom);
    }
    public static Fraction operator -(Fraction aF1, Fraction aF2)
    {
        long num = aF1.mNumerator * aF2.mDenominator - aF2.mNumerator * aF1.mDenominator;
        long denom = aF1.mDenominator * aF2.mDenominator;
        return new Fraction(num, denom);
    }
    public static Fraction operator *(Fraction aF1, Fraction aF2)
    {
        long num = aF1.mNumerator * aF2.mNumerator;
        long denom = aF1.mDenominator * aF2.mDenominator;
        return new Fraction(num, denom);
    }
    public static Fraction operator /(Fraction aF1, Fraction aF2)
    {
        long num = aF1.mNumerator * aF2.mDenominator;
        long denom = aF1.mDenominator * aF2.mNumerator;
        return new Fraction(num, denom);
    }
    // Unary minus operator
    public static Fraction operator -(Fraction aFrac)
    {
        long num = -aFrac.mNumerator;
        long denom = aFrac.mDenominator;
        return new Fraction(num, denom);
    }
    // Explicit conversion to double operator
    public static explicit operator double(Fraction aFrac)
    {
        return (double)aFrac.mNumerator / aFrac.mDenominator;
    }
    //Operator ++ (the same for prefix and postfix form)
    public static Fraction operator ++(Fraction aFrac)
    {
        long num = aFrac.mNumerator + aFrac.mDenominator;
        long denom = aFrac.mDenominator;
        return new Fraction(num, denom);
    }
    //Operator -- (the same for prefix and postfix form)
    public static Fraction operator --(Fraction aFrac)
    {
        long num = aFrac.mNumerator - aFrac.mDenominator;
        long denom = aFrac.mDenominator;
        return new Fraction(num, denom);
    }
    public static bool operator true(Fraction aFraction)
    {
        return aFraction.mNumerator != 0;
    }
    public static bool operator false(Fraction aFraction)
    {
        return aFraction.mNumerator == 0;
    }
    public static implicit operator Fraction(double aValue)
    {
        double num = aValue; long denom = 1;
        while (num - Math.Floor(num) > 0)
        {
            num = num * 10; denom = denom * 10;
        }
        return new Fraction((long)num, denom);
    }
    public override string ToString()
    {
        if (mDenominator != 0)
        {
            return String.Format("{0}/{1}", mNumerator, mDenominator);
        }
        else
        {
            return ("NAN"); // not а number
        }
    }
}
class FractionsTest
{
    static void Main()
    {
        Fraction f1 = (double)1 / 4;
        Console.WriteLine("f1 = {0}", f1);
        Fraction f2 = (double)7 / 10;
        Console.WriteLine("f2 = {0}", f2);
        Console.WriteLine("-f1 = {0}", -f1);
        Console.WriteLine("f1 + f2 = {0}", f1 + f2);
        Console.WriteLine("f1 - f2 = {0}", f1 - f2);
        Console.WriteLine("f1 * f2 = {0}", f1 * f2);
        Console.WriteLine("f1 / f2 = {0}", f1 / f2);
        Console.WriteLine("f1 / f2 as double = {0}", (double)(f1 / f2));
        Console.WriteLine("-(f1+f2)*(f1-f2/f1) = {0}", -(f1 + f2) * (f1 - f2 / f1));
    }
}
