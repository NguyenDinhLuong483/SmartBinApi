
namespace SmartBin.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BinUnitController : ControllerBase
    {
        public IBinUnitService _binUnitService {  get; set; }

        public BinUnitController(IBinUnitService binUnitService)
        {
            _binUnitService = binUnitService;
        }

        [HttpGet]
        [Route("GetBinUnitById")]
        public async Task<BinUnitViewModel> GetBinUnitById([FromQuery] string binUnitId) 
        {
            return await _binUnitService.GetBinUnitById(binUnitId);
        }
        [HttpPatch]
        [Route("UpdateBinUnit")]
        public async Task<IActionResult> UpdateBinUnit([FromQuery] string id, [FromBody] UpdateBinUnitViewModel viewModel)
        {
            var isSuccess = await _binUnitService.UpdateBinUnit(id, viewModel);
            if (isSuccess)
            {
                return new OkObjectResult("Update binUnit successfully!");
            }
            else
            {
                return new OkObjectResult("This binUnit can not be found!");
            }
        }
    }
}
