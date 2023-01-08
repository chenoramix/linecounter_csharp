using System.IO;
using System.IO.Enumeration;

namespace linecounter
{
    internal class Program
    {
        /*
        static void processDirectories(string sDir, List<string> paths, string pattern)
        {
            try
            {
                foreach(string dir in Directory.GetDirectories(sDir))
                {
                    foreach(string file in Directory.GetFiles(dir))
                    {
                        bool isMatch = FileSystemName.MatchesSimpleExpression(pattern, file);
                        if(isMatch)
                        {
                            paths.Add(file);
                        }
                    }
                    processDirectories(dir, paths, pattern);
                }
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }*/
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

            string[] files = Array.Empty<string>();
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
            Console.WriteLine($"In {files.Length} files");
        }
    }
}