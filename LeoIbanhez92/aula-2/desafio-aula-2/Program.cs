//Escreva um programa que receba 2 números (significa que no prompt serão digitados este números e o programa os armazenará) e imprima o resultado da soma dos mesmos.

Console.WriteLine("Digite um número para somar: ");

string numero1 = Console.ReadLine();
if (int.TryParse(numero1, out int num1))
{
    Console.WriteLine($"O número digitado foi {num1}");

}
else {
    Console.WriteLine("A entrada não é um número valido!");
}

Console.WriteLine("Digite outro número para somar: ");

string numero2 = Console.ReadLine();
if (int.TryParse(numero2, out int num2)){
    Console.WriteLine($"O número digitado foi {num2}");
}
else {
    Console.WriteLine("Aentrada não é um número válido");
}

Console.WriteLine($"Você digitou: {num1} e {num2}!");

int soma = num1 + num2;

Console.WriteLine("O resultado da soma dos dois números que vc digitou foi: " + "" + soma);

//Escreva um programa que imprima se um número é par ou ímpar (Se o resto da divisão de um número por 2 for 0, ele é par).

if (soma % 2 ==0) {

    Console.WriteLine("E esse número é PAR.");

}else {
    Console.WriteLine("E esse número é ÍMPAR.");
}

