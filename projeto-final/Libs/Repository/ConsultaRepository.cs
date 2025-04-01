namespace Libs.Repository
{
    using Libs.Models;
    using Libs.DAO;
    using System.Collections.Generic;

    public class ConsultaRepository : Repository<DAO.Consulta>, IRepository<DAO.Consulta>
    {
        public ConsultaRepository() : base() 
        {
            
        }

        public DAO.Consulta Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<DAO.Consulta> List()
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Upsert(DAO.Consulta entidade)
        {
            throw new NotImplementedException();
        }
    }
}