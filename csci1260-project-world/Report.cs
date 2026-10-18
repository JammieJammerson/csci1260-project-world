using System;

public static class Report
{
    public static void Print(string content)
    {
        if (string.IsNullOrEmpty(content)) return;
        Console.WriteLine(content);
    }
}
