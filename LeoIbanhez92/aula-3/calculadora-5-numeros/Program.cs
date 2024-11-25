//Escreva um programa como o anterior, mas agora o usuário pode digitar entre 2 a 5 números para realizar uma operação. Exemplo:

class Calculadora2 
{
    static void Main () {
        int[] receber5Numeros = new int[5];

        int contador = 0;

        while (contador < 5) {
            Console.WriteLine("Digite um número(ou digite 'parar' para encerrar):");
            string armazenar = Console.ReadLine();

            if (armazenar.ToLower() == "parar") {
                break;
            }

            if(int.TryParse(armazenar, out int numero)) {
                receber5Numeros[contador] = numero;
                contador++;
            }
            else {
                Console.WriteLine("Digite um número válido!");
            }
        }

        if (contador < 2) {        

            Console.WriteLine("Você precisa inserir pelo menos 2 números");
            return;
        }

        string operacaoEscolhida = "";
        bool operacaoValida = false;

        while(!operacaoValida) 
        {

            Console.WriteLine("\nEscolha uma operação");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("Digite o número da operação desejada");

            operacaoEscolhida = Console.ReadLine();
            

            System.Console.WriteLine("Você escolher a operação de número: " + operacaoEscolhida);

            switch (operacaoEscolhida) {
                case "1":
                    int soma = 0;
                    for (int i = 0; i < contador; i++) {
                        soma += receber5Numeros[i];
                    }
                    System.Console.WriteLine("A soma dos número inseridos é: " + soma);
                    operacaoValida = true;
                    break;
                
                case "2":
                    int subtrair = receber5Numeros[0];
                    for (int i = 1; i < contador; i++ ){
                        subtrair -= receber5Numeros[i];
                    }
                    System.Console.WriteLine("A subtração dos números inseridos é: " + subtrair);
                    operacaoValida = true;
                    break;

                case"3":
                    int multiplicar = 1;
                    for (int i = 0; i < contador; i++) {
                        multiplicar *= receber5Numeros[i];
                    }
                    System.Console.WriteLine("A multiplicação dos números inseridos é: " + multiplicar);
                    operacaoValida = true;
                    break;

                case"4":
                    double dividir = receber5Numeros[0];
                    if (dividir == 0) {
                        System.Console.WriteLine("Erro: não é possível dividir por zero!");
                        operacaoValida = false;
                        break;
                    }

                    for (int i = 1; i < contador; i++) {
                        if(receber5Numeros[i] == 0){
                            System.Console.WriteLine("Erro: Não é possível dividir por zero!");
                            return;
                        }
                        dividir /= receber5Numeros[i];
                    }
                    if (dividir < 0.0001 || dividir > 10000) {
                        System.Console.WriteLine("O resultado da divisão é: " + dividir.ToString("F6"));
                    }
                    else 
                    {
                        System.Console.WriteLine("O resultado da divisão é: " + dividir);

                    }
                    operacaoValida = true;
                    break;

                default:
                    Console.WriteLine("Opção inválida! Por favor, escolha uma operação válida.");
                    operacaoValida = false;
                    break;
            }
        }
        
    }
}

