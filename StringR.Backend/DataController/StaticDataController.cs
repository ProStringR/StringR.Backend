using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StringR.Backend.DAO;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DTO.InitialFetchData;

namespace StringR.Backend.DataController
{
    public class StaticDataController : IStaticDataController
    {
        private StaticDataDAO _staticDataDao;

        public StaticDataController(StaticDataDAO staticDataDao)
        {
            _staticDataDao = staticDataDao;
        }
        public List<ColorDto> GetAllColors()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_staticDataDao.GetAllColors().Tables[0]);
                List<ColorDto> colorDtos = JsonConvert.DeserializeObject<List<ColorDto>>(json);

                return colorDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<PurposeDto> GetAllPurposes()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_staticDataDao.GetAllPurposes().Tables[0]);
                List<PurposeDto> purposeDtos = JsonConvert.DeserializeObject<List<PurposeDto>>(json);

                return purposeDtos;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}