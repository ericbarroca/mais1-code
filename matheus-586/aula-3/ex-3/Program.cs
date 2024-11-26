//- Escreva um programa (dividido em funções) que:
//    - Pede para o usuário digitar um número, o armazena em uma variável.
//    - Pede para o usuário digitar outro número, o armazena em uma variável.
//    - Soma os 2 números e imprime o resultado na tela.

int PedeEArmazenaONumeroDigitado(int num1) {
    
    Console.WriteLine("Digite o número para ser armazenado: ");
    
    while (!int.TryParse(Console.ReadLine(), out num1)) {
    Console.WriteLine("Insira somente um número inteiro por favor.");
    }
    
    return num1;
}

int numero1 = PedeEArmazenaONumeroDigitado(0);
int numero2 = PedeEArmazenaONumeroDigitado(1);

void Soma2NumerosEImprimeNatela(){
    Console.WriteLine("O Primeiro número digitado foi: " + numero1);
    Console.WriteLine("O Segundo número digitado foi: " + numero2);
    
    Console.WriteLine("A soma dos números é: " + (numero1+numero2));
}

Soma2NumerosEImprimeNatela();
