using System;
using System.Collections.Generic;

namespace Task02
{
    public class Program
    {
        static void Main(string[] args)
        {
            var authors = new HashSet<string>();
            authors.Add("J.K. Rowling");
            authors.Add("J.K. Rowling");

            var book = new Book("Harry Potter", DateTime.Now, authors);
            Console.WriteLine(book.Authors.Count);
            Console.ReadLine();

            var catalog = new Catalog();
            catalog["123-4-56-789012-3"] = book;
            var book1 = catalog["1234567890123"];
            var book2 = catalog["123-4-56-789012-3"];
            Console.ReadLine();
        }
    }
}