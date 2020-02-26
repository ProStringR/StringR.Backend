namespace StringR.Backend.DTO
{
    public class RacketDto
    {
        public int RacketId { get; set; }
        public string RacketBrand { get; set; }
        public string RacketModel { get; set; }
        public int Weight { get; set; }
        public int Main { get; set; }
        public int Cross { get; set; }
        public int GripSize { get; set; }

        public RacketDto(int racketId, string racketBrand, string racketModel, int weight, int main, int cross, int gripSize)
        {
            RacketId = racketId;
            RacketBrand = racketBrand;
            RacketModel = racketModel;
            Weight = weight;
            Main = main;
            Cross = cross;
            GripSize = gripSize;
        }
    }
}