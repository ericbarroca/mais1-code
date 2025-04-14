namespace Libs.Repository
{
    using Libs.Models;
    using Libs.DAO;
    using System.Collections.Generic;

    public class ConsultaRepository : Repository<DAO.Consulta>
    {
        private PetRepository petRepository;
        
        public void VacinaRepository(PetRepository petRepository) 
        {
            this.petRepository = petRepository;
        }

        public List<Models.Consulta> List()
        {
            List<Models.Consulta> Consultas = new List<Models.Consulta>();

            foreach(DAO.Consulta consulta in items) {
                Consultas.Add(new Models.Consulta(consulta));
            }

            return Consultas;
        }

        public Models.Consulta Get(int id)
        {
            DAO.Consulta consulta = items.SingleOrDefault(p => p.ID == id);

            if (consulta is null)
            {
                return null;
            }

            return new Models.Consulta(consulta);
        }

        public bool Upsert(Models.Consulta entidade)
        {
            if(entidade.PetID == null) {
                throw new NullReferenceException("Uma vacina precisa de um pet");
            }

            if(petRepository.Get(entidade.PetID) is null) {
                throw new Exception("Pet não encontrado na base");
            }

            if (entidade.ID == 0)
            {
                int maxID = 0;

            if (items.Count > 0) {
                maxID =  items.Max(p=>p.ID);
            }

            entidade.ID = maxID+1;
            items.Add(new DAO.Consulta(entidade));
            
            return true;
            }

            DAO.Consulta consulta = items.SingleOrDefault(p => p.ID == entidade.ID);

            if (consulta is null)
            {
                return false;
            }


            consulta.ID = entidade.ID;
            consulta.NomeDoutor = entidade.NomeDoutor;
            consulta.DataConsulta = entidade.DataConsulta;
            consulta.Diagnostico = entidade.Diagnostico;
            consulta.Telefone = entidade.Telefone;
            consulta.PetID = entidade.PetID;


            return true;
        }

        public bool Remove(int id)
        {
            if (id <= 0) {
                return false;
            }

            DAO.Consulta consulta = items.SingleOrDefault(p=>p.ID == id);

            if(consulta is null) {
                return false;
            }

            return items.Remove(consulta);
        }
    }
}