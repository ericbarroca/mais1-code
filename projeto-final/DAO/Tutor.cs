namespace ProjetoFinal.DAO;

using ProjetoFinal.Models;
using ProjetoFinal.Repository;

public class Tutor {

    public string Nome {get; set;}

    public DateTime DataNascimento {get; set;}

    public string Endereco {get; set;}

    public int Telefone {get; set;}

    public Documento Documento {get; set;}

    public List<DAO.Pet> Pets {get;set;}

    public Tutor(string nome, Documento documento, DateTime dataNascimento,
     string endereco, int telefone, List<DAO.Pet> pets)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Documento = new Documento(documento.Tipo, documento.Numero);
        Endereco = endereco;
        Telefone = telefone;
        Pets = pets;
        
    }

    public Tutor(Models.Tutor tutor, List<DAO.Pet> pets): this(tutor.Nome, tutor.Documento,
     tutor.DataNascimento, tutor.Endereco, tutor.Telefone, pets) {
        
    }

}