// - Praticar a criação de classes e instâncias de objetos. Descrição: Crie uma classe chamada `Carro` com os seguintes atributos: `Marca`, `Modelo` e `Ano`. Adicione um método chamado `ExibirDetalhes` que exiba os detalhes do carro. Em seguida, crie uma instância da classe `Carro`, atribua valores aos atributos e chame o método para exibir os detalhes.

public class Carro{
    public string Marca;
    public string Modelo;
    public int Ano;

    public void ExibirDetalhes(){
        Console.WriteLine($"Marca: {Marca}, Modelo: {Modelo}, Ano: {Ano}");
    }
}