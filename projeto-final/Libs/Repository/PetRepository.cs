using Libs.Models;

namespace Libs.Repository;

public class PetRepository : Repository<DAO.Pet>, IRepository<Pet>
{
    private TutorRepository tutorRepository;
    public PetRepository(TutorRepository tutorRepository) {
        this.tutorRepository = tutorRepository;
    }

    public Pet Get(int id)
    {
        DAO.Pet pet = items.SingleOrDefault(p => p.ID == id);

        if (pet is null)
        {
            return null;
        }

        return new Pet(pet);
    }

    public bool Upsert(Pet entidade)
    {
        if(entidade.TutorID == null) {
            throw new NullReferenceException("Um pet precisa ter tutor");
        }

        if(tutorRepository.Get(entidade.TutorID.Numero) is null) {
            throw new Exception("Tutor não encontrado na base");
        }

        if (entidade.ID == 0)
        {
            int maxID = 0;

            if (items.Count > 0) {
                maxID =  items.Max(p=>p.ID);
            }

            entidade.ID = maxID+1;
            items.Add(new DAO.Pet(entidade));
            return true;
        }

        DAO.Pet pet = items.SingleOrDefault(p => p.ID == entidade.ID);

        if (pet is null)
        {
            return false;
        }


        pet.DataNascimento = entidade.DataNascimento;
        pet.Especie = (int)entidade.Especie;
        pet.Nome = entidade.Nome;
        pet.Raca = entidade.Raca;


        return true;

    }

    public bool Remove(int id)
    {
        if (id <= 0) {
            return false;
        }

        DAO.Pet pet = items.SingleOrDefault(p=>p.ID == id);

        if(pet is null) {
            return false;
        }

        return items.Remove(pet);
    }

    public List<Pet> List()
    {
        List<Pet> pets = new List<Pet>();
        foreach(DAO.Pet pet in items) {
            pets.Add(new Pet(pet));
        }

        return pets;
    }

    internal object Get(object value)
    {
        throw new NotImplementedException();
    }
}