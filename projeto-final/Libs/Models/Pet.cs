namespace Libs.Models;

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

    public Documento TutorID {get;set;}

    public Pet() {
        
    }

    public Pet(string nome, DateTime dataNascimento,
    Especie especie, string raca, Documento tutorID) {

        this.Nome = nome;
        this.DataNascimento = dataNascimento;
        this.Especie = especie;
        this.Raca = raca;
        this.TutorID = new Documento(tutorID.Tipo, tutorID.Numero);
    }

    public Pet(DAO.Pet pet): this(pet.Nome,
    pet.DataNascimento, (Especie)pet.Especie, pet.Raca, pet.TutorID) {
        this.ID = pet.ID;
    }
}