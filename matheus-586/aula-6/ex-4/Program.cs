// - Crie uma classe abstrata chamada `FormaGeometrica` com um método abstrato `CalcularArea`. Em seguida, crie duas subclasses `Retangulo` e `Circulo`, cada uma implementando o método `CalcularArea`. Teste as classes criando instâncias de `Retangulo` e `Circulo`, e chamando o método `CalcularArea`.


abstract class FormaGeometrica
{

  public abstract void CalcularArea(int b, int altura);

}

class Retangulo : FormaGeometrica
{
  public override void CalcularArea(int B, int H)
  {
    Console.WriteLine("A Área desse retangulo é: " + (B*H));
  }
}

class Circulo : FormaGeometrica
{
  public override void CalcularArea(int Pi, int Raio)
  {
    Console.WriteLine("A Área desse circulo é: " + (Pi*(Raio*Raio)));
  }
}

class Program
{
  static void Main(string[] args)
  {
    Retangulo retangulo = new Retangulo();
    retangulo.CalcularArea( 5,  6);
    
    Circulo circulo = new Circulo();
    circulo.CalcularArea( (22/7),  6);
  }
}