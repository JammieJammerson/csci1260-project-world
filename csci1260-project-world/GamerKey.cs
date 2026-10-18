using System;

public sealed record GamerKey(string Name, string Gamertag) : IComparable<GamerKey>
{
    public int CompareTo(GamerKey other)
    {
        if (other == null) return 1;
        int c = string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        if (c != 0) return c;
        return string.Compare(Gamertag, other.Gamertag, StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString() => $"{Name} ({Gamertag})";
}
