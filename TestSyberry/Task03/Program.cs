using System;

namespace Task03
{
    public class Program
    {
        public static void Main()
        {
            var dataReader = new DataReader(@"data.txt");
            var data = dataReader.Read();
            data.ForEach(item => Console.WriteLine(item));

            while (true)
            {
                Console.Write("X = ");
                if (!double.TryParse(Console.ReadLine(), out var x))
                {
                    break;
                }

                Console.Write("Y = ");
                if (!double.TryParse(Console.ReadLine(), out var y))
                {
                    break;
                }

                var result = KnnClassifier.Classify(data, (x, y));
                Console.WriteLine(result);
            }
        }
    }
}
