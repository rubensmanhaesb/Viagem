using Microsoft.AspNetCore.Mvc;
using ViagemApp.Application.DTO;
using ViagemApp.Application.Interfaces;


namespace ViagemApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramaFidelidadeController : ControllerBase
    {
        private readonly IProgramaFidelidadeApplicationService _programaFidelidadeApplicationService;

        public ProgramaFidelidadeController(IProgramaFidelidadeApplicationService programaFidelidadeApplicationService)
        {
            _programaFidelidadeApplicationService = programaFidelidadeApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProgramaFidelidadeDTOResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Insert([FromBody] ProgramaFidelidadeDTOInsert dto)
        {
            return StatusCode(StatusCodes.Status201Created, await _programaFidelidadeApplicationService.AddAsync(dto));
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProgramaFidelidadeDTOResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] ProgramaFidelidadeDTOUpdate dto)
        {
            return StatusCode(StatusCodes.Status200OK, await _programaFidelidadeApplicationService.UpdateAsync(dto));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ProgramaFidelidadeDTOResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromBody] ProgramaFidelidadeDTODelete dto)
        {
            return StatusCode(StatusCodes.Status200OK, await _programaFidelidadeApplicationService.DeleteAsync(dto));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProgramaFidelidadeDTOResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            return StatusCode(StatusCodes.Status200OK, await _programaFidelidadeApplicationService.Get());
        }

    }
}
