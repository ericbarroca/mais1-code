// - Escreva um programa como o anterior, mas agora o usuário pode digitar entre 2 a 5 números para realizar uma operação. 

//Exemplo:
//     - Usuário digita 1 da enter, 5 da enter e 8 da enter. A operação deve usar estes 3 números.
//     - Usuário digita 1 da enter, 5 da enter, 8 da enter e 6 da enter. A operação deve usar estes 4 números.


// Fazendo ainda..

        Console.WriteLine("Caso você continuar esse programa, deverá escrever no mínimo 2 números e no máximo 5, você concorda? (responda com Sim ou Não)");
        string resposta = Console.ReadLine();

        if (resposta.ToLower() == "sim")
        {
            int[] numeros = new int[5];
            int contador = 0;

            while (contador < 5)
            {
                Console.WriteLine("Digite um número:");
                if (int.TryParse(Console.ReadLine(), out int numero))
                {
                    numeros[contador] = numero;
                    contador++;

                    if (contador >= 2){
                        Console.WriteLine("Deseja continuar? (Sim/Não)");
                        string respostaSeContinua = Console.ReadLine().ToLower();
                        while (respostaSeContinua != "sim" && respostaSeContinua != "não")
                        {
                            Console.WriteLine("Resposta inválida. Digite Sim ou Não.");
                            respostaSeContinua = Console.ReadLine().ToLower();
                        }
                        if (respostaSeContinua == "não"){
                            break;
                        }else{
                            Console.WriteLine("Insira somente um número inteiro por favor");
                        }
                    
            }

            Console.WriteLine("\nNúmeros inseridos:");
            foreach (int Numero in numeros)
            {
                if (numero != 0)
                {
                    Console.WriteLine(numero);
                }
            }
        }
        else
        {
            Console.WriteLine("Programa encerrado.");
        }
    }
}

// ----------------------------------------------------------------------
// int soma(int num1, int num2){
//     int resultado = num1 + num2;
//     return resultado;
// }


// int subtracao(int num1, int num2){
//     int resultado = num1 - num2;
//     return resultado;
// }

// int multiplicacao(int num1, int num2){
//     int resultado = num1 * num2;
//     return resultado;
// }

// int divisao(int num1, int num2){
//     int resultado = num1 / num2;
//     return resultado;
// }

// Console.WriteLine("Qual operação matemática você deseja fazer? (+, -, * ou /)");

// string operador;
// while (true){
//     operador = Console.ReadLine();
//     if (operador == "+" || operador == "-" || operador == "*" || operador == "/"){
//         break;
//     }
//     Console.WriteLine("Escreva um operador válido por favor (+, -, *, /)");
// }



// if (operador == "+"){
//     int resultado = soma(num1, num2);
//     Console.WriteLine("O resultado da soma é: " + resultado);
// }
// else if (operador == "-")
// {
//     int resultado = subtracao(num1, num2);
//     Console.WriteLine("O resultado da subtração é: " + resultado);
// }
// else if (operador == "*"){
//     int resultado = multiplicacao(num1, num2);
//     Console.WriteLine("O resultado da multiplicação é: " + resultado);
// }

// else if (operador == "/"){
//     int resultado = divisao(num1, num2);
//     Console.WriteLine("O resultado da divisão é: " + resultado);

// }else{
//     Console.WriteLine("Escolha uma das operações direcionadas (+, -, *, /)");
// }


//Tô pensando ainda....