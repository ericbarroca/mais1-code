// - Escreva um programa que leia a idade de uma pessoa e exiba uma mensagem indicando se ela é menor de idade (menos de 18 anos), maior de idade (18 anos ou mais), ou idosa (65 anos ou mais)

int PedeEArmazenaAIdadeDigitada(int num1) {
    
    Console.WriteLine("Digite sua idade: ");
    
    while (!int.TryParse(Console.ReadLine(), out num1)) {
    Console.WriteLine("Insira somente um número inteiro por favor.");
    }
    
    return num1;
}

int idade = PedeEArmazenaAIdadeDigitada(0);

if (idade < 18){
    Console.WriteLine("Você é menor de idade ");
} if (idade >= 18 && idade < 65) {
    Console.WriteLine("Você é maior de idade ");
} else if (idade >= 65){
    Console.WriteLine("Você é uma pessoa idosa ");
}