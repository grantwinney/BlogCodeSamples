using DeconstructUserDefinedTypes;
using System.Drawing;


// EXAMPLE 1 - DECONSTRUCTION ON USER-DEFINED TYPE

var usa = new Country { Name = "United States" };
usa.States.Add(new State { Name = "Utah", Population = 3380800 });
usa.States.Add(new State { Name = "Maine", Population = 1385340 });
usa.States.Add(new State { Name = "Florida", Population = 22244823 });

var (name, population) = usa;
//usa.Deconstruct(out var name, out var population);

Console.WriteLine($"{name} has {population} people in it.");
// United States has 27010963 people in it.

Console.WriteLine($"{usa.Name} has {usa.TotalPopulation} people in it.");


// EXAMPLE 2 - DECONSTRUCTION IN EXTENSION METHOD

var couch = new Furniture
{
    Name = "Couch",
    Location = new Point(3, 4),
    Size = new Size(6, 2)
};

var (x, y) = couch.Location;
var (width, height) = couch.Size;

Console.WriteLine($"The {couch.Name} is {width} feet by {height} feet.");
