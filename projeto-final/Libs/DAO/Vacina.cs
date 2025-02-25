using Libs.Models;

namespace Libs.DAO;
public class Vacina
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataDeAplicacao { get; set; }
    public DateTime DataDeValidade { get; set; }
    public TimeSpan Durabilidade { get; set; }


    public Vacina(string nome, DateTime dataDeAplicacao, DateTime dataDeValidade, int id, TimeSpan durabilidade)
    {
        Nome = nome;
        DataDeAplicacao = dataDeAplicacao;
        DataDeValidade = dataDeValidade;
        Id = id;
        Durabilidade = durabilidade;
    }

    public Vacina(Models.Vacina vacina) : this(vacina.Nome, vacina.DataDeAplicacao, vacina.DataDeValidade, vacina.Id, vacina.Durabilidade)
    {

    }
}





