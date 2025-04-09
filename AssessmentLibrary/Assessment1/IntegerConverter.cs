namespace AssessmentLibrary.Assessment1;

internal class IntegerConverter
{
    private static readonly Dictionary<int,string> CodeValues = Enumerable.Range(MinValue, MaxValue + 1)
        .ToDictionary(v => v, v => char.ConvertFromUtf32(456 + v));

    public static int MinValue => byte.MinValue;
    public static int MaxValue => byte.MaxValue;

    public static string Convert(int value)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(value, MaxValue);
        ArgumentOutOfRangeException.ThrowIfLessThan(value, MinValue);

        // Make this an "expensive" conversion
        Thread.Sleep(20);
        return CodeValues[value];
    }
}