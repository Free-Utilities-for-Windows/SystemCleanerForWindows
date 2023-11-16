namespace ForWindows;

public static class MyDirectory
{
    public static void CleanDirectory(string path, bool isFirstCall = true)
    {
        bool confirm = true;
        if (isFirstCall)
        {
            Console.WriteLine($"Are you sure you want to clean the directory at {path}? (y/n)");
            string confirmation = Console.ReadLine();
            confirm = confirmation.ToLower() == "y";
        }

        if (confirm)
        {
            try
            {
                long initialSize = GetDirectorySize(path);
                foreach (var directory in Directory.GetDirectories(path))
                {
                    CleanDirectory(directory, false);
                    Directory.Delete(directory, true);
                    Console.Write(".");
                }

                foreach (var file in Directory.GetFiles(path))
                {
                    File.Delete(file);
                    Console.Write(".");
                }

                Directory.Delete(path, true);

                Console.WriteLine($"\nCleaned {initialSize / (1024 * 1024)} MB. Directory removed.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
        else
        {
            Console.WriteLine("Operation cancelled.");
        }
    }

    public static void CleanFile(string path)
    {
        Console.WriteLine($"Are you sure you want to clean the file at {path}? (y/n)");
        string confirmation = Console.ReadLine();
        if (confirmation.ToLower() == "y")
        {
            try
            {
                long initialSize = new FileInfo(path).Length;
                File.Delete(path);
                long finalSize = File.Exists(path) ? new FileInfo(path).Length : 0;
                Console.WriteLine($".\nCleaned {initialSize / (1024 * 1024)} MB. Current size: {finalSize / (1024 * 1024)} MB");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"No permission to access file: {path}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
        else
        {
            Console.WriteLine("Operation cancelled.");
        }
    }

    public static long GetDirectorySize(string path)
    {
        long size = 0;
        try
        {
            string[] a = Directory.GetFiles(path, "*.*");
            
            foreach (string name in a)
            {
                FileInfo info = new FileInfo(name);
                size += info.Length;
            }
            
            string[] directories = Directory.GetDirectories(path);
            
            foreach (string directory in directories)
            {
                size += GetDirectorySize(directory);
            }
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine($"Directory not found: {path}");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"No permission to access directory: {path}");
        }
        return size;
    }

    public static long GetFileSize(string path)
    {
        if (File.Exists(path))
        {
            return new FileInfo(path).Length;
        }

        return 0;
    }
}