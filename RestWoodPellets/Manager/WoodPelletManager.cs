using WoodPelletsLib;

namespace RestWoodPellets.Manager
{
    public class WoodPelletManager
    {
        private static int incrementId = 1;

        private static readonly List<WoodPellet> woodPellets = new List<WoodPellet>()
        {
            new WoodPellet(){Id = incrementId++, Brand="BioWood", Price=4995, Quality = 4},
            new WoodPellet(){Id = incrementId++, Brand="BioWood", Price=5195.99, Quality = 4},
            new WoodPellet(){Id = incrementId++, Brand="BilligPille", Price=4125, Quality = 1},
            new WoodPellet(){Id = incrementId++, Brand="GoldenWoodPellet", Price=5995.55, Quality = 5},
            new WoodPellet(){Id = incrementId++, Brand="GoldenWoodPellet", Price=5795, Quality = 5},
        };

        public IEnumerable<WoodPellet> GetAll()
        {
            return new List<WoodPellet>(woodPellets);
        }

        public WoodPellet? GetById(int id)
        {
            return woodPellets.Find(woodpellet => woodpellet.Id == id);
        }

        public WoodPellet Add(WoodPellet newWoodPellet)
        {
            newWoodPellet.Validate();
            newWoodPellet.Id = incrementId++;
            woodPellets.Add(newWoodPellet);
            return newWoodPellet;
        }

        public WoodPellet? Update(int id, WoodPellet updatedWoodPellet)
        {
            updatedWoodPellet.Validate();
            WoodPellet? oldWoodPellet = GetById(id);
            if (oldWoodPellet == null) return null;
            oldWoodPellet.Brand = updatedWoodPellet.Brand;
            oldWoodPellet.Price = updatedWoodPellet.Price;
            oldWoodPellet.Quality = updatedWoodPellet.Quality;
            return oldWoodPellet;
        }
    }
}
