using System.Collections.Generic;

namespace Task02
{
    public class Catalog
    {
        private readonly Dictionary<string, Book> _catalog = new();

        public Book this[string key]
        {
            get
            {
                Expect.IndexIsNotMatch(ref key);
                if (_catalog.ContainsKey(key))
                {
                    return _catalog[key];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                Expect.IndexIsNotMatch(ref key);
                _catalog.Add(key, value);
            }
        }
    }
}
