using System.IO;


namespace linecounter
{
    internal class Program
    {
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

            // GetFiles(path, filePatter, searchOption);
            string[] files = Directory.GetFiles(args[0], args[1], SearchOption.AllDirectories);
            if(files.Length == 0)
            {
                Console.WriteLine("Couldn't find any files matching pattern:");
                Console.WriteLine(args[1]);
                return;
            }

            Console.ReadLine();
        }
    }
}