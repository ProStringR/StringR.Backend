using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StringR.Backend.DAO;
using StringR.Backend.DataController.Interface;
using StringR.Backend.DTO.InitialFetchData;

namespace StringR.Backend.Controllers.v1
{
    [Authorize]
    [Route("api/v1/[controller]")]
    public class StaticDataController : ControllerBase
    {
        private IStaticDataController _staticDataController;

        public StaticDataController(IConfiguration configuration)
        {
            _staticDataController = new DataController.StaticDataController(new StaticDataDAO(configuration));
        }

        [AllowAnonymous]
        [HttpGet("all-colors")]
        public ActionResult<List<ColorDto>> GetAllColors()
        {
            return _staticDataController.GetAllColors();
        }
        
        [AllowAnonymous]
        [HttpGet("all-purposes")]
        public ActionResult<List<PurposeDto>> GetAllPurposes()
        {
            return _staticDataController.GetAllPurposes();
        }
        
        [AllowAnonymous]
        [HttpGet("all-racket-brands")]
        public ActionResult<List<RacketBrandDto>> GetAllRacketBrands()
        {
            return _staticDataController.GetAllRacketBrands();
        }
        
        [AllowAnonymous]
        [HttpGet("all-string-brands")]
        public ActionResult<List<StringBrandDto>> GetAllStringBrands()
        {
            return _staticDataController.GetAllStringBrands();
        }
        
        [AllowAnonymous]
        [HttpGet("all-string-types")]
        public ActionResult<List<StringTypeDto>> GetAllStringTypes()
        {
            return _staticDataController.GetAllStringTypes();
        }
    }
}