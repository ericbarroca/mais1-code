// - Escreva um programa que leia um número do usuário e exiba sua tabuada de 1 a 10
Console.WriteLine("Escreva um numero para ver sua tabuada.");
int numeroEscrito = int.Parse(Console.ReadLine());

for(int j = 2; j <= 10; j++){
    int tabuada = numeroEscrito * j;
    Console.WriteLine (tabuada);
}
