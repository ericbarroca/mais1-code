
using System.Data;
using ProjetoFinal.Repository;

namespace ProjetoFinal.Models;


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

    private PetRepository petRepository;

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

    private List<Pet> Pets { get; set; }

    public Tutor(PetRepository petRepo)
    {
        petRepository = petRepo;
    }

    public Tutor(PetRepository petRepo, string nome, Documento documento,
     DateTime dataNascimento, string endereco, int telefone,
     List<int> pets) : this(petRepo)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Endereco = endereco;
        Telefone = telefone;
        Documento = documento;
        Pets = LoadPets(pets);

    }

    public Tutor(PetRepository petRepo, DAO.Tutor tutor, List<int> pets) : this(
        petRepo, tutor.Nome,
     tutor.Documento, tutor.DataNascimento, tutor.Endereco,
      tutor.Telefone, pets)
    {
    }

    public List<Pet> ListPets()
    {
        return Pets.ToList();
    }

    private List<Pet> LoadPets(List<int> petIDs)
    {
        List<Pet> pets = petRepository.List();
        List<Pet> meusPets = new List<Pet>();


        foreach (Pet pet in pets)
        {
            if (petIDs.Any(id => id == pet.ID))
            {
                meusPets.Add(pet);
            }
        }

        return meusPets;
    }

    public bool AddPet(int petID) {

        Pet existingPet = petRepository.Get(petID);
        if(existingPet is null) {
            return false;
        }

        Pets.Add(existingPet);
        return true;

    }

}

