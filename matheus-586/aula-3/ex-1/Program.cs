//Escreva uma função que some dois números da sua escolha, os divida por 4 e retorne o resultado.
//Feito em aula

int somaDoisNumerosDividePorQuatro (int num1, int num2){
    int soma = num1 + num2;
    int divisao = soma / 4;
    return divisao;
}

int resultado = somaDoisNumerosDividePorQuatro(5,7);
Console.WriteLine(resultado);