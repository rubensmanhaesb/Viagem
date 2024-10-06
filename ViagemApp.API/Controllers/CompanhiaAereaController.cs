using Microsoft.AspNetCore.Mvc;
using ViagemApp.Applicaion.Interfaces;
using ViagemApp.Application.DTO;


namespace ViagemApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanhiaAereaController : ControllerBase
    {
        private readonly ICompanhiaAereaApplicationService _companhiaAereaApplicationService;

        public CompanhiaAereaController(ICompanhiaAereaApplicationService companhiaAereaApplicationService)
        {
            _companhiaAereaApplicationService = companhiaAereaApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CompanhiaAereaDTOResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Insert([FromBody] CompanhiaAereaDTOInsert dto)
        {
            return StatusCode(StatusCodes.Status201Created, await _companhiaAereaApplicationService.AddAsync(dto));
        }

        [HttpPut]
        [ProducesResponseType(typeof(CompanhiaAereaDTOResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] CompanhiaAereaDTOUpdate dto)
        {
            return StatusCode(StatusCodes.Status200OK, await _companhiaAereaApplicationService.UpdateAsync(dto));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(CompanhiaAereaDTOResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] CompanhiaAereaDTODelete dto)
        {
            return StatusCode(StatusCodes.Status200OK, await _companhiaAereaApplicationService.DeleteAsync(dto));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CompanhiaAereaDTOResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return StatusCode(StatusCodes.Status200OK, await _companhiaAereaApplicationService.Get());
        }

    }
}
