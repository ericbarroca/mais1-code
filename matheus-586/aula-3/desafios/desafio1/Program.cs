//- Escreva uma calculadora que tenha as seguintes operações: multiplicar, dividir, somar e subtrair. Estas operações devem estar divididas em suas próprias funções. O usuário deve ter a opção de digitar os 2 números e escolhar a operação desejada.

//- Escreva um programa como o anterior, mas agora o usuário pode digitar entre 2 a 5 números para realizar uma operação. Exemplo:

    //- Usuário digita 1 da enter, 5 da enter e 8 da enter. A operação deve usar estes 3 números.

    //- Usuário digita 1 da enter, 5 da enter, 8 da enter e 6 da enter. A operação deve usar estes 4 números.



//Calculadora só com 2 numeros
int num1;
Console.WriteLine("Digite um número: ");

while (!int.TryParse(Console.ReadLine(), out num1)) {
    Console.WriteLine("Insira somente um número inteiro por favor");
}

int num2;
Console.WriteLine("Digite um número: ");

while (!int.TryParse(Console.ReadLine(), out num2)) {
    Console.WriteLine("Insira somente um número inteiro por favor");
}

int soma(int num1, int num2){
    int resultado = num1 + num2;
    return resultado;
}


int subtracao(int num1, int num2){
    int resultado = num1 - num2;
    return resultado;
}

int multiplicacao(int num1, int num2){
    int resultado = num1 * num2;
    return resultado;
}

int divisao(int num1, int num2){
    int resultado = num1 / num2;
    return resultado;
}

Console.WriteLine("Qual operação matemática você deseja fazer? (+, -, * ou /)");

string operador;
while (true){
    operador = Console.ReadLine();
    if (operador == "+" || operador == "-" || operador == "*" || operador == "/"){
        break;
    }
    Console.WriteLine("Escreva um operador válido por favor (+, -, *, /)");
}



if (operador == "+"){
    int resultado = soma(num1, num2);
    Console.WriteLine("O resultado da soma é: " + resultado);
}
else if (operador == "-")
{
    int resultado = subtracao(num1, num2);
    Console.WriteLine("O resultado da subtração é: " + resultado);
}
else if (operador == "*"){
    int resultado = multiplicacao(num1, num2);
    Console.WriteLine("O resultado da multiplicação é: " + resultado);
}

else if (operador == "/"){
    int resultado = divisao(num1, num2);
    Console.WriteLine("O resultado da divisão é: " + resultado);

}else{
    Console.WriteLine("Escolha uma das operações direcionadas (+, -, *, /)");
}