using System;
using System.Diagnostics;
using System.IO;
using ForWindows;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Select an option:");
            Console.WriteLine(
                $"1. Clean Temp folder ({MyDirectory.GetDirectorySize(Path.GetTempPath()) / (1024 * 1024)} MB)");
            Console.WriteLine(
                $"2. Clean LogFiles folder ({MyDirectory.GetDirectorySize(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "LogFiles")) / (1024 * 1024)} MB)");
            Console.WriteLine(
                $"3. Clean Windows Update log files ({MyDirectory.GetDirectorySize(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "SoftwareDistribution", "Download")) / (1024 * 1024)} MB)");
            Console.WriteLine(
                $"4. Clean Thumbnail cache ({MyDirectory.GetDirectorySize(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft", "Windows", "Explorer")) / (1024 * 1024)} MB)");
            Console.WriteLine(
                $"5. Clean Font cache ({MyDirectory.GetFileSize(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "FNTCACHE.DAT")) / (1024 * 1024)} MB)");
            Console.WriteLine("6. Clean Recycle Bin");
            Console.WriteLine(
                $"7. Clean Downloads folder ({MyDirectory.GetDirectorySize(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads")) / (1024 * 1024)} MB)");
            Console.WriteLine("8. Flush DNS cache");
            Console.WriteLine("9. Clean all files and directories");
            Console.WriteLine("10. Clean a specific file");
            Console.WriteLine("11. Clean a specific directory");
            Console.WriteLine("0. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    MyDirectory.CleanDirectory(Path.GetTempPath());
                    Console.WriteLine("Temp folder cleaned successfully.");
                    break;
                case "2":
                    MyDirectory.CleanDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System),
                        "LogFiles"));
                    Console.WriteLine("LogFiles folder cleaned successfully.");
                    break;
                case "3":
                    MyDirectory.CleanDirectory(Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.Windows), "SoftwareDistribution",
                        "Download"));
                    Console.WriteLine("Windows Update log files cleaned successfully.");
                    break;
                case "4":
                    MyDirectory.CleanDirectory(Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft",
                        "Windows", "Explorer"));
                    Console.WriteLine("Thumbnail cache cleaned successfully.");
                    break;
                case "5":
                    File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System),
                        "FNTCACHE.DAT"));
                    Console.WriteLine("Font cache cleaned successfully.");
                    break;
                case "6":
                    RecycleBin.EmptyRecycleBin();
                    Console.WriteLine("Recycle Bin cleaned successfully.");
                    break;
                case "7":
                    MyDirectory.CleanDirectory(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"));
                    Console.WriteLine("Downloads folder cleaned successfully.");
                    break;
                case "8":
                    FlushDns.EmptyFlushDns();
                    Console.WriteLine("DNS cache flushed successfully.");
                    break;
                case "9":
                    MyDirectory.CleanDirectory(Path.GetTempPath());
                    MyDirectory.CleanDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System),
                        "LogFiles"));
                    MyDirectory.CleanDirectory(Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.Windows), "SoftwareDistribution",
                        "Download"));
                    MyDirectory.CleanDirectory(Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Microsoft",
                        "Windows", "Explorer"));
                    MyDirectory.CleanFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System),
                        "FNTCACHE.DAT"));
                    RecycleBin.EmptyRecycleBin();
                    MyDirectory.CleanDirectory(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"));
                    FlushDns.EmptyFlushDns();
                    Console.WriteLine("All files and directories cleaned successfully.");
                    break;
                case "10":
                    Console.WriteLine("Enter the path of the file you want to clean:");
                    string filePath = Console.ReadLine();
                    MyDirectory.CleanFile(filePath);
                    Console.WriteLine("File cleaned successfully.");
                    break;
                case "11":
                    Console.WriteLine("Enter the path of the directory you want to clean:");
                    string directoryPath = Console.ReadLine();
                    MyDirectory.CleanDirectory(directoryPath);
                    Console.WriteLine("Directory cleaned successfully.");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}