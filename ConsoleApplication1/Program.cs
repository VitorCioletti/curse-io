using CurseIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static async void PrintAsync()
        {
            var curse = new Curse();

            var result = await curse.CleanseAsync("fuck dog potato ships");

            Console.WriteLine(result);
        }

        static void Main(string[] args)
        {
            PrintAsync();

            Console.WriteLine("apos async");
            Console.ReadKey();
        }
    }
}
