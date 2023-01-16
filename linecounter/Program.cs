using System.IO.Enumeration;

namespace linecounter
{
    internal class Program
    {
        static void processDirs(string cDir, List<string> paths, string pattern)
        {
            try
            {
                var result = Directory.EnumerateFiles(cDir);
                foreach(var item in result)
                {
                    if(FileSystemName.MatchesSimpleExpression(pattern, item))
                    {
                        paths.Add(item);
                    }
                }

                result = Directory.EnumerateDirectories(cDir);
                foreach(var item in result)
                {
                    processDirs(item, paths, pattern);
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
                Console.WriteLine(@"linecounter.exe c:\path *.cs");
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