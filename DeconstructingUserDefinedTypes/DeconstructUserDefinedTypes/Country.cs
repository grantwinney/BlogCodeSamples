namespace DeconstructUserDefinedTypes
{
    public class Country
    {
        public string Name { get; set; }
        public List<State> States { get; set; } = new List<State>();
        public long TotalPopulation => States.Sum(s => s.Population);

        /// <summary>
        /// Returns the name and population of the country.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="pop">Population</param>
        public void Deconstruct(out string name, out long pop)
        {
            name = Name;
            pop = States.Sum(s => s.Population);
        }

        /// <summary>
        /// Returns the name, population, and number of states.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="pop">Population</param>
        /// <param name="numberOfStates">Number of states</param>
        public void Deconstruct(out string name, out long pop, out int numberOfStates)
        {
            name = Name;
            pop = States.Sum(s => s.Population);
            numberOfStates = States.Count;
        }
    }

    public class State
    {
        public string Name { get; set; }
        public long Population { get; set; }
    }
}
