namespace Libs.Models;
using Libs.DAO;

public class Vacina
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataDeAplicacao { get; set; }
    public DateTime DataDeValidade { get; set; }
    public TimeSpan Durabilidade { get; set; }

    public Vacina(Models.Vacina vacina) : this(vacina.Nome, vacina.DataDeAplicacao, vacina.DataDeValidade, vacina.Id, vacina.Durabilidade)
    {

    }

    public Vacina(string nome, DateTime dataDeAplicacao, DateTime dataDeValidade, int id, TimeSpan durabilidade)
    {
        Nome = nome;
        DataDeAplicacao = dataDeAplicacao;
        DataDeValidade = dataDeValidade;
        Id = id;
        Durabilidade = durabilidade;
    }
}
