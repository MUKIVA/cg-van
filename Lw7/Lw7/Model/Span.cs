using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lw7.Model
{
    public class Span<T>
    {
        private T[] _values;
        public Span(UInt32 range)
        {
            _values = new T[(int)range];
        }

        public void Fill(T value)
        {
            for (int i = 0; i < _values.Length; ++i)
                _values[i] = value;
        }

        public T this[UInt32 index]
        {
            get => _values[index];
            set => _values[index] = value;
        }
    }
}
