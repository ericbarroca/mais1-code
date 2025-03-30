namespace Libs.Repository
{
    using Libs.Models;
    using Libs.DAO;

    public class ConsultaRepository : Repository<DAO.Consulta>, IRepository<DAO.Consulta>
    {
        public ConsultaRepository() : base() 
        {
            items.Add(new DAO.Consulta {
                NomeDoutor = "Marcelo",
                DataConsulta = new DateTime(2024, 02, 12),
                Telefone = 987564536
            });
        }
    }
}