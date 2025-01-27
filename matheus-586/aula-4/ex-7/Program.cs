// - Escreva um programa que leia três notas de um aluno, calcule a média e exiba uma mensagem indicando se ele foi aprovado (média ≥ 7), está em recuperação (5 ≤ média < 7) ou foi reprovado (média < 5). Usar funções.
int notaDoAluno()
{
    Console.WriteLine("escreva a nota do aluno: ");
    return int.Parse(Console.ReadLine());
}

int nota1 = notaDoAluno();
int nota2 = notaDoAluno();
int nota3 = notaDoAluno();

int somatorio = nota1 + nota2 + nota3;
int media = somatorio / 3;

if (media >= 7){
    Console.WriteLine("Você foi aprovado ");
} if (media <= 6 && media >= 5){
    Console.WriteLine("Você está de recuperação ");
}if (media < 5){
    Console.WriteLine("Você está reprovado ");
}

Console.WriteLine("Sua média é: " + media);