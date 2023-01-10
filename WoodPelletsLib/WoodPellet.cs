namespace WoodPelletsLib
{
    public class WoodPellet
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Quality { get; set; }

        public WoodPellet(int id, string brand, double price, int quality)
        {
            Id = id;
            Brand = brand;
            Price = price;
            Quality = quality;
        }

        public WoodPellet()
        {

        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Brand)}={Brand}, {nameof(Price)}={Price.ToString()}, {nameof(Quality)}={Quality.ToString()}}}";
        }

        public void ValidateBrand()
        {
            if (Brand == null) throw new ArgumentNullException();
            if (Brand.Length < 2) throw new ArgumentOutOfRangeException();
        }

        public void ValidatePrice()
        {
            if (Price < 0) throw new ArgumentOutOfRangeException(); 
        }

        public void ValidateQuality()
        {
            if (Quality < 1 || Quality > 5) throw new ArgumentOutOfRangeException();
        }

        public void Validate()
        {
            ValidateBrand();
            ValidatePrice();
            ValidateQuality();
        }
    }
}