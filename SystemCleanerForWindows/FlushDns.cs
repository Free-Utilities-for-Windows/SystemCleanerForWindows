using System.Diagnostics;

namespace ForWindows;

public static class FlushDns
{
    public static void EmptyFlushDns()
    {
        Console.WriteLine("Are you sure you want to flush the DNS cache? (y/n)");
        string confirmation = Console.ReadLine();
        if (confirmation.ToLower() == "y")
        {
            var psi = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c ipconfig /flushdns",
                UseShellExecute = false
            };

            var process = new Process { StartInfo = psi };
            process.Start();
            process.WaitForExit();
            Console.WriteLine("DNS cache flushed successfully.");
        }
        else
        {
            Console.WriteLine("Operation cancelled.");
        }
    }
}