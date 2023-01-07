namespace linecounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 2)
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("linecounter.exe c:\\path *.cs");
                return;
            }

            Console.ReadLine();
        }
    }
}