using System;
using System.IO;

public class Logger : IDisposable
{
    private readonly string path;
    private StreamWriter writer;
    private bool disposed = false;

    public Logger(string path)
    {
        this.path = path ?? "log.txt";
        writer = new StreamWriter(this.path, append: false);
        writer.WriteLine("Log start: " + DateTime.Now);
        writer.Flush();
    }

    public void Log(string line)
    {
        if (disposed) throw new ObjectDisposedException(nameof(Logger));
        writer.WriteLine(line);
        writer.Flush();
    }

    public void Dispose()
    {
        if (disposed) return;
        disposed = true;
        try
        {
            if (writer != null)
            {
                writer.WriteLine("Log end: " + DateTime.Now);
                writer.Flush();
                writer.Dispose();
                writer = null;
            }
        }
        catch
        {
        }
    }
}
