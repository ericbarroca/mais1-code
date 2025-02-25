using System.Reflection.Metadata;
using Libs.Models;

namespace Libs.DAO;


public class Pet {
    public int ID {get; set;}

    public string Nome {get;set;}

    public DateTime DataNascimento {get;set;}

    public int Especie {get;set;}

    public string Raca {get;set;}

    public Documento TutorID {get;set;}

    public Pet(string nome, DateTime dataNascimento,
    int especie, string raca, Documento tutorID) {

        this.Nome = nome;
        this.DataNascimento = dataNascimento;
        this.Especie = especie;
        this.Raca = raca;
        this.TutorID = new Documento(tutorID.Tipo, tutorID.Numero);
    }

    public Pet(Models.Pet pet):this(pet.Nome,
    pet.DataNascimento,(int)pet.Especie,pet.Raca, pet.TutorID) {
        this.ID = pet.ID;
    }
}