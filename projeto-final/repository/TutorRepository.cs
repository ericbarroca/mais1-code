namespace ProjetoFinal.Repository
{
    using ProjetoFinal.Models;

    public class TutorRepository : Repository<DAO.Tutor>, IRepository<Tutor>
    {
        public Tutor Get(int id)
        {
            DAO.Tutor tutor = items.SingleOrDefault(t => t.Documento.Numero == id);

            if (tutor is null)
            {
                return null;
            }

            return new Tutor(tutor);
        }

        public bool Upsert(Tutor entidade)
        {
            DAO.Tutor tutor = items.SingleOrDefault(t=>t.Documento.Numero == entidade.Documento.Numero);

            if(tutor is null) {
                tutor = new DAO.Tutor(entidade);
                items.Add(tutor);
                return true;
            }


            tutor.DataNascimento = entidade.DataNascimento;
            tutor.Documento = new Documento(entidade.Documento.Tipo, entidade.Documento.Numero);
            tutor.Endereco = entidade.Endereco;
            tutor.Nome = entidade.Nome;
            tutor.Telefone = entidade.Telefone;

            return true;
        }

        public bool Remove(int id)
        {
            DAO.Tutor tutor = items.SingleOrDefault(t=>t.Documento.Numero==id);

            if(tutor is null) {
                return false;
            }

            return items.Remove(tutor);
        
        }

        public List<Tutor> List()
        {
            List<Tutor> tutores = new List<Tutor>();
            foreach (DAO.Tutor tutor in items)
            {
                tutores.Add(new Tutor(tutor));
            }

            return tutores;
        }
    }
}