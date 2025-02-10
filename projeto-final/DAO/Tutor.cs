namespace ProjetoFinal.DAO;

using ProjetoFinal.Models;
using ProjetoFinal.Repository;

public class Tutor : PetRepository{

    public string NomeTutor {get; set;}

    public DateTime DataNascimentoTutor {get; set;}

    public string EnderecoTutor {get; set;}

    public int TelefoneTutor {get; set;}

    public DocumentoTutor TipoDocumento {get; set;}

    public string NumeroDocumento {get; set;}


    public Tutor(string nomeTutor, DateTime dataNascimentoTutor, string enderecoTutor, int telefoneTutor)
    {
        NomeTutor = nomeTutor;
        DataNascimentoTutor = dataNascimentoTutor;
        EnderecoTutor = enderecoTutor;
        TelefoneTutor = telefoneTutor;
        
    }

    public Tutor(ProjetoFinal.DAO.Tutor tutor): this(tutor.NomeTutor, tutor.DataNascimentoTutor, tutor.EnderecoTutor, tutor.TelefoneTutor) {
        this.TipoDocumento = tutor.TipoDocumento; 
        this.NumeroDocumento = tutor.NumeroDocumento;
    }

}