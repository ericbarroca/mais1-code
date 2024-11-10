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

## Referências

- [Tutorials - C# Fundamentals, Microsoft](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/tutorials/oop)