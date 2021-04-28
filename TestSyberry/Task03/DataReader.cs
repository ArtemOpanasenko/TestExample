using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Task03
{
    public class DataReader
    {
        private readonly string _fullPath;

        public DataReader(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            _fullPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, fileName));
            if (!File.Exists(_fullPath))
            {
                throw new FileNotFoundException("File Not Found", _fullPath);
            }
        }

        public List<(string, double, double)> Read()
        {
            var culture = new CultureInfo("en-US");
            return File.ReadLines(_fullPath)
                .Select(line => line.Split(','))
                .Select(parts => (parts[0], double.Parse(parts[1], culture), double.Parse(parts[2], culture)))
                .ToList();
        }
    }
}