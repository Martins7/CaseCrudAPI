using CaseCrud.Domain.Entities;
using CaseCrud.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CaseCRUD.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IPessoaFisicaService _pessoaFisicaService;

        public PessoaFisicaController(IPessoaFisicaService pessoaFisicaService)
        {
            _pessoaFisicaService = pessoaFisicaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPessoasFisicas()
        {
            try
            {
                var pessoasFisicas = await _pessoaFisicaService.GetPessoasFisicas();
                return Ok(pessoasFisicas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoaFisicaById(int id)
        {
            try
            {
                var pessoaFisica = await _pessoaFisicaService.GetPessoaFisicaById(id);

                if (pessoaFisica == null)
                {
                    return NotFound();
                }

                return Ok(pessoaFisica);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPessoaFisica([FromBody] PessoaFisica pessoa)
        {
            try
            {
                var pessoaId = await _pessoaFisicaService.AddPessoaFisica(pessoa);
                return CreatedAtAction(nameof(GetPessoaFisicaById), new { id = pessoaId }, pessoa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePessoaFisica(int id, [FromBody] PessoaFisica pessoa)
        {
            try
            {
                var updated = await _pessoaFisicaService.UpdatePessoaFisica(pessoa);

                if (!updated)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoaFisica(int id)
        {
            try
            {
                var deleted = await _pessoaFisicaService.DeletePessoaFisica(id);

                if (!deleted)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno do servidor");
            }
        }
    }
}