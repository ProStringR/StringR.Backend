namespace StringR.Backend.Models
{
    public class Racket
    {
        public int Brand { get; }
        public int Model { get; }
        public double Weight { get; }
        public int StringsMain { get; }
        public int StringsCross { get; }
        public int GripSize { get; }

        public Racket(int brand, int model, double weight, int stringsMain, int stringsCross, int gripSize)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
            StringsMain = stringsMain;
            StringsCross = stringsCross;
            this.GripSize = gripSize;
        }
    }
}