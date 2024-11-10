# Condicionais e Loops

Até o momento vimos ferramentas da linguagem que nos ajudam a armazenar valores e a organizar e reutilizar nosso código. Porém ainda não sabemos fazer muita coisa em termos de lógica. Se quisermos por exemplo contar até 5 ou tomar uma decisão caso o dia esteja chuvoso, como poderiamos fazer isso em nossos programas? 

Para isso existem duas ferramentas poderosas e comuns em programação: condicionais e laços de repetição. Ambas são fundamentais para controlar o fluxo de execução do seu programa.

## Condicionais
As condicionais são usadas para executar diferentes blocos de código com base em determinadas condições.

### Estrutura if
A estrutura `if` é usada para verificar uma condição. Se a condição for verdadeira, o bloco de código dentro do `if` é executado.

```csharp
int idade = 20;

if (idade >= 18) {
    Console.WriteLine("Você é maior de idade.");
}
```

### Estrutura else
A estrutura `else` é usada para especificar um bloco de código que é executado se a condição do `if` for falsa.

```csharp
int idade = 16;

if (idade >= 18) {
    Console.WriteLine("Você é maior de idade.");
} else {
    Console.WriteLine("Você é menor de idade.");
}
```

### Estrutura else if
A estrutura else if permite adicionar múltiplas condições em sequência.

```csharp
int temperatura = 15;

if (temperatura < 0) {
    Console.WriteLine("Está muito frio.");
} else if (temperatura < 20) {
    Console.WriteLine("Está frio.");
} else if (temperatura < 30) {
    Console.WriteLine("Está agradável.");
} else {
    Console.WriteLine("Está calor hoje.");
    Console.WriteLine("Lembre-se de se manter hidratado.");
    Console.WriteLine("Use protetor solar.");
}
```

## Tabela Lógica dos Operadores (Tabela Verdade)

Uma tabela-verdade é uma ferramenta usada na lógica para determinar o valor de verdade de uma expressão lógica baseada em todas as combinações possíveis de seus valores de entrada. Em outras palavras, ela ajuda a entender como os operadores lógicos (AND, OR, NOT, etc.) funcionam.

### Operadores Lógicos

- `AND (&&)`: Retorna true se ambas as condições forem verdadeiras.
- `OR (||)`: Retorna true se pelo menos uma das condições for verdadeira.
- `NOT (!)`: Inverte o valor de verdade.

### Tabela-Verdade para o Operador `AND (&&)`
| A |	B |	A && B |
|-------|-------|--------|
| true |	true |	true |
| true |	false |	false |
| false |	true |	false |
| false |	false |	false |

### Tabela-Verdade para o Operador `OR (||)`
| A | B | A \|\| B |
|-------|-------|--------|
| true | true | true | 
| true | false | true | 
| false | true | true | 
| false | false | false |

### Tabela-Verdade para o Operador `NOT (!)`
| A |	!A |
|-------|-------|
| true |	false |
| false |	true |

```csharp
bool chuva = true;
bool temGuardaChuva = false;

if (chuva && temGuardaChuva) {
    Console.WriteLine("Você pode sair sem se molhar.");
} else if (chuva && !temGuardaChuva) {
    Console.WriteLine("Você vai se molhar.");
} else {
    Console.WriteLine("Sem chuva, você está seguro.");
}
```

## Laços de Repetição
Os laços de repetição são usados para executar repetidamente um bloco de código enquanto uma condição é verdadeira.

### Laço for
O laço for é usado quando você sabe de antemão quantas vezes deseja repetir um bloco de código.

```csharp
for (int i = 0; i < 5; i++) {
    Console.WriteLine("Iteração: " + i);
}
```

Repare que o trecho `i++` é um incremento a variável `i` declarada no `for`, a cada iteração ela será acrescida de `1`.

### Laço while
O laço while executa um bloco de código enquanto a condição especificada for verdadeira.

```csharp
int contador = 0;

while (contador < 5) {
    Console.WriteLine("Contador: " + contador);
    contador++;
}
```

Repare que no `while` nós incrementador o `contador` através do `contador++` da mesma forma que fizemos no `for` com a variável `i`.

## Referencias

- [Instruções - C# Programming Guide, Microsoft](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/statements-expressions-operators/statements)