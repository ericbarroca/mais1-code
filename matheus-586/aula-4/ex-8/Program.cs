// - Escreva um programa que crie uma matriz de identidade 3x3. Uma matriz de identidade é uma matriz quadrada em que todos os elementos da diagonal principal são 1, e todos os outros elementos são 0. Exiba a matriz resultante.

// Declarar matriz 
int[,] matrizIdentidade = new int[3, 3];

for (int linha = 0; linha < matrizIdentidade.GetLength(0); linha++)
{
    for (int coluna = 0; coluna < matrizIdentidade.GetLength(1); coluna++)
    {
        if (linha == coluna)
        {
            matrizIdentidade[linha, coluna] = 1;
        }
    }
}


// Imprimir matriz
void imprimirMatriz(int[,] matriz)
{
    for (int linha = 0; linha < matrizIdentidade.GetLength(0); linha++)
    {
        for (int coluna = 0; coluna < matrizIdentidade.GetLength(1); coluna++)
        {
            Console.Write($"{matrizIdentidade[linha, coluna]} ");
        }
        Console.WriteLine();
    }
}

Console.WriteLine("Matriz de Identidade 3x3:");
imprimirMatriz(matrizIdentidade);