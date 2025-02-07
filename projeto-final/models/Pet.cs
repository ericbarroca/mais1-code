namespace ProjetoFinal.Models;

public enum Especie {
    cachorro,
    gato
}

public class Pet {
    public int ID {get; set;}

    public string Nome {get;set;}

    public DateTime DataNascimento {get;set;}

    public Especie Especie {get;set;}

    public string Raca {get;set;}

    public Pet(string nome, DateTime dataNascimento,
    Especie especie, string raca) {

        this.Nome = nome;
        this.DataNascimento = dataNascimento;
        this.Especie = especie;
        this.Raca = raca;
    }

    public Pet(ProjetoFinal.DAO.Pet pet): this(pet.Nome,
    pet.DataNascimento, (Especie)pet.Especie, pet.Raca) {
        this.ID = pet.ID;
    }
}