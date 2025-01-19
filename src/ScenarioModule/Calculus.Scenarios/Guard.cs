namespace Calculus.Scenarios;

public static class Guard
{
    public static string AgainstNullOrEmpty(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException($"{nameof(value)} cannot be null or empty.");
        }

        return value;
    }
}
