using System.Collections.Generic;
using StringR.Backend.DTO;
using StringR.Backend.DTO.InitialFetchData;

namespace StringR.Backend.DataController.Interface
{
    public interface IStaticDataController
    {
        List<ColorDto> GetAllColors();
        List<PurposeDto> GetAllPurposes();
        List<RacketBrandDto> GetAllRacketBrands();
    }
}