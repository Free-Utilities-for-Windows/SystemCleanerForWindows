namespace ForWindows;

using System.Runtime.InteropServices;

public static class RecycleBin
{
    [DllImport("Shell32.dll")]
    static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, uint dwFlags);

    public static void EmptyRecycleBin()
    {
        Console.WriteLine("Are you sure you want to empty the recycle bin? (y/n)");
        string confirmation = Console.ReadLine();
        if (confirmation.ToLower() == "y")
        {
            SHEmptyRecycleBin(IntPtr.Zero, null, 0);
            Console.WriteLine("Recycle bin emptied successfully.");
        }
        else
        {
            Console.WriteLine("Operation cancelled.");
        }
    }
}