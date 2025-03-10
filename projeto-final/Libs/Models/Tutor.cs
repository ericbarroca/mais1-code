
using System.Data;
using Libs.Repository;

namespace Libs.Models;


public enum TipoDocumento
{
    RG,
    CPF
}

public class Documento
{

    public TipoDocumento Tipo { get; private set; }

    public int Numero { get; private set; }

    public Documento(TipoDocumento tipo, int numero)
    {
        Tipo = tipo;

        if (!numeroValido(tipo, numero))
        {
            throw new Exception("Documento inválido");
        }

        Numero = numero;
    }

    private bool numeroValido(TipoDocumento tipo, int numero)
    {
        if (tipo == TipoDocumento.CPF)
        {

            if (numero.ToString().Length != 11)
            {
                return false;
            }
        }
        else
        {
            if (numero.ToString().Length != 9)
            {
                return false;
            }
        }

        return true;
    }
}
public class Tutor
{
    public string Nome { get; set; }

    public DateTime DataNascimento { get; set; }

    public string Endereco { get; set; }

    public int Telefone { get; set; }

    private Documento documento;
    public Documento Documento
    {
        get
        {
            return documento;
        }
        set
        {
            if (value is null)
            {
                throw new NoNullAllowedException();
            }

            documento = value;
        }
    }

    public Tutor(string nome, Documento documento,
     DateTime dataNascimento, string endereco, int telefone)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Endereco = endereco;
        Telefone = telefone;
        Documento = documento;

    }

    public Tutor(DAO.Tutor tutor) : this(tutor.Nome,
     tutor.Documento, tutor.DataNascimento, tutor.Endereco,
      tutor.Telefone)
    {
    }

    public List<Pet> Pets(PetRepository petRepository)
    {
        List<Pet> pets = petRepository.List();
        return pets.FindAll(p => p.TutorID.Numero == Documento.Numero)
        .ToList();
    }

    public bool UpsertPet(PetRepository petRepository, Pet pet)
    {
        pet.TutorID = Documento;
        return petRepository.Upsert(pet);
    }

    public bool RemovePet(PetRepository petRepository, int petID) {
        return petRepository.Remove(petID);
    }

}

