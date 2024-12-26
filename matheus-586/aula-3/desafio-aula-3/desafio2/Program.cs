// - Escreva um programa como o anterior, mas agora o usuário pode digitar entre 2 a 5 números para realizar uma operação. 

//Exemplo:
//     - Usuário digita 1 da enter, 5 da enter e 8 da enter. A operação deve usar estes 3 números.
//     - Usuário digita 1 da enter, 5 da enter, 8 da enter e 6 da enter. A operação deve usar estes 4 números.

int soma(params int[] nums)
{
    int resultado = 0;
    foreach (var num in nums) resultado += num;
    return resultado;
}

int subtracao(params int[] nums)
{
    int resultado = 0;
    foreach (var num in nums) resultado -= num;
    return resultado;
}

int multiplicacao(params int[] nums)
{
    int resultado = 1;
    foreach (var num in nums) resultado *= num;
    return resultado;
}

int divisao(params int[] nums)
{
    double resultado = nums[0];
    for (int i = 1; i < nums.Length; i++) 
    {
        if (nums[i] == 0) 
        {
            throw new DivideByZeroException("Divisão por zero não permitida.");
        }
        resultado /= nums[i];
    }
    return (int)resultado;
}


int escolha(string mensagem)
{
    while (true)
    {
        Console.Write(mensagem + ": ");
        try
        {
            return int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Número muito grande. Por favor, digite um número inteiro válido.");
        }
    }
}

int operacao(char op, params int[] nums)
{
     switch (op) 
    {
        case '+': return soma(nums);
        case '-': return subtracao(nums);
        case '*': return multiplicacao(nums);
        case '/': return divisao(nums);
        default: throw new ArgumentException("Operação inválida.");
    }
}

int qtd;
int[] nums;
char op;

qtd = escolha("Escolha a qtd de numeros");
nums = new int[qtd];
for (int i = 0; i < qtd; i++)
{
    nums[i] = escolha("Escolha um numero");
}

Console.WriteLine("Escolha a operacao");
op = Console.ReadLine()[0];
Console.WriteLine(operacao(op, nums));