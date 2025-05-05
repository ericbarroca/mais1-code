// - Escreva um programa que leia duas matrizes 2x2 do usuário e calcule a soma das duas matrizes.
int[,] matrizA = new int[2, 2];
int[,] matrizB = new int[2, 2];
int[,] matrizSoma = new int[2, 2];

int[,] leituraDaMatriz(int[,] matriz)
{
    for (int linha = 0; linha < matriz.GetLength(0); linha++)
    {
        for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
        {
            Console.Write($"Digite o elemento [{linha + 1},{coluna + 1}]: ");
            matriz[linha, coluna] = Convert.ToInt32(Console.ReadLine());
        }
    }

    return matriz;
}
// Leitura da Matriz A
Console.WriteLine("Matriz A:");
matrizA = leituraDaMatriz(matrizA);

// Leitura da Matriz B
Console.WriteLine("Matriz B:");
matrizB = leituraDaMatriz(matrizB);

// Cálculo da Soma
for (int linha = 0; linha < 2; linha++)
{
    for (int coluna = 0; coluna < 2; coluna++)
    {
        matrizSoma[linha, coluna] = matrizA[linha, coluna] + matrizB[linha, coluna];
    }
}

// Impressão das Matrizes
static void ImprimirMatriz(int[,] matriz)
{
    for (int linha = 0; linha < matriz.GetLength(0); linha++)
    {
        for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
        {
            Console.Write($"{matriz[linha, coluna]} ");
        }
        Console.WriteLine();
    }
}

Console.WriteLine("\nMatriz A:");
ImprimirMatriz(matrizA);

Console.WriteLine("\nMatriz B:");
ImprimirMatriz(matrizB);

Console.WriteLine("\nMatriz Soma:");
ImprimirMatriz(matrizSoma);
