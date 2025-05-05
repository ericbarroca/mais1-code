// - Escreva um programa que ordene 10 números digitados pelo usuário e imprima-os ordenadamente em uma linha.

// Declarar vetor
int[] numeros = new int[10];

// Ler números
for (int i = 0; i < 10; i++)
{
    Console.Write($"Digite o número {i + 1}: ");
    numeros[i] = int.Parse(Console.ReadLine());
}

// Ordenar números
Array.Sort(numeros);

// Imprimir números ordenados
Console.WriteLine("Números ordenados:");
Console.WriteLine(string.Join($" ", numeros));