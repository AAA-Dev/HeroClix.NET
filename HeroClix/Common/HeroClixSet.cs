using HeroClix.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroClix.Common
{
    /// <summary>
    /// Represents a set of HeroClix GameElements.
    /// </summary>
    public class HeroClixSet
    {
        private string name;
        private DateTime releaseDate;
        private Bitmap symbol;
        private HeroClixAge age;
        private IGameElement[] elements;

        /// <summary>
        /// Creates an empty HeroClixSet.
        /// </summary>
        public HeroClixSet()
        {
            this.name = "Default";
            this.releaseDate = DateTime.Now;
            this.age = HeroClixAge.Golden;
            this.symbol = new Bitmap(32, 32);
            this.elements = new IGameElement[10];
        }

        /// <summary>
        /// Creates a HeroClixSet.
        /// </summary>
        /// <param name="setName">The name of the se.</param>
        /// <param name="setReleaseDate">The date the set was released.</param>
        /// <param name="setAge">What age the set is in.</param>
        /// <param name="setSymbol">The set symbol.</param>
        /// <param name="setElements">The list of game elements(maps, characters, special objects, etc...) that make up the set.</param>
        public HeroClixSet(string setName, DateTime setReleaseDate, HeroClixAge setAge, Bitmap setSymbol, IGameElement[] setElements)
        {
            this.name = setName;
            this.releaseDate = setReleaseDate;
            this.age = setAge;
            this.symbol = setSymbol;
            this.elements = setElements;
        }

        /// <summary>
        /// Returns the name of the set.
        /// </summary>
        /// <returns>The name of the set.</returns>
        public string Name()
        {
            return this.name;
        }

        /// <summary>
        /// Returns the date that the set was released.
        /// </summary>
        /// <returns>The date that the set was released.</returns>
        public DateTime ReleaseDate()
        {
            return this.releaseDate;
        }

        /// <summary>
        /// Returns the HeroClixAge that the set belongs to.
        /// </summary>
        /// <returns>The HeroClixAge that the set belongs to.</returns>
        public HeroClixAge Age()
        {
            return this.age;
        }

        /// <summary>
        /// Returns the set's symbol.
        /// </summary>
        /// <returns>The set's symbol.</returns>
        public Bitmap Symbol()
        {
            return this.symbol;
        }

        /// <summary>
        /// Returns an array of all GameElements that belong to this set.
        /// </summary>
        /// <returns>An array of all GameElements that belong to this set.</returns>
        public IGameElement[] AllElements()
        {
            return this.elements;
        }

        /// <summary>
        /// Returns an array of HeroClixMaps that belong to this set.
        /// </summary>
        /// <returns>An array of HeroClixMaps that belong to this set.</returns>
        public HeroClixMap[] Maps()
        {
            return GetSubset<HeroClixMap>(this.elements);
        }

        /// <summary>
        /// Returns an array of HeroClixCharacters that belong to this set.
        /// </summary>
        /// <returns>An array of HeroClixCharacters that belong to this set.</returns>
        public HeroClixCharacter[] Characters()
        {
            return GetSubset<HeroClixCharacter>(this.elements);
        }

        /// <summary>
        /// Returns an array of HeroClixObjects that belong to this set.
        /// </summary>
        /// <returns>An array of HeroClixObjects that belong to this set.</returns>
        public HeroClixObject[] Objects()
        {
            return GetSubset<HeroClixObject>(this.elements);
        }

        /// <summary>
        /// Returns an array of all elements of type T that belong to the set.
        /// </summary>
        /// <typeparam name="T">The type of object to create a subset of from the contents of the set.</typeparam>
        /// <param name="original">The list of GameElements to create a subset of.</param>
        /// <returns>A subset of the original array of the type requested.</returns>
        private T[] GetSubset<T>(IGameElement[] original)
        {
            int count = original.Count(x => x.GetType().BaseType.Equals(typeof(T)));
            T[] result = new T[count];
            int index = 0;

            for (int i = 0; i < original.Length; i++)
            {
                if (original[i].GetType().BaseType.Equals(typeof(T)))
                {
                    result[index] = (T)original[i];
                    index++;
                }
            }
            return result;
        }
    }
}
