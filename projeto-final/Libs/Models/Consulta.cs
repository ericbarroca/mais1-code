namespace Libs.Models;

public class Consulta
{
    public string NomeDoutor { get; set; }

    public DateTime DataConsulta { get; set; }

    public string Diagnostico { get; set; }

    public int Telefone { get; set; }

        public Consulta(string nomeDoutor, DateTime dataConsulta, string diagnostico, int telefone)
    {
        NomeDoutor = nomeDoutor;
        DataConsulta = dataConsulta;
        Diagnostico = diagnostico;
        Telefone = telefone;
    }

    public Consulta(DAO.Consulta Consulta) : this(Consulta.NomeDoutor, Consulta.DataConsulta, Consulta.Diagnostico, Consulta.Telefone) 
    {

    }
}