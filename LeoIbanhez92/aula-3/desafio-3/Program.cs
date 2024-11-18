class Calculadora 
{
    static int Somar (int num, int num2) {
        return num + num2;
    }
    static int Multiplicar (int num, int num2) {
        return num * num2;
    }

    static double Dividir (int num, int num2) {
        if (num2 == 0) {
            System.Console.WriteLine("Não é possível dividir por zera!");
            return 0;
        }
        return(double) num / num2;
    }

    static int Subtrair (int num, int num2) {
        return num - num2;
    }


    static (int, int) ObterNumeros()
    {
        int num, num2;

        while (true) 
        {
            Console.WriteLine("Digite o primeiro número: ");
            string primeiroNum = Console.ReadLine();

            if(int.TryParse(primeiroNum, out num)) {
                if(num <0) {
                    Console.WriteLine("O número não pode ser negativo. Digite um número válido!");
                }else {
                    break;
                }
            }
            else {
                Console.WriteLine("Entrada inválida! Digite um número válido!");
            }
        }

        while (true) 
        {
            Console.WriteLine("Digite o segundo número:");
            string segundoNum = Console.ReadLine();

            if (int.TryParse(segundoNum, out num2))
            {
                if(num2 < 0) {
                    Console.WriteLine("O número não pode ser negativo! Digite um número válido!");
                }
                
                else {
                    break ;
                }
            }
            else {
                Console.WriteLine("Entrada inválida! Digite um número válido!");
            }
        }

        return(num , num2);
    }

    static string EscolherOperacao()
    {
        string operacao;

        while (true)
        {
            Console.WriteLine("Escolha a operação: ");
            Console.WriteLine("1. Soma");
            Console.WriteLine("2. Subtração");
            Console.WriteLine("3. Multiplicação");
            Console.WriteLine("4. Divisão");

            operacao = Console.ReadLine();

            if (operacao == "1" || operacao == "2" || operacao == "3" || operacao == "4") {
                break;
            }
            else  {
                Console.WriteLine("Operação inválida! Digite uma operação válida!");
            }
        }
        return (operacao);
    }

    static void RealizarOperacao()
    {
        var (num, num2) = ObterNumeros();
        string operacao = EscolherOperacao();


        switch (operacao)
        {
            case "1":
                Console.WriteLine($"Resultado da soma: {Somar(num, num2)}");
                break;
            case "2":
                Console.WriteLine($"Resultado da subtração: {Subtrair(num, num2)}");
                break;
            case "3":
                Console.WriteLine($"Resultado da multiplicação: {Multiplicar(num, num2)}");
                break;
            case "4":
                Console.WriteLine($"Resultado da divisão: {Dividir(num, num2)}");
                break;
            default:
                Console.WriteLine("Operação inválida.");
                break;
        }
    }
    public static void Main()
    {
        RealizarOperacao();
    }
}