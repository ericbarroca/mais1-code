using Libs.DAO;

namespace Libs.Repository
{
    public class MedicamentoRepository:Repository<DAO.Medicamento>, IRepository<DAO.Medicamento>
    {
        public MedicamentoRepository()
        {
            items = new List<DAO.Medicamento>
            {
                new DAO.Medicamento("Paracetamol", "Dor de cabeça"),
                new DAO.Medicamento("Amoxicilina", "Infecção bacteriana")
            };
        }

        public Medicamento Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Medicamento> List()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Upsert(Medicamento entidade)
        {
            throw new NotImplementedException();
        }
    }
}