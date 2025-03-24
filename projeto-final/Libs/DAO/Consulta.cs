namespace Libs.DAO;

public class Consulta
{
    public string NomeDoutor { get; set; }

    public DateTime DataConsulta { get; set; }

    public string Diagnostico { get; set; }

    public int Telefone { get; set; }

    public Consulta(string nomeDoutor, DateTime dataConsulta, int telefone)
    {
        NomeDoutor = nomeDoutor;
        DataConsulta = dataConsulta;
        Telefone = telefone;
    }

    public Consulta(Models.Consulta Consulta) : this(Consulta.NomeDoutor, Consulta.DataConsulta, Consulta.Telefone)
    {
        Diagnostico = Consulta.Diagnostico;
    }
}
