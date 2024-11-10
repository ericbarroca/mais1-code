# Interfaces e Listas

Nesta aula, exploraremos interfaces, listas e filas em C#. Interfaces são um dos principais pilares da Programação Orientada a Objetos, fornecendo uma maneira de definir contratos que classes e estruturas podem implementar. Vamos ver como as listas e filas utilizam interfaces para fornecer uma estrutura consistente e flexível.

## Interfaces

Uma interface é um contrato que define um conjunto de métodos e propriedades que uma classe ou estrutura deve implementar. Interfaces não contêm implementação, apenas a assinatura dos membros.

### Definição de Interfaces

```csharp
public interface IVeiculo {
    void Acelerar();
    void Frear();
}
```

### Implementação de Interfaces

```csharp
public class Carro : IVeiculo {
    public void Acelerar() {
        Console.WriteLine("Carro acelerando.");
    }
    
    public void Frear() {
        Console.WriteLine("Carro freando.");
    }
}
```

### Vantagens das Interfaces

- **Polimorfismo**: Permite tratar diferentes classes de maneira uniforme.

- **Desacoplamento**: Separa a definição de métodos e propriedades da implementação.

- **Flexibilidade**: Facilita a alteração de implementações sem mudar o código que as usa.

## Listas

Uma lista é uma coleção genérica que pode armazenar um número variável de elementos. A classe `List<T>` em C# implementa a interface `IList<T>`, fornecendo métodos para manipulação de listas.

### Uso de Listas

```csharp
List<int> numeros = new List<int>();
numeros.Add(1);
numeros.Add(2);
numeros.Add(3);

foreach (int numero in numeros) {
    Console.WriteLine(numero);
}

```
### Interface `IList<T>`

A interface `IList<T>` define métodos como `Add`, `Remove`, `Clear`, `Contains`, entre outros. Isso garante que todas as implementações de listas forneçam funcionalidade consistente.

```csharp
public interface IList<T> : ICollection<T> {
    T this[int index] { get; set; }
    int IndexOf(T item);
    void Insert(int index, T item);
    void RemoveAt(int index);
}
```

### Métodos Comuns de Listas

- `Add(T item)`: Adiciona um item à lista.

- `Remove(T item)`: Remove a primeira ocorrência de um item específico da lista.

- `Contains(T item)`: Determina se a lista contém um elemento específico.

- `Insert(int index, T item)`: Insere um elemento na lista no índice especificado.

### Buscas em Listas

Um predicado é uma função que retorna um valor booleano (`true` ou `false`) com base na avaliação de uma condição. Em C#, predicados são usados frequentemente com listas para encontrar, filtrar ou manipular elementos que atendem a certas condições. Eles são especialmente úteis quando combinados com métodos da classe `List<T>`.

Aqui está um exemplo de um predicado que verifica se um número é par:

```csharp
bool EhPar(int numero) {
    return numero % 2 == 0;
}
```

#### `Find`
O método `Find` retorna o primeiro elemento de uma lista que corresponde a um predicado especificado.

```csharp
List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6 };
int primeiroPar = numeros.Find(EhPar);

Console.WriteLine(primeiroPar);  // Saída: 2
```

#### `FindAll`
O método `FindAll` retorna todos os elementos de uma lista que correspondem a um predicado especificado.

```csharp
List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6 };
List<int> numerosPares = numeros.FindAll(EhPar);

foreach (int numero in numerosPares) {
    Console.WriteLine(numero);  // Saída: 2, 4, 6
}
```

#### `Exists`
O método `Exists` verifica se existe pelo menos um elemento na lista que corresponde ao predicado especificado.

```csharp
List<int> numeros = new List<int> { 1, 3, 5, 7 };
bool existePar = numeros.Exists(EhPar);

Console.WriteLine(existePar);  // Saída: False
```

#### `RemoveAll`
O método `RemoveAll` remove todos os elementos da lista que correspondem ao predicado especificado.

```csharp
List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6 };
numeros.RemoveAll(EhPar);

foreach (int numero in numeros) {
    Console.WriteLine(numero);  // Saída: 1, 3, 5
}
```

## Filas

Uma fila é uma coleção que segue a ordem **FIFO** (primeiro a entrar, primeiro a sair), onde o primeiro elemento inserido é o primeiro a ser removido. 

### Uso de Filas

```csharp
Queue<string> fila = new Queue<string>();
fila.Enqueue("Primeiro");
fila.Enqueue("Segundo");
fila.Enqueue("Terceiro");

while (fila.Count > 0) {
    Console.WriteLine(fila.Dequeue());
}
```

### Métodos Comuns de Filas

- `Enqueue(T item)`: Adiciona um item ao final da fila.

- `Dequeue()`: Remove e retorna o item do início da fila.

- `Peek()`: Retorna o item no início da fila sem removê-lo.

- `Count`: Obtém o número de elementos na fila.