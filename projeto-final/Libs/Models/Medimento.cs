namespace Libs.Models;

public class Medicamento
{
    public string Nome { get; set; }
    public string Motivo { get; set; }

    public Medicamento(string nome, string motivo)
    {
        Nome = nome;
        Motivo = motivo;
    }

    public Medicamento(DAO.Medicamento medicamento) : this(medicamento.Nome, medicamento.Motivo)
    {

    }
}