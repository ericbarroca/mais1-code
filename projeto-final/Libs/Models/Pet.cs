using Libs.Repository;
using System.Data;

namespace Libs.Models;

public enum Especie
{
    cachorro,
    gato
}

public class Pet
{
    public int ID { get; set; }

    public string Nome { get; set; }

    public DateTime DataNascimento { get; set; }

    public Especie Especie { get; set; }

    public string Raca { get; set; }

    public Documento TutorID { get; set; }

    public Pet()
    {

    }

    public Pet(string nome, DateTime dataNascimento,
    Especie especie, string raca)
    {

        this.Nome = nome;
        this.DataNascimento = dataNascimento;
        this.Especie = especie;
        this.Raca = raca;
    }

    public Pet(DAO.Pet pet) : this(pet.Nome,
    pet.DataNascimento, (Especie)pet.Especie, pet.Raca)
    {
        this.ID = pet.ID;
        this.TutorID = pet.TutorID;
    }

    public List<Vacina> Vacinas(VacinaRepository vacinaRepository)
    {
        List<Vacina> vacinas = vacinaRepository.List();
        return vacinas.FindAll(t => t.PetID == ID).ToList();
    }

    public bool UpsertVacina(VacinaRepository vacinaRepository, Vacina vacina)
    {
        vacina.PetID = ID;
        return vacinaRepository.Upsert(vacina);
    }

    public List<Consulta> Consultas(ConsultaRepository consultaRepository)
    {
        List<Consulta> consultas = consultaRepository.List();
        return consultas.FindAll(p => p.ID == ID).ToList();
         
    }

    public bool UpsertConsulta(ConsultaRepository consultaRepository, Consulta consulta)
    {
        consulta.PetID = ID;
        return consultaRepository.Upsert(consulta);
    }

    public bool RemoveConsulta(ConsultaRepository consultaRepository, int consultaID) {
        return consultaRepository.Remove(consultaID);
    }
}