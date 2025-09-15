namespace api_09_09.Models.Dtos
{
    public class TarefaDto
    {
        public required string Descricao {  get; set; }
        public required string Situacao { get; set; }
        public required DateTime DataAbertura {  get; set; }
        public required DateTime DataFechamento { get; set; }
    }
}
