using Microsoft.AspNetCore.Mvc;
using api_09_09.Models;
using api_09_09.Models.Dtos;

namespace atividade_tarefa_api_09_09
{
    [Route("/tarefas")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private static List<Tarefa> _listaTarefa = new List<Tarefa>
        {
            new Tarefa()
            {
                Id = 1,
                Descricao = "Error",
                DataAbertura = new DateTime(2025, 09, 01),
                DataFechamento = new DateTime(2025, 09, 02),
                Situacao = "Fechado"
            },
            new Tarefa()
            {
                Id = 2,
                Descricao = "Error",
                DataAbertura = new DateTime(2025, 09, 01),
                DataFechamento = new DateTime(2025, 09, 02),
                Situacao = "Fechado"
            }
        };

        private static int _proximoId = 3;

        [HttpGet]
        public IActionResult BuscarTodos()
        {
            return Ok(_listaTarefa);
        }

        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            var tarefa = _listaTarefa.FirstOrDefault(t => t.Id == id);

            if (tarefa == null)
            {
                return NotFound();
            }

            return Ok(tarefa);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] TarefaDto novaTarefa)
        {
            var tarefa = new Tarefa
            {
                Id = _proximoId++,
                Descricao = novaTarefa.Descricao,
                DataAbertura = novaTarefa.DataAbertura,
                DataFechamento = novaTarefa.DataFechamento,
                Situacao = "Aberto"
            };

            _listaTarefa.Add(tarefa);

            return Created("", tarefa);
        }

        [HttpPut("{id}")]

        public IActionResult Atualizar(int id, [FromBody] TarefaDto novaTarefa)
        {
            var tarefa = _listaTarefa.FirstOrDefault(i =>  i.Id == id);

            if(tarefa == null)
            {
                return NotFound();
            }

            tarefa.Descricao = novaTarefa.Descricao;
            tarefa.Situacao = novaTarefa.Situacao;
            tarefa.DataAbertura = novaTarefa.DataAbertura;
            tarefa.DataFechamento = novaTarefa.DataFechamento;

            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var tarefa = _listaTarefa.FirstOrDefault(i =>i.Id == id);

            if(tarefa == null)
            {
                return NotFound();
            }

            _listaTarefa.Remove(tarefa);

            return NoContent();
        }
    }
}
