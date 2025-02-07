namespace ProjetoFinal.DAO;


public class Pet {
    public int ID {get; set;}

    public string Nome {get;set;}

    public DateTime DataNascimento {get;set;}

    public int Especie {get;set;}

    public string Raca {get;set;}

    public Pet(string nome, DateTime dataNascimento,
    int especie, string raca) {

        this.Nome = nome;
        this.DataNascimento = dataNascimento;
        this.Especie = especie;
        this.Raca = raca;
    }

    public Pet(ProjetoFinal.Models.Pet pet):this(pet.Nome,
    pet.DataNascimento,(int)pet.Especie,pet.Raca) {
        this.ID = pet.ID;
    }
}