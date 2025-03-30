namespace Libs.Repository
{
    public class MedicamentoRepository
    {
        private readonly List<Medicamento> _medicamentos;

        public MedicamentoRepository()
        {
            _medicamentos = new List<Medicamento>
            {
                new Medicamento("Paracetamol", "Dor de cabeça"),
                new Medicamento("Amoxicilina", "Infecção bacteriana")
            };
        }
    }
}