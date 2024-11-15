//Escreva um programa que receba 2 números (significa que no prompt serão digitados este números e o programa os armazenará) e imprima o resultado da soma dos mesmos.

int num1;
Console.WriteLine("Digite o primeiro número para ser somado: ");
num1 = int.Parse(Console.ReadLine());

int num2;
Console.WriteLine("Digite o segundo número para ser somado: ");
num2 = int.Parse(Console.ReadLine());

int total = num1 + num2;
Console.WriteLine("A soma dos dois numeros é: " + total + "\n\n");

//Escreva um programa que imprima se um número é par ou ímpar (Se o resto da divisão de um número por 2 for 0, ele é par).

int n;
Console.WriteLine("Digite um número: ");
n = int.Parse(Console.ReadLine());

if (n % 2 == 0) {
    Console.WriteLine("O número escolhido é par");
} else {
    Console.WriteLine("O número escolhido é impar");
}
