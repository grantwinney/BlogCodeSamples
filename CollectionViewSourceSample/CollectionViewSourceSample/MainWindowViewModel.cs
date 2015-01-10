using System.Collections.Generic;

namespace CollectionViewSourceSample
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Pirates = new List<Pirate>
                      {
                          new Pirate("Anne", "Bonny"),
                          new Pirate("Black", "Bart"),
                          new Pirate("Hayreddin", "Barbarossa"),
                          new Pirate("Hector", "Barbossa"),
                          new Pirate("Henry", "Avery"),
                          new Pirate("Henry", "Morgan"),
                          new Pirate("Howell", "Davis"),
                          new Pirate("William", "Kidd"),
                          new Pirate("William", "Turner"),
                      };
        }

        public List<Pirate> Pirates { get; set; }

        public Pirate SelectedPirate { get; set; }
    }
}
