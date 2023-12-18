namespace linecounter
{
    internal class Program
    {
        static void processDirs(string currentDir, List<string> paths, string endswith)
        {
            try
            {
                var result = Directory.EnumerateFiles(currentDir);
                foreach(var item in result)
                {
                    if(item.EndsWith(endswith))
                    {
                        paths.Add(item);
                    }
                }

                result = Directory.EnumerateDirectories(currentDir);
                foreach(var item in result)
                {
                    processDirs(item, paths, endswith);
                }

            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            if(args.Length != 2)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine(@"dotnet linecounter.dll c:\path .cs");
                return;
            }

            if(!Directory.Exists(args[0]))
            {
                Console.WriteLine("Directory doesn't exist, sorry.");
                return;
            }

            List<string> paths = new List<string>();
            processDirs(args[0], paths, args[1]);

            if(paths.Count == 0)
            {
                Console.WriteLine("Couldn't find any files matching pattern:");
                Console.WriteLine(args[1]);
                return;
            }

            long lineCounter = 0;

            foreach(string file in paths)
            {
                foreach(string line in File.ReadLines(file))
                {
                    lineCounter++;
                }
            }

            Console.WriteLine($"Counted lines: {lineCounter}");
            Console.WriteLine($"In {paths.Count} files");

        }
    }
}