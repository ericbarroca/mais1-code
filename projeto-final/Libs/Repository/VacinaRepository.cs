using Libs.Models;

namespace Libs.Repository
{
    public class VacinaRepository : Repository<DAO.Vacina>
    {
        private PetRepository petRepository;

        public VacinaRepository(PetRepository petRepository)
        {
            this.petRepository = petRepository;
        }


        public Vacina Get(int id)
        {
            DAO.Vacina vacina = items.SingleOrDefault(v => v.ID == id);

            if (vacina is null)
            {
                return null;
            }

            return new Vacina(vacina);
        }


        public bool Upsert(Vacina entidade)
        {

            if (entidade.PetID == 0)
            {
                throw new NullReferenceException("A vacina precisa estar associada a um pet.");
            }


            if (petRepository.Get(entidade.PetID) is null)
            {
                throw new Exception("Pet não encontrado na base.");
            }


            if (entidade.ID == 0)
            {
                int maxID = 0;
                if (items.Count > 0)
                {
                    maxID = items.Max(v => v.ID);
                }

                entidade.ID = maxID + 1;
                items.Add(new DAO.Vacina(entidade));
                return true;
            }


            DAO.Vacina vacina = items.SingleOrDefault(v => v.ID == entidade.ID);

            if (vacina is null)
            {
                return false;
            }


            vacina.Nome = entidade.Nome;
            vacina.DataDeAplicacao = entidade.DataDeAplicacao;
            vacina.DataDeValidade = entidade.DataDeValidade;
            vacina.Durabilidade = entidade.Durabilidade;

            return true;
        }

        public List<Vacina> List()
        {
            List<Vacina> vacinas = new List<Vacina>();
            foreach (DAO.Vacina vacina in items)
            {
                vacinas.Add(new Vacina(vacina));
            }

            return vacinas;
        }
    }
}