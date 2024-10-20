# Programação

> "A linguagem de programação é um método padronizado, formado por um conjunto de regras sintáticas e semânticas, de implementação de um código fonte - que pode ser compilado e transformado em um programa de computador,[1] ou usado como script interpretado - que informará instruções de processamento ao computador.[2][Nota 1] Permite que um programador especifique precisamente quais os dados que o computador irá atuar, como estes dados serão armazenados ou transmitidos e, quais ações devem ser tomadas de acordo com as circunstâncias. Linguagens de programação podem ser usadas para expressar algoritmos com precisão." - [[Linguagem de Programação, Wikipidea](https://pt.wikipedia.org/wiki/Linguagem_de_programa%C3%A7%C3%A3o)]

Ao longo dos anos as linguagens de programação vieram evoluindo em busca de se tornarem ferramentas mais produtivas para os desenvolvedores. Isso se converte em linguagens que chamamos de alto nível, onde elas são maís fáceis de serem interpretadas por humanos e fornecem ferramentas que auxiliam no desenvolvimento do código seja aumentando o reuso ou eliminando repetições de código.

É possível observar isso olhando os códigos abaixo em assembly (linguagem de máquina) e C# (linguagem orientada a objeto):

**Assembly** [Fonte: Quora](https://www.quora.com/How-do-I-write-an-assembly-language-program-to-add-two-numbers)
``` assembly
section .data 
    num1 dd 5 
    num2 dd 3 
    result dd 0 
 
section .text 
    global _start 
 
_start: 
    mov eax, num1 
    add eax, num2 
    mov result, eax 
    mov eax, 1 
    int 0x80 
```

**C#**
```csharp 
int num1 = 5
int num2 = 3
int result = num1 + num2
```

## Conceitos e Fundamentos

Existem diversos fundamentos que são importantes para programar e a medida que a complexidade dos códigos aumentam estes fundamentos evoluem e se tornam a diferença entre um código bom e um código ruim.

Porém, para iniciarmos precisamos entender o que é um programa, e o que é a linguagem de programação. A programação só é possível por causa que a matemática existe, e ela tem uma relação bem próximo com a `Teoria das Categorias`, onde podemos ler mais a respeito de forma introudtória em [O que é Teoria das Categorias, Otávio Paulino Pace - Medium](https://medium.com/@otaviopp8/o-que-%C3%A9-teoria-das-categorias-5e7ed0d64a94).

Apesar dessa relação, não vamos nos aprofundar na parte matemática neste curso. Apesar que ao entende-lá as ferramentas das linguagem começam a fazer bem mais sentido. Dito isso, a primeira coisa que precisamos saber é que um computador tem 2 memórias. Uma delas é a "permanente" e a outra é volátil.

A permanente é o `HD/SSD`, onde salvamos os nossos arquivos, fotos e muito mais. O que está salvo no `HD` **não é perdido** quando fechamos uma aplicação ou deligamos nosso computador. Porém, a volátil, que é a memória RAM, **perde informações** quando fechamos um programa ou desligamos nosso PC.

Então quando instalamos um programa em nosso computador os arquivos necessários para a execução deste vão para o `HD`, mas quando o executamos ele usa a memória `RAM` para realizar as operações que pedimos a ele. Por exemplo, se você abrir a calculadora do windows e fizer qualquer operação, ao fechar e abri-lá novamente vai ver que o resultado ou a própria operação não está mais lá.

Dadas essas informações, qual a relevancia delas para escrevermos um programa? Bom, um programa como observamos deve normalmente receber dados, e realizar operações com estes. Logo, estes dados devem ser armazenados em algum lugar. Assim, chegamos ao nosso primeiro conceito e fundamento para a programação, as `variáveis`.

> [!NOTE] 
> Antes de inciar siga o [passo a passo de como criar uma aplicação em `C#`](csharp-console.md).

### Variáveis

Variáveis são elementos do código responsáveis por armazenar valoes em memória (RAM) para que o programa possa trabalhar com eles imediatamente ou no futuro. Elas nos permitem 3 operações básicas:

- `Declaração`: Uma variável necessita ter um nome (e dependendo da linguagem um tipo) para que o programa possa a referenciar em outros trechos do código, logo a delcaração é quando criamos a variável e a damos um nome.
- `Atribuição`: Uma variável tem a função de armazenar um dado, logo podemos atribuir valores a elas. Uma variável, como o nome diz, pode mudar de valor, ou seja, podemos armazenar um valor e depois o substituir pelo mesmo processo de atribuição.
- `Leitura`: Por fim nosso programa pode ler os valores de variáveis e fazer operações com estes. Para ler uma variável basta usar o nome que foi dado a mesma no código.

Abaixo temos exemplos de declarações, atribuições e leitura de variáveis em `C#`:

```csharp
//Declaração
int a;

//Atribuição
a = 1

//Declaração com atribuição
int b = 2

//atribuição e leitura
a = b
```

Em `C#` precisamos declarar o tipo da variável. O tipo da variável informa o programa sobre qual o tipo de dado que aquela variável está armazenando, como por exemplo texto, número inteiro... Mas, por que isso importa?

Lembre que variáveis armazenam valores na memória `RAM`, e que tudo que é armazenado em um computador se converte em `bytes` (uma sequencia de 8 digitos em que cada digito pode conter somente o valor 0 ou o 1). Cada tipo de dado tem um tamanho associado a ele, ou seja, um conjunto de `bytes` e isso faz com que os programas consigam determinar que tipo de operações podem ser realizadas naqueles dados.

Em `C#` podemos ter diversos tipos de dados, porém vamos inicar com os tipos primitivos que são os mais comuns. Eles são:

- `string`: tipo texto.
- `int`: tipo para números inteiros.
- `float`: tipo para números de ponto flutuante.
- `decimal`: tipo para números decimais.
- `bool`: tipo para booleanos (Verdadeiro ou Falso).

Agora, dado como se declara variáveis é interessante sabermos como realizar mais operações com elas, como somar, dividir e outras mais.

### Operadores

Já mostramos um operador sem falar que ele era um, o operador de atribuição: `=`. Quando atribuimos valor a uma variável o utilizamos. 

#### Aritiméticos

Aproveitando nosso exemplo que é com variáveis do tipo inteiro podemos realizar operações aritiméticas como:

| Operador | Descrição |
| -------- | --------- |
| + | Adição |
| - | Subtração |
| * | Multiplicação |
| / | Divisão |
| % | Módulo (resto da divisão) |


Apesar de falarmos do nosso exemplo alguns destes operadores podem ser aplicados a `strings` e outros tipos. Exemplos de uso:


```csharp
int a = 1 + 2
int b = a - 1
int c = a * b
string d = "io"
string e = "io"
e = d + e
```

**Qual o valor das variáveis `a`, `b`, `c`, `d` e `e` ao final do programa?**
<details>
    <summary>Resposta</summary>

- `a = 3`
- `b = 2`
- `c = 6`
- `d = "io"`
- `e = "ioio"`

<details>

Para os próximos operadores acompanharemos o artigo [Tipos de Operadores do C#, DevMedia](https://www.devmedia.com.br/tipos-de-operadores-do-csharp/18873).

## Referencias

- [Linguagem de Programação, Wikipidea](https://pt.wikipedia.org/wiki/Linguagem_de_programa%C3%A7%C3%A3o)
- [How do I write an assembly language program to add two numbers?, Quora](https://www.quora.com/How-do-I-write-an-assembly-language-program-to-add-two-numbers)
- [O que é Teoria das Categorias, Otávio Paulino Pace - Medium](https://medium.com/@otaviopp8/o-que-%C3%A9-teoria-das-categorias-5e7ed0d64a94)
- [Tipos de Operadores do C#, DevMedia](https://www.devmedia.com.br/tipos-de-operadores-do-csharp/18873)

## Inidcações de Leitura
- [Category Theory for Programmers, Bartosz Milewiski](https://unglueit-files.s3.amazonaws.com/ebf/e90890f0a6ea420c9825657d6f3a851d.pdf) (Avançado)