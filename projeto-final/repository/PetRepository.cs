using ProjetoFinal.Models;

namespace ProjetoFinal.Repository;

public class PetRepository : Repository<DAO.Pet>, IRepository<Pet>
{

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
}