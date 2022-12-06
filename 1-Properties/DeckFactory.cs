namespace Properties
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A factory class for building <see cref="ISet{T}">decks</see> of <see cref="Card"/>s.
    /// </summary>
    public class DeckFactory
    {
        private string[] _seeds;
        
        // necessario per avere i semi sottoforma di Lista
        public IList<string> Seeds 
        { 
            get => this._seeds.ToList();
            set => this._seeds = value.ToArray();
        }

        private string[] _names; 
        
        // necessario per avere i nomi sottoforma di Lista
        public IList<string> Names 
        { 
            get => this._names.ToList();
            set => this._names = value.ToArray();
        }

        public int DeckSize => this._names.Length * this._seeds.Length;

        public ISet<Card> Deck
        {
            get 
            {
                if (this.Names == null || this.Seeds == null)
                {
                    throw new InvalidOperationException();
                }

                return new HashSet<Card>(Enumerable
                    .Range(0, this._names.Length)
                    .SelectMany(i => Enumerable
                        .Repeat(i, this._seeds.Length)
                        .Zip(
                            Enumerable.Range(0, this._seeds.Length),
                            (n, s) => Tuple.Create(this._names[n], this._seeds[s], n)))
                    .Select(tuple => new Card(tuple))
                    .ToList());
            }
        }
    }
}
