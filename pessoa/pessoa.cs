// Definição de uma classe Pessoa
public class Pessoa {
    // Atributos
    private string nome;
    private int idade;


    //Metodos publicos para acessar atributos
    public void SetNome(string nome){
        this.nome = nome;
    }

    public string GetNome(){
        return nome;
    }


        public void SetIdade(int idade){
        this.idade = idade;
    }

        public int GetIdade(){
        return idade;
    }
    // Métodos
    public void ExibirDetalhes() {

        if(ComprimentoCabelo > 0){
        Console.WriteLine($"Nome: {Nome}, CM: {ComprimentoCabelo} Idade: {Idade}");
        } else {
            Console.WriteLine($"Nome: {Nome}, Idade: {Idade}");
        }

    }
}
