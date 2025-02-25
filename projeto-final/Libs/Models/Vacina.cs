namespace Libs.Models;
using Libs.DAO;


public class Vacina
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataDeAplicacao { get; set; }
    public DateTime DataDeValidade { get; set; }
    public TimeSpan Durabilidade { get; set; }

    public Vacina(DAO.Vacina vacina)
    {
        this.DataDeAplicacao = vacina.DataDeAplicacao;
        this.DataDeValidade = vacina.DataDeValidade;
        this.Id = vacina.Id;
        this.Nome = vacina.Nome;
        this.Durabilidade = vacina.Durabilidade;
    }
}
