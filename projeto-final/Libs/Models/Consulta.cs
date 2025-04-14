namespace Libs.Models;

public class Consulta
{
    public int ID { get; set;}

    public string NomeDoutor { get; set; }

    public DateTime DataConsulta { get; set; }

    public string Diagnostico { get; set; }

    public int Telefone { get; set; }

    public int PetID {get;set;}

    public Consulta(string nomeDoutor, DateTime dataConsulta, int telefone, string diagnostico, int petID)
    {
        NomeDoutor = nomeDoutor;
        DataConsulta = dataConsulta;
        Telefone = telefone;
        Diagnostico = diagnostico;
        PetID = petID;
    }

    public Consulta(DAO.Consulta consulta) : this(consulta.NomeDoutor, consulta.DataConsulta, consulta.Telefone, consulta.Diagnostico, consulta.PetID)
    {
        this.ID = consulta.ID;
    }
}