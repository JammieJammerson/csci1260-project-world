using System;
using System.Collections.Generic;

public class GamerKeyGamertagComparer : IComparer<GamerKey>
{
    public int Compare(GamerKey x, GamerKey y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (x is null) return -1;
        if (y is null) return 1;
        return string.Compare(x.Gamertag, y.Gamertag, StringComparison.OrdinalIgnoreCase);
    }
}
