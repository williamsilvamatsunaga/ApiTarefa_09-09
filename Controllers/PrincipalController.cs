using Microsoft.AspNetCore.Mvc;

namespace atividade_tarefa_api_09_09.Models
{
    [Route("/")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {
        [HttpGet]
        public IActionResult Principal()
        {
            var resultado = new { situacao = "OK", mensagem = "ApiServiço" };

            return Ok(resultado);
        }

        [HttpGet("autor")]
        public IActionResult GetAutor()
        {
            return Ok(new
            {
                nome = "William",
                email = "willinhajogafacil01@gmail.com",
                telefone = "69999942754"
            });
        }
    }
}
