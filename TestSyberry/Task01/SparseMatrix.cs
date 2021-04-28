using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task01
{
    public class SparseMatrix : IEnumerable<int>
    {
        private readonly Dictionary<(int, int), int> _matrix = new Dictionary<(int, int), int>();

        public int Rows { get; }
        public int Columns { get; }

        public SparseMatrix(int rows, int columns)
        {
            Expect.PositiveArgument(rows, nameof(rows));
            Expect.PositiveArgument(columns, nameof(columns));

            Rows = rows; Columns = columns;
        }

        public int this[int i, int j]
        {
            get
            {
                Expect.IndexOutOfRange(i, Rows, nameof(Rows));
                Expect.IndexOutOfRange(j, Columns, nameof(Columns));

                if (_matrix.ContainsKey((i, j)))
                {
                    return _matrix[(i, j)];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                Expect.IndexOutOfRange(i, Rows, nameof(Rows));
                Expect.IndexOutOfRange(j, Columns, nameof(Columns));
                if (value == 0)
                {
                    if (_matrix.ContainsKey((i, j)))
                    {
                        _matrix.Remove((i, j));
                    }
                }
                else
                {
                    _matrix.Add((i, j), value);
                }
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    yield return _matrix[(i, j)];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<(int, int, int)> GetNonZeroElements()
        {
            var _sorted = new SortedDictionary<(int, int), int>(_matrix);
            foreach (var pair in _sorted)
            {
                yield return (pair.Key.Item1, pair.Key.Item2, pair.Value);
            }
        }

        public int GetCount(int x)
        {
            if (x == 0)
            {
                return ((Rows * Columns) - _matrix.Count());
            }

            int result = 0;
            foreach (var pair in _matrix)
            {
                if (pair.Value == x)
                {
                    result++;
                }
            }

            return result;
        }

        public override string ToString()
        {
            var result = new StringBuilder(Rows * Columns * 3 + Rows * 2);
            for (var i = 0; i < Rows; i++)
            {
                for (var j = 0; j < Columns; j++)
                {
                    result.Append($"{this[i, j],-3}");
                }

                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}
