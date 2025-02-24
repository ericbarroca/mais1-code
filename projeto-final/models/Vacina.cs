namespace ProjetoFinal.Models;
using ProjetoFinal.DAO;


public class Vacina
    {
        public int Id { get; set; }
        public required Vacina Vacina { get; set; }
        public DateTime DataDeAplicacao { get; set; }
        public DateTime DataDeValidade { get; set; }

        public string vacinaDurabilidade { get; set; }

        public Vacina (Vacina vacina, DateTime dataDeAplicacao)
        {
            Vacina = vacina;
            DataDeAplicacao = dataDeAplicacao;
            DataDeValidade = dataDeAplicacao.Add(vacinaDurabilidade);
        }
}
