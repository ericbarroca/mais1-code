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

O Polimorfiso serve para que possamos atribuir comportamentos distintos a medida que criamos classes derivadas de outras e queremos fazer mudanças em alguns comportamentos. Notem, que para poder mudar o comportamento da função da classe pai, esta deve ter o modificador `virtual` enquanto a função que está na classe filha e sobrescreverá o comportamento, deve ter o modificador `override`.

O uso do Polimorfismo nos permite simplificar nosso código e tratar objetos como o seu tipo pai, porém garantindo o comportamento específico dos filhos, como mostrado no exemplo abaixo.

#### Exemplo Pizza

Arquivo `pizza.cs`

```csharp
public class Produto {

    public int ID{get;set;}
    public string Tamanho {get; private set;}
    public string[] Adicionais{get;private set;}

    public decimal Valor{get; internal set;}

    public Produto(int id, string tamanho) {
        ID = id;
        Tamanho = tamanho;
    }

    public virtual void CalcularPreco(params string[] adicionais) {
        if(Tamanho == "pequeno") {
            Valor+=10;
        } else if(Tamanho == "medio") {
            Valor+=15;
        } else {
            Valor+=20;
        }

        //Calcular Adicionais
        if (adicionais == null) {
            return;
        }

        Adicionais = adicionais;
        Valor+=adicionais.GetLength(0)*5;
    }
}

public class Pizza:Produto {

    public Pizza(int id, string sabor, string tamanho)
    : base(id, tamanho) {
        Sabor = sabor;
    }

    public string Sabor {get; private set;}

    public override void CalcularPreco(params string[] adicionais) {
        base.CalcularPreco(adicionais);
        
        if (Sabor == "mussarela") {
            Valor*=2;
        } else {
            Valor*=3;
        }
        
    }
}

public class Esfiha : Produto {

    public string Sabor {get; private set;}

    public Esfiha(int id, string sabor, string tamanho) : 
    base(id,tamanho) {
        Sabor = sabor;
    }

    public override void CalcularPreco(params string[] adicionais){
        base.CalcularPreco(adicionais);
        
        if(Sabor == "carne") {
            Valor+=5;
        } else {
            Valor+=8;
        }
    }

}
```

Arquivo `Program.cs`

```csharp
Pizza pizzaMussarela = new Pizza(1, "mussarela", "pequeno");
// Pizza pizzaCalabresa = new Pizza(2,"calabresa","pequeno");
Esfiha esfihaCarne = new Esfiha(3, "carne", "grande");

Produto p = new Produto(4,"medio");
Animal a = new Cachorro();


void Total(params Produto[] produtos)
{

    decimal total = 0;
    for (int i = 0; i < produtos.Length; i++)
    {
        produtos[i].CalcularPreco();
        total += produtos[i].Valor;
    }

    Console.WriteLine(total);
}

Total(pizzaMussarela, esfihaCarne);
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

Repare que na classe abstarta não se implementam as funções, apenas se cria a assinatura do método, para ser implementado por suas classes filhas. Toda classe filha que herdar de uma classe abstrata será obrigada a implementar (override) todas as funções `abstract` da classe pai.

É importante saber que não podemos criar uma instância da classe pai, somente de suas classes filhas.

#### Exemplo Geometria

Arquivo `geometria.cs`

```csharp
/*
Crie uma classe abstrata chamada FormaGeometrica com um método
abstrato CalcularArea. Em seguida, crie duas subclasses Retangulo
e Circulo, cada uma implementando o método CalcularArea.
Teste as classes criando instâncias de Retangulo e Circulo, 
e chamando o método CalcularArea.
*/

public abstract class FormaGeometrica {
    public abstract double CalcularArea(double x, double y);
}

public class Retangulo : FormaGeometrica
{
    public override double CalcularArea(double x, double y)
    {
        return x*y;
    }
}

public class Circulo : FormaGeometrica
{
    public override double CalcularArea(double x, double y)
    {
        return x*y*y;
    }
}
```

Arquivo `Program.cs`

```csharp
FormaGeometrica retangulo = new Retangulo();
FormaGeometrica circulo = new Circulo();

double areaRet = retangulo.CalcularArea(2,2);
double areaCirc = circulo.CalcularArea(Math.PI,2);

Console.WriteLine(areaRet);
Console.WriteLine(areaCirc);
```

## Referências

- [Tutorials - C# Fundamentals, Microsoft](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/tutorials/oop)