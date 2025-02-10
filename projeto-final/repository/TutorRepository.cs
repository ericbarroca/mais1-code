namespace ProjetoFinal.Repository
{
    using ProjetoFinal.Models;

    public class TutorRepository
    {
        private List<Tutor> tutores = new List<Tutor>();

        // Adicionar tutor
        public void AdicionarTutor(Tutor tutor)
        {
            tutores.Add(tutor);
        }

        // Listar tutores
        public List<Tutor> ListarTutores()
        {
            return tutores;
        }

        // Buscar tutor por ID
        public Tutor BuscarTutor(string numeroDocumento)
        {
            tutores.FirstOrDefault(t => t.NumeroDocumento == numeroDocumento);

            return new Tutor(tutores);
        }
    }
}