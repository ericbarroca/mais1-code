//Escreva um programa que leia um número do usuário e exiba uma mensagem indicando se ele é positivo, negativo ou zero.


bool numeroInvalido = false;
double num;

while (!numeroInvalido)
{

    Console.WriteLine("Digite um número");
    string recebeNumero = Console.ReadLine();



    if (double.TryParse(recebeNumero, out num))
    {

        numeroInvalido = true;

        if (num > 0)
        {
            Console.WriteLine("Seu número é positivo");
        }
        else
        {
            Console.WriteLine("Seu número é negativo");
        }
    }
    else
    {
        System.Console.WriteLine("Entrada inválida!");
    }
}




// Escreva um programa que leia a idade de uma pessoa e exiba uma mensagem indicando se ela é menor de idade (menos de 18 anos)


int idade;
bool entradaInvalida = false;

while (!entradaInvalida)
{
    System.Console.WriteLine("Digite sua idade");
    string receberIdade = Console.ReadLine();

    if (int.TryParse(receberIdade, out idade))
    {
        entradaInvalida = true;
        if (idade >= 18)
        {
            System.Console.WriteLine("Você é maior de idade");
        }
        else
        {
            System.Console.WriteLine("Você é menor de idade");
        }
    }
    else
    {
        System.Console.WriteLine("Entrada inválida");
    }
}

//Escreva um programa que use um laço for para exibir os números de 1 a 10.

for(int i = 0; i <= 10; i++) {
    System.Console.WriteLine("" + i);
}


//Escreva um programa que leia um número do usuário e exiba sua tabuada de 1 a 10


int lerTabuada;
bool entradaInvalida = false;

while (!entradaInvalida)
{
    System.Console.WriteLine("Digite o número para criar a tabuada");

    if (int.TryParse(Console.ReadLine(), out lerTabuada))
    {
        entradaInvalida = true;

        System.Console.WriteLine($"Tabuada de {lerTabuada}: ");

        for (int i = 1; i <= 10; i++)
        {
            System.Console.WriteLine($"{lerTabuada} x {i} = {lerTabuada * i}");
        }
    }
    else
    {
        System.Console.WriteLine("Entrada inválida");
    }
}


// Escreva um programa que leia 10 números inteiros do usuário, armazene-os em um vetor e calcule a soma desses números.

System.Console.WriteLine("Digite 10 números para armazenar e somar! ");
int[] numero = new int[10];

for (int i = 0; i < numero.Length; i++)
{
    System.Console.WriteLine($"Digite o número {i + 1}: ");

    while (!int.TryParse(Console.ReadLine(), out numero[i]))
    {
        System.Console.WriteLine("Entrada inválida! Por favor, digite um número válido!");
    }
}

double soma = 0;

System.Console.WriteLine("Os números armazenados são: ");

foreach (double num in numero)
{

    System.Console.WriteLine(num);

    soma += num;

}

System.Console.WriteLine($"A soma dos números é: {soma}");




//Escreva um programa que leia 10 números inteiros do usuário, e determine o maior e o menor valor presente.


System.Console.WriteLine("Digite dez números");
int maior = int.MinValue;
int menor = int.MaxValue;
int[] numeros = new int[10];

for (int i = 0; i < numeros.Length; i++)
{
    System.Console.WriteLine($"Digite o número {i + 1}: ");

    while (!int.TryParse(Console.ReadLine(), out numeros[i]))
    {
        System.Console.WriteLine("Entrada iválida!");
    }

    if (numeros[i] > maior)
    {
        maior = numeros[i];

    }
    if (numeros[i] < menor)
    {
        menor = numeros[i];
    }
}
System.Console.WriteLine($"Esse foi o maior número {maior}, e esse o menor {menor}");


//Escreva um programa que leia três notas de um aluno, calcule a média e exiba uma mensagem indicando se ele foi aprovado (média ≥ 7), está em recuperação (5 ≤ média < 7) ou foi reprovado (média < 5). Usar funções.

