int[,] matrizA = new int[2, 2] {
    { 1, 2 },
    { 3, 4 }
};

int[,] matrizB = new int[2, 2] {
    { 1, 2 },
    { 3, 4 }
};

int[,] matrizSoma = new int[2, 2];


for (int linha = 0; linha < 2; linha++)
{
    for (int coluna = 0; coluna < 2; coluna++)
    {
        matrizSoma[linha, coluna] = matrizA[linha, coluna] + matrizB[linha, coluna];
    }
}

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
ImprimirMatriz(matrizSoma);