using System.IO;
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
                    //Console.WriteLine(item);
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

            /*string[] files = Array.Empty<string>();
            try
            {
                files = Directory.GetFiles(args[0], args[1], SearchOption.AllDirectories);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Exiting...");
                return;
            }

            if(files.Length == 0)
            {
                Console.WriteLine("Couldn't find any files matching pattern:");
                Console.WriteLine(args[1]);
                return;
            }

            decimal lineCounter = 0;

            foreach(string file in files)
            {
                foreach(string line in File.ReadLines(file))
                {
                    lineCounter++;
                }
            }

            Console.WriteLine($"Counted lines: {lineCounter}");
            Console.WriteLine($"In {files.Length} files");*/

        }
    }
}