# Funções/Métodos e Pacotes/Bibliotecas

## Funções/Métodos

Agora que criamos a nossa primeira aplicação console e entendemos variáveis podemos avançar para o segunto concetio mais importante que devemos aprender: `Funcões`. Esta ferramenta de código nos permite realizar certos tipos de funcionalidades no código, assim como as variáveis.

Até o momento nós escrevemos código em um arquivo e como se ele fosse um paragráfro ou documento de texto:

```csharp

int num1 = 2
int num2 = 4

int res = num1 + num2
```

Porém, imagine que eu estamos escrevendo um código que gostaríamos de reutilizá-lo em outras partes do nosso código. No modelo atual teriamos que rescrever este trecho toda vez que quisermos o usar, o que gera bastante repetição e é pouco produtivo. Para resolver esta questão nós temos as `Funções`. Funções nos permitem escrever o código uma vez e o reutilizar em qualquer lugar apenas referenciando o nome da função e passando seus argumentos.

Inclusive na aula 2 nós já estavamos utilizando funções, vocês sabem qual?

<details>
<summary><b>Resposta</b></summary>

A função `WriteLine`.

</details>

Funções são ferramentas poderosas, são derivadas do conceito matemático de função:

*"Uma função é uma relação de um conjunto **A** com um conjunto **B**. Denotamos uma função por 
`f:A→B, y = f(x)`, onde **f** é o nome da função, **A** é chamado de domínio, **B** é chamado de contradomínio e 
`y = f(x)` expressa a lei de formação (relação) dos elementos, `x ∈ A` com os elementos 
`y ∈ B`." [Função (matemática), Wikipidea](https://pt.wikipedia.org/wiki/Fun%C3%A7%C3%A3o_(matem%C3%A1tica))*

Logo, isso implica que uma função retorna um valor e pode ou não receber argumentos. 

<details>
<summary><b>Vamos considerar um função que soma 2 números.
Quais são os argumentos? Qual o Valor retornado?</b></summary>

A função descrita tem a forma matemática `f(x,y) = x + y`. Onde **x** é o priemiro argumento que devemos passar para a função, o primeiro número a ser somado e
**y** é o segundo argumento, o segundo número a ser somado. Já, *f* é o resultado desta função, a somatória dos 2 números.
</details>

<details>
<summary><b>Vamos considerar um função que desenha uma reta horizontal com valor 2.
Quais são os argumentos? Qual o Valor retornado?</b></summary>

A função descrita tem a forma matemática `f(?) = 2`. Onde não existem argumentos, ou eles não importam. Já, *f* o resultado desta função, é sempre 2.
</details>

### Como criar funções em C#

Assim como todas as funcionalidades em uma linguagem, existe uma sintexe adequada que deve ser respeitada para que o programa entenda que queremos criar uma função. Em `C#` a syntaxe completa é:

`<modificador> <tipo do retorno> <nome da função> (<lista de argumentos>) { <código da função> }` onde a lista de argumentos nada mais é que uma lista de variáveis que você deseja criar para esta funcção (`<tipo> <nome da variavel>`) separadas por `,`. No momento podemos omitir o modificador, vamos falar sobre isso em outro momento. Exemplos:

```csharp

int SomaDoisNumeros(int num1, int num2) {
    return num1 + num2;

}

string AdicionaFimAUmaString(string valor) {
    return valor + "Fim";
    
}

void EscreveAbacaxi() {
    Console.WriteLine("Abacaxi");
}

```

É importante notar 2 coisas, eu posso escrever quantas linhas eu desejar dentro de uma função, porém é uma boa prática que elas não tenham um código que realize mais de uma funcionalidade como por exemplo somar 2 números e escrever abacaxi. Para isso seria interessante escrever 3 funções, uma que soma 2 números, uma que escreve abacaxi e uma terceira que chama as 2 anteriores. O segundo ponto é o tipo de retorno chamado de `void`.

Usamos `void` quando temos uma função que realiza uma operação que não nos interessa o retorno, como por exemplo escrever no prompt um texto.


### Como usar funções em C#

Para chamar uma função em qualquer parte do seu código você deve seguir a seguinte sintaxe: `<nome da função>(<lista de valores/variáveis aceitos pela função>)`. Exemplos:

```csharp

int resultado = SomaDoisNumeros(2,4)

string texto = "olá"
AdicionaFimAUmaString(texto)

EscreveAbacaxi()

```

<details>
<summary><b>Ao final do programa, qual o valor de resultado? O valor de texto? </b></summary>

- `resultado` é igual a `6`.
- `texto` é igual a `"olá"`.
</details>

Repare que uma função mesmo tendo sida criada com retorno de valor (`AdicionaFimAUmaString`), não impede de ser chamada sem armazenar o valor dela em nenhuma variável.

## Pacotes/Bibliotecas

### Funções importantes já existentes no framework

## Referências

- [Funções Locais, Microsoft](https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/local-functions)
- [Função (matemática), Wikipidea](https://pt.wikipedia.org/wiki/Fun%C3%A7%C3%A3o_(matem%C3%A1tica))