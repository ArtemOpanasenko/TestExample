using System;
using System.Collections.Generic;

namespace Task02
{
    public class Book
    {
        public Book(string name, DateTime publicationDate, HashSet<string> authors)
        {
            Expect.ArgumentNotNullOrEmpty(name, nameof(name));
            Name = name; PublicationDate = publicationDate; Authors = authors;
        }

        public string Name { get; set; }

        public DateTime PublicationDate { get; set; }

        public HashSet<string> Authors { get; set; }
    }
}
