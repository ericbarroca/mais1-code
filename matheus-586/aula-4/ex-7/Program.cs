// - Escreva um programa que leia três notas de um aluno, calcule a média e exiba uma mensagem indicando se ele foi aprovado (média ≥ 7), está em recuperação (5 ≤ média < 7) ou foi reprovado (média < 5). Usar funções.
Console.WriteLine("escreva a primeira nota do aluno: ");
double nota1 = double.Parse(Console.ReadLine());

Console.WriteLine("escreva a segunda nota do aluno: ");
double nota2 = double.Parse(Console.ReadLine());

Console.WriteLine("escreva a terceira nota do aluno: ");
double nota3 = double.Parse(Console.ReadLine());

double somatorio = nota1 + nota2 + nota3;
double media = somatorio/3;

Console.WriteLine("Sua média é: " + media);