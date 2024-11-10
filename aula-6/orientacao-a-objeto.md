# Orientação a Objeto

A Programação Orientada a Objetos (POO) é um paradigma de programação amplamente utilizado na Engenharia de Software para modelar sistemas complexos de maneira intuitiva e organizada. POO permite que os desenvolvedores pensem em termos de objetos do mundo real e suas interações. Nesta aula, vamos explorar os conceitos fundamentais da POO, como classes, objetos, herança, polimorfismo, encapsulamento e abstração.

## Conceitos Básicos
### Classes e Objetos
Classe: Uma classe é uma descrição de um conjunto de objetos que compartilham a mesma estrutura de dados (atributos) e comportamento (métodos). É como um molde para criar objetos.

Objeto: Um objeto é uma instância de uma classe. Ele representa uma entidade do mundo real com características e comportamentos específicos.

```csharp
// Definição de uma classe Pessoa
public class Pessoa {
    // Atributos
    public string Nome;
    public int Idade;
    
    // Métodos
    public void ExibirDetalhes() {
        Console.WriteLine($"Nome: {Nome}, Idade: {Idade}");
    }
}


// Criação de um objeto Pessoa
Pessoa pessoa1 = new Pessoa();
pessoa1.Nome = "João";
pessoa1.Idade = 30;
pessoa1.ExibirDetalhes();

```

Repare que criamos a classe primeiramente pela instrução de `public class Pessoa {}` e definimos seus atributos e métodos. Após termos a declaração dela podemos instanciar seu tipo em uma variável. Recordem que na aula de variáveis falamos que uma variável armazena um dado de um determinado tipo, logo quando criamos uma classe, estamos criando um novo tipo para o C#.

Com isso podemos criar uma variável para armazenar este novo tipo, `Pessoa`, pela declaração de variável que já aprendemos. E como as classes tem atributos (que são variáveis dentro da classe), podemos referenciar eles pela sintaxe `<nome da variável do tipo da classe>.<atributo da classe>`, no caso `pessoa1.Idade`.

### Encapsulamento
Encapsulamento: É o princípio de ocultar os detalhes internos de um objeto e expor apenas o que é necessário. Isso é feito através de modificadores de acesso (public, private, protected).

```csharp
public class Pessoa {
    // Atributos privados
    private string nome;
    private int idade;
    
    // Métodos públicos para acessar os atributos
    public void SetNome(string nome) {
        this.nome = nome;
    }

    public string GetNome() {
        return nome;
    }

    public void SetIdade(int idade) {
        this.idade = idade;
    }

    public int GetIdade() {
        return idade;
    }
}

```
Em C# existem diversos modificadores de acesso, como: `public`, `protected`, `internal`, `private` e `file`. E o nível de permissão de cada modificador é dado abaixo por [Access Modifiers - C# Language Reference, Microsoft](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/access-modifiers).

- `public`: o acesso não é restrito.
- `protected`: o acesso é limitado à classe que os contém ou aos tipos derivados da classe que os contém.
- `internal`: o acesso é limitado ao assembly atual.
- `protected internal`: o acesso é limitado ao assembly atual ou aos tipos derivados da classe que os contém.
- `private`: o acesso é limitado ao tipo recipiente.
- `private protected`: o acesso é limitado à classe que o contém ou a tipos derivados da classe que o contém no assembly atual.
- `file`: o tipo declarado apenas é visível no arquivo de origem atual. Os tipos com escopo de arquivo geralmente são usados para geradores de fonte.

Na forma mais atual da lingiagem costumamos escrever modificadores e atributos como abaixo:

```csharp
public class Pessoa {
    // Atributos privados
    public string Nome {get; private set;}
    private int idade;
    public int CPF {get;}
    
}

```

### Herança
Herança: Permite criar uma nova classe baseada em uma classe existente, aproveitando seus atributos e métodos. A classe existente é chamada de superclasse ou classe base, e a nova classe é chamada de subclasse.

```csharp
public class Animal {
    public void Comer() {
        Console.WriteLine("Comendo...");
    }
}

public class Cachorro : Animal {
    public void Latir() {
        Console.WriteLine("Latindo...");
    }
}

// Uso da herança
Cachorro cachorro = new Cachorro();
cachorro.Comer();
cachorro.Latir();

```

Como visto acima, como o cachorro é um animal ele pode executar a ação de comer além de latir. Como poderiamos criar um Gato que mia?

<details>
<summary><b>Resposta</b></summary>

```csharp
public class Animal {
    public void Comer() {
        Console.WriteLine("Comendo...");
    }
}

public class Cachorro : Animal {
    public void Latir() {
        Console.WriteLine("Latindo...");
    }
}

public class Gato : Animal {
    public void Miar() {
        Console.WriteLine("Miando...");
    }
}

// Uso da herança
Cachorro cachorro = new Cachorro();
cachorro.Comer();
cachorro.Latir();

// Uso da herança
Gato gatinho = new Gato();
gatinho.Miar();
gatinho.Comer();

```
</details>

## Argumentos por Valor e por Referência
### Passagem de Argumentos por Valor

Por Valor: Quando um argumento é passado por valor, uma cópia do valor é feita e passada para o método. Modificações feitas ao argumento dentro do método não afetam a variável original.

```csharp
public void IncrementarPorValor(int numero) {
    numero += 1;
    Console.WriteLine("Dentro do método: " + numero);
}

int x = 10;
IncrementarPorValor(x);
Console.WriteLine("Fora do método: " + x);  // x permanece 10
```

### Passagem de Argumentos por Referência
Por Referência: Quando um argumento é passado por referência, uma referência à variável original é passada para o método. Modificações feitas ao argumento dentro do método afetam a variável original.

```csharp
public void IncrementarPorReferencia(ref int numero) {
    numero += 1;
    Console.WriteLine("Dentro do método: " + numero);
}

int y = 10;
IncrementarPorReferencia(ref y);
Console.WriteLine("Fora do método: " + y);  // y agora é 11
```

>[!IMPORTANT]
> Tipos derivados de classes são sempre passados por referência.

Qual o número de patas no código abaixo?

```csharp
public class Pato {
    public int Patas;
}

Pato pato = new Pato();
pato.Patas = 2;
casar(pato)

void casar(Pato noivo) {
    noivo.Patas +=1;

}

Console.WriteLine(pato.Patas);

```

<details>
<summary><b>Resposta</b></summary>
2
</details>

- [Tutorials - C# Fundamentals, Microsoft](https://learn.microsoft.com/pt-br/dotnet/csharp/fundamentals/tutorials/oop)
