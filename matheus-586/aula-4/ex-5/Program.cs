// - Escreva um programa que leia 10 números inteiros do usuário, armazene-os em um vetor e calcule a soma desses números.

int[] numeros = new int[10];

        for (int i = 0; i < 10; i++){
            Console.Write($"Digite o número {i + 1}: ");
            while (!int.TryParse(Console.ReadLine(), out numeros[i])){
                Console.Write("Entrada inválida. Digite novamente: ");
            }
        }

        Console.WriteLine("\nNúmeros armazenados:");
        foreach (var numero in numeros){
            Console.WriteLine(numero);
        }

        int soma = numeros.Sum();
        Console.WriteLine($"\nSoma: {soma}");