namespace Libs.DAO;

using Libs.Models;
using Libs.Repository;

public class Tutor
{
    public string Nome { get; set; }

    public DateTime DataNascimento { get; set; }

    public string Endereco { get; set; }

    public int Telefone { get; set; }

    public Documento Documento { get; set; }
    public Tutor()
    {

    }
    public Tutor(string nome, DateTime dataNascimento, string endereco, int telefone)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Endereco = endereco;
        Telefone = telefone;
    }

    public Tutor(DAO.Tutor tutor) : this(tutor.Nome, tutor.DataNascimento, tutor.Endereco,
      tutor.Telefone)
    {
        Documento = tutor.Documento;
    }

}