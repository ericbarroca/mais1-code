namespace ProjetoFinal.DAO;
public class Vacina{
    public int Id {get; set;}
    public string Nome {get; set;}
    public string Efeito {get; set;}
    public DateTime DataDeAplicacao {get; set;}
    public DateTime DataDeValidade {get; set;}
    public Timestamp Durabilidade {get; set;}
}