//Escreva uma função que pede para o usuário digitar um número e escreve o número digitado de volta com o Numero "O seu número é <número>".
void perguntaEEscreveNumero() 
{
    string numero;
    Console.WriteLine("Digite um número: ");
    
    numero = Console.ReadLine();
    Console.WriteLine("O número digitado foi: " + numero);
}

perguntaEEscreveNumero();