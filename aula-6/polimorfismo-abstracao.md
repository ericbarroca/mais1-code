# Orientação a Objeto

## Conceitos Básicos
### Polimorfismo
Polimorfismo: É a capacidade de usar o mesmo método de maneiras diferentes. Pode ser alcançado através de sobrecarga de método e sobrescrita de método.

```csharp
public class Forma {
    public virtual void Desenhar() {
        Console.WriteLine("Desenhando uma forma.");
    }
}

public class Circulo : Forma {
    public override void Desenhar() {
        Console.WriteLine("Desenhando um círculo.");
    }
}

// Uso do polimorfismo
Forma forma = new Circulo();
forma.Desenhar();  // Saída: Desenhando um círculo.

```

### Abstração
Abstração: É o processo de simplificar sistemas complexos, destacando apenas os aspectos essenciais e ocultando os detalhes desnecessários.

```csharp
public abstract class Forma {
    public abstract void Desenhar();
}

public class Retangulo : Forma {
    public override void Desenhar() {
        Console.WriteLine("Desenhando um retângulo.");
    }
}

// Uso da abstração
Forma forma = new Retangulo();
forma.Desenhar();  // Saída: Desenhando um retângulo.
```

### Exemplo veículos

```csharp
public class Veiculo
{

    public Veiculo(string motor)
    {
        this.motor = motor;
    }

    private string motor { get; }
    public int Velocidade { get; set; }

    public int Locomover(int tempo)
    {
        Console.WriteLine($"Locomovi com o motor: {motor}");
        return Velocidade * tempo;
    }
}

public class Carro : Veiculo
{

    public Carro(string motor, int tamanhoPortaMalas,
     string categoria) : base(motor)
    {
        this.TamanhoPortaMalas = tamanhoPortaMalas;
        this.Categoria = categoria;
    }

    public int TamanhoPortaMalas {get;}

    public string Categoria{get;} //Black, Confort, x
}

public class Moto : Veiculo
{

    public Moto(string motor) : base(motor)
    {

    }

    private bool levaPassageiro;
}

Carro camaro = new Carro("V8", 50, "UberX");
camaro.Velocidade = 80;
int distancia = camaro.Locomover(2);
Console.WriteLine(distancia);
Console.WriteLine(camaro.Categoria);

Moto ninja = new Moto("600cc");
ninja.Velocidade = 100;
distancia = ninja.Locomover(1);
Console.WriteLine(distancia);
string cat = ninja.Categoria;
```

## Referências

- [Tutorials - C# Fundamentals, Microsoft](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/tutorials/oop)