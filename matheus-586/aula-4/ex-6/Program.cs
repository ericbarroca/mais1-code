// - Escreva um programa que leia 10 números inteiros do usuário, e determine o maior e o menor valor presente.

int[] numeros = new int[10];

        for (int i = 0; i < 10; i++)
        {
            Console.Write($"Digite o número {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out numeros[i]))
            {
                Console.Write("Entrada inválida. Digite novamente: ");
            }
        }

        Console.WriteLine("\nNúmeros armazenados:");
        foreach (var numero in numeros)
        {
            Console.WriteLine(numero);
        }

        int maior = numeros.Max();
        int menor = numeros.Min();

        Console.WriteLine($"\nMaior valor: {maior}");
        Console.WriteLine($"Menor valor: {menor}");
