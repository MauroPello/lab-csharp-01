namespace Properties
{
    using System;

    /// <summary>
    /// The class models a card.
    /// </summary>
    public class Card
    {
        public string seed { get; }
        public string name { get; }
        public int ordinal { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="name">the name of the card.</param>
        /// <param name="seed">the seed of the card.</param>
        /// <param name="ordinal">the ordinal number of the card.</param>
        public Card(string name, string seed, int ordinal)
        {
            this.name = name;
            this.ordinal = ordinal;
            this.seed = seed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="tuple">the informations about the card as a tuple.</param>
        internal Card(Tuple<string, string, int> tuple) : this(tuple.Item1, tuple.Item2, tuple.Item3)
        {
        }

        /// <inheritdoc cref="object.ToString"/>
        public override string ToString() => $"{this.GetType().Name}(Name={this.name}, Seed={this.seed}, Ordinal={this.ordinal})";

        public bool Equals(Card card) => string.Equals(seed, card.seed) && string.Equals(name, card.name) && ordinal == card.ordinal;

        public override bool Equals(object obj) => obj.GetType().Equals(this.GetType()) && Equals(this, obj);

        public override int GetHashCode() => HashCode.Combine(seed, name, ordinal);
    }
}
