using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Utilities
    {
        public static object row { get; internal set; }

        public static string GetString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        public static int GetInteger(string question)
        {
            Console.WriteLine(question);
            return int.Parse(Console.ReadLine());
        }
        public static double Getdouble(string question)
        {
            Console.WriteLine(question);
            return double.Parse(Console.ReadLine());
        }

        internal static string GetString(object content)
        {
            throw new NotImplementedException();
        }
    }
}


