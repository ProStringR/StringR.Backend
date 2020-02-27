namespace StringR.Backend.Models
{
    public class Racket
    {
        public int Brand { get; set; }
        public int Model { get; set; }
        public double Weight { get; set; }
        public int StringsMain { get; set; }
        public int StringsCross { get; set; }
        public int GripSize { get; set; }

        public Racket(int brand, int model, double weight, int stringsMain, int stringsCross, int gripSize)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
            StringsMain = stringsMain;
            StringsCross = stringsCross;
            GripSize = gripSize;
        }
    }
}