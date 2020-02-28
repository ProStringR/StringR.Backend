using System.Collections.Generic;
using StringR.Backend.DTO.InitialFetchData;

namespace StringR.Backend.DataController.Interface
{
    public interface IStaticDataController
    {
        List<ColorDto> GetAllColors();
    }
}