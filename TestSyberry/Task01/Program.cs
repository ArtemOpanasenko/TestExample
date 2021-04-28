using System;

namespace Task01
{
    public class Program
    {
        static void Main(string[] args)
        {
            var x = new SparseMatrix(3, 3) { [0, 0] = 0, [2, 2] = 5, [0, 1] = 2, };
            Console.WriteLine(x);
            Console.ReadLine();

            x[0, 2] = 7;
            Console.WriteLine(x);
            Console.ReadLine();

            foreach (var item in x.GetNonZeroElements())
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

            Console.WriteLine(x.GetCount(0));
            Console.ReadLine();
        }
    }
}
