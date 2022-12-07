namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {
        // dictionary where the key is a tuple with the two keys as values
        private readonly Dictionary<Tuple<TKey1, TKey2>, TValue> dict = new Dictionary<Tuple<TKey1, TKey2>, TValue>();
        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        public int NumberOfElements
        {
            get => this.dict.Count;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get => this.dict.GetValueOrDefault(Tuple.Create(key1, key2));
            set => this.dict[Tuple.Create(key1, key2)] = value;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            return this.dict.Where(i => i.Key.Item1.Equals(key1)).Select(i => Tuple.Create(i.Key.Item2, i.Value)).ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            return this.dict.Where(i => i.Key.Item2.Equals(key2)).Select(i => Tuple.Create(i.Key.Item1, i.Value)).ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            return this.dict.Select(i => Tuple.Create(i.Key.Item1, i.Key.Item2, i.Value)).ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            foreach(var key1 in keys1)
            {
                foreach(var key2 in keys2.ToArray())
                {
                    this.dict[Tuple.Create(key1, key2)] = generator(key1, key2);
                }
            }
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other) => Equals(this.dict, other);

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals(obj);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode() => this.dict.GetHashCode();

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.ToString"/>
        public override string ToString()
        {
            string output = "{ ";
            foreach(var elem in GetElements())
            {
                output += $"[{elem.Item1}, {elem.Item2}] -> {elem.Item3}, ";
            }
            output = output.Substring(0, output.Length - 2);
            return output + " }";
        }
    }
}