System.Console.WriteLine("Digite as notas do aluno");
        
double[] notas = new double[3];
double soma = 0;
for (int i = 0; i < notas.Length; i++) {
    System.Console.WriteLine($"Nota {i + 1}: ");
            
    while(!double.TryParse(Console.ReadLine(), out notas[i])) {
        System.Console.WriteLine("Entrada iválida!");

    }
            
    soma += notas[i];
            
}

double media = soma / notas.Length;
        
if (media >= 7 ) {
    System.Console.WriteLine("Você foi aprovado! Essa foi a sua média: " + media.ToString("F2"));
}
else if (media > 5 && media <7) {
    System.Console.WriteLine("Você está em recuperação! Essa foi a sua média " + media.ToString("F2"));
}
else if (media < 5) {
    System.Console.WriteLine("Você está reprovado! Essa foi a sua média: " + media.ToString("F2"));
}


//Escreva um programa que crie uma matriz de identidade 3x3. Uma matriz de identidade é uma matriz quadrada em que todos os elementos da diagonal principal são 1, e todos os outros elementos são 0. Exiba a matriz resultante.


int [,] matriz = new int [3,3];

for (int i = 0; i < 3; i++){
    for (int j = 0; j < 3; j++){
        if(i == j){
            matriz[i,j] = 1;
        } else {
            matriz[i,j]=0;
        } 
    }
}

System.Console.WriteLine("Matriz 3x3");
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        System.Console.Write(matriz[i, j] + " ");
    }
    System.Console.WriteLine();
}



//Escreva um programa que leia duas matrizes 2x2 do usuário e calcule a soma das duas matrizes.


double[,] matriz = new double[2, 2];
double[,] matriz2 = new double[2, 2];
double[,] matrizSoma = new double[2, 2];

double receberNumeros;

System.Console.WriteLine("Preencha a primeira matriz");

for (int i = 0; i < 2; i++)
{
    for (int j = 0; j < 2; j++)
    {
        System.Console.WriteLine($"Digite o valor para a posição ({i + 1}, {j + 1}) da matriz!");

        while (!double.TryParse(Console.ReadLine(), out receberNumeros))
        {
            System.Console.WriteLine("Entrada iválida! Digite uma entrada válida");
        }

        matriz[i, j] = receberNumeros;
    }
}

System.Console.WriteLine("Preencha a segunda matriz");

for (int i = 0; i < 2; i++)
{
    for (int j = 0; j < 2; j++)
    {
        System.Console.WriteLine($"Digite o valor para a posição ({i + 1}, {j + 1}) da matriz 2!");

        while (!double.TryParse(Console.ReadLine(), out receberNumeros))
        {
            System.Console.WriteLine("Entrada iválida! Digite uma entrada válida");
        }

        matriz2[i, j] = receberNumeros;
    }
}

for (int i = 0; i < 2; i++)
{
    for (int j = 0; j < 2; j++)
    {
        matrizSoma[i, j] = matriz[i, j] + matriz2[i, j];

    }
}

System.Console.WriteLine("\nResultado da soma das matrizes!");
for (int i = 0; i < 2; i++)
{
    for (int j = 0; j < 2; j++)
    {
        System.Console.WriteLine(matrizSoma[i, j] + " ");
    }
    System.Console.WriteLine();
}


//Escreva um programa que ordene 10 números digitados pelo usuário e imprima-os ordenadamente em uma linha.

double[] ordenarDez = new double[10];
double receberNumero = 0;

System.Console.WriteLine("digite os numeros");

for (int i = 0; i < 10; i++)
{
    while (!double.TryParse(Console.ReadLine(), out receberNumero))
    {
        System.Console.WriteLine("Entrada iválida");
    }
    ordenarDez[i] = receberNumero;
}

Array.Sort(ordenarDez);

System.Console.WriteLine("Números digitados e ordenados");
for (int i = 0; i < 10; i++)
{
    System.Console.Write(ordenarDez[i] + " ");
}
System.Console.WriteLine();