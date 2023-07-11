using JPVApiCrud.Model;
using JPVApiCrud.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace JPVApiCrud.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {

        private readonly ICandidatoService _candidatoService;

        public CandidatoController(ICandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidato>>> ObterTodosCandidatos()
        {
           return Ok(await _candidatoService.BuscarLista());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> CandidatoPorId(int id)
        {            
            Candidato? candidato = await _candidatoService.BuscaPorId(id);

            if(candidato == null)
            {
                return NotFound();  
            }

            return  Ok(new[] { candidato });
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarCandidato([FromBody] Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           await _candidatoService.AdicionarCandidato(candidato);

           return CreatedAtAction(nameof(CandidatoPorId), new { id = candidato.CdCandidato }, candidato);
        } 
         
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCandidato(int id,[FromBody] Candidato candidatoAtualizado)
        {
         var atualizado = await _candidatoService.AtualizarCandidato(id, candidatoAtualizado);

            if (!atualizado)
            {
                return NotFound("Candidato não atualizado");
            }
          
          return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirCandidato(int id)
        {
            var dell = await _candidatoService.ExcluirCandidato(id);
            if (!dell)
            {
                return NotFound("Candidato ja foi excluido ou não existe");
            }

            return NoContent();

        }

    }
}