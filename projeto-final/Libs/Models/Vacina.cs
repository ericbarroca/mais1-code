namespace Libs.Models;
using Libs.DAO;

public class Vacina
{
    public int ID { get; set; }
    public string Nome { get; set; }
    public DateTime DataDeAplicacao { get; set; }
    public DateTime DataDeValidade { get; set; }
    public TimeSpan Durabilidade { get; set; }
    public int PetID { get; set; }

    public Vacina() {

    }
    
    public Vacina(string nome, DateTime dataDeAplicacao, DateTime dataDeValidade, TimeSpan durabilidade, int petID)
    {
        Nome = nome;
        DataDeAplicacao = dataDeAplicacao;
        DataDeValidade = dataDeValidade;
        Durabilidade = durabilidade;
        PetID = petID;
    }

    public Vacina(DAO.Vacina vacina) : this(vacina.Nome, vacina.DataDeAplicacao, vacina.DataDeValidade, vacina.Durabilidade, vacina.PetID)
    {
        ID = vacina.ID;
    }
}
