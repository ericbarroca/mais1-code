// - Escreva um programa que leia um número do usuário e exiba uma mensagem indicando se ele é positivo, negativo ou zero.

int PedeEArmazenaONumeroDigitado(int num1) {
    
    Console.WriteLine("Digite o número para saber se é positivo ou negativo: ");
    
    while (!int.TryParse(Console.ReadLine(), out num1)) {
    Console.WriteLine("Insira somente um número inteiro por favor.");
    }
    
    return num1;
}

int numero = PedeEArmazenaONumeroDigitado(0);

if (numero < 0){
    Console.WriteLine("O número " + numero + " é negativo ");
}else if (numero == 0) {
    Console.WriteLine("O número é " + numero);
} else {
    Console.WriteLine("O número " + numero + " é positivo ");
}
