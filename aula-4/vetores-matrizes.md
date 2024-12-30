# Vetores e Matrizes

> [!IMPORTANT] 
> Primeiro, passe pelo material sobre condicionais e loops [aqui](condicionais-loops.md). 

Um `vetor` (ou `array`) é uma coleção de elementos do mesmo tipo, armazenados em posições sequenciais na memória. Cada elemento pode ser acessado por um índice. Vetores podem ser de qualquer tipo (`string`, `int`...), assim como seus índices, mas para nossos casos vamos trabalhar comente com índices inteiros. Os vetores são utilizados como variáveis para quando precisamos armazenar sequências, como por exemplo, os números de 1 a 10 e queremos buscá-los baseados em que posição se encontram (índice).

## Declaração e Inicialização de Vetores

```csharp
// Declaração
int[] numeros;

// Inicialização
numeros = new int[5];

// Declaração e Inicialização
int[] idades = new int[3] { 20, 30, 40 };
```

## Acessando Elementos do Vetor

```csharp
int[] numeros = new int[3] { 10, 20, 30 };

Console.WriteLine(numeros[0]); 
Console.WriteLine(numeros[2]); 
Console.WriteLine(numeros[1]); 
```

<details>
<summary><b>O que será escrito na tela no exemplo acima?</b></summary>

```shell
10
30
20
```
</details>

## Iterando sobre um Vetor

Aqui temos um exemplo de como imprimir cada item do vetor na tela do usuário de forma dinâmica usando loops.
```csharp
int[] numeros = new int[3] { 10, 20, 30 };

for (int i = 0; i < numeros.Length; i++) {
    Console.WriteLine(numeros[i]);
}
```

Agora que já passamos por vetores, uma matriz nada mais é que um vetor de vetores, permitindo armazenar dados em uma grade bidimensional ou multidimensional. Quando temos uma tabela com linhas e colunas, temos uma matriz de 2 dimensões por exemplo.

## Declaração e Inicialização de Matrizes

```csharp
// Declaração e Inicialização
int[,] matriz = new int[2, 2] {
    { 1, 2 },
    { 3, 4 }
};
```

Repare que na declarção do tipo da matriz do exemplo (`int[,]`) temos 2 indíces, 1 antes e 1 depois da virgula. Numa matriz 2x2 (tabela) eles seriam o número da linha e o da coluna respectivamente. Ao passar uma linha e coluna em uma tabela achamos a célula que contém o valor desejado.

## Acessando Elementos da Matriz
```csharp
int[,] matriz = new int[2, 2] {
    { 1, 2 },
    { 3, 4 }
};

Console.WriteLine(matriz[0, 0]); 
Console.WriteLine(matriz[0, 1]); 
Console.WriteLine(matriz[1, 0]); 
Console.WriteLine(matriz[1, 1]); 
```

<details>
<summary><b>O que será escrito na tela no exemplo acima?</b></summary>

```shell
1
2
3
4
```
</details>

## Iterando sobre uma Matriz
```csharp
int[,] matriz = new int[2, 2] {
    { 1, 2 },
    { 3, 4 }
};

for (int i = 0; i < matriz.GetLength(0); i++) {
    for (int j = 0; j < matriz.GetLength(1); j++) {
        Console.WriteLine(matriz[i, j]);
    }
}
```

`GetLength(...)` é uma função do `Array` que permite descobrirmos o tamanho de uma dimensão da matriz. Logo, se usamos `GetLength(0)`, saberemos o tabanho da linha.

### Exemplo Soma de Matrizes

O programa abaixo contém uma função que criar matrizes de 2 dimensões e uma que soma as 2, retornando uma matriz com o resultado.

```csharp
int[,] CriaMatriz2D(int tamanhoD1, int tamanhoD2) {
    int [,] m = new int[tamanhoD1,tamanhoD2];

    for(int linha=0;linha<m.GetLength(0);linha++) {
        for(int coluna=0;coluna<m.GetLength(1);coluna++) {
            m[linha,coluna] = int.Parse(Console.ReadLine());
        }
    }

    return m;
}

int[,] m1 = CriaMatriz2D(2,2);
int[,] m2 = CriaMatriz2D(2,2);

int[,] Soma(int[,] m1, int[,] m2) {
    int[,] m = new int[m1.GetLength(0),m1.GetLength(1)];

    for(int linha=0;linha<m.GetLength(0);linha++) {
        for(int coluna=0;coluna<m.GetLength(1);coluna++) {
            m[linha,coluna] = m1[linha, coluna] + 
                m2[linha,coluna];
            Console.WriteLine(m[linha, coluna]);
        }
    }

    return m;
}
```

## Referencias

- [Matrizes - C# Language Reference, Microsoft](https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/builtin-types/arrays)