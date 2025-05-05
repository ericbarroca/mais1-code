// - Praticar a criação de classes e instâncias de objetos. Descrição: Crie uma classe chamada `Carro` com os seguintes atributos: `Marca`, `Modelo` e `Ano`. Adicione um método chamado `ExibirDetalhes` que exiba os detalhes do carro. Em seguida, crie uma instância da classe `Carro`, atribua valores aos atributos e chame o método para exibir os detalhes.

public class Carro {
    // Atributos
    public string Marca;
    public string Modelo;
    public int Ano;
    
    // Métodos
    public void ExibirDetalhes() {
        Console.WriteLine("Você tem um carro da " + $"Marca: {Marca}, Modelo: {Modelo} e Ano: {Ano}");
    }
}