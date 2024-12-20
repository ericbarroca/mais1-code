// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// //Delaração
int nume;
string t;


// //Atribuição
nume = 12;
t = "Marco ";
Console.WriteLine(t);



int soma = 2 + nume;
Console.WriteLine(soma);

// //operadores
int numero = 2;

float resultado = numero * 6;

resultado = numero / resultado;
// forma resumida da de cima
//resultado /= numero;

Console.WriteLine(resultado);

// //----------------------------------------------
// // codigo sem função
int num = 3;
int incremento = num + 2;
Console.WriteLine(incremento);

int num2 = 5;
incremento = num2 + 2;
Console.WriteLine(incremento);

// codigo com função
void escreveNumMais2(int num){
    int incremento = num + 2;
    Console.WriteLine(incremento);
}

 escreveNumMais2(3);
 escreveNumMais2(5);


// //---------------------------------------------------
// //If e else
int idade = 16;

if (idade >= 18){
    Console.WriteLine ("Você é maior de idade");
} else{
    Console.WriteLine ("Você é menor de idade");
}

// //else if
int temperatura = 16;
if (temperatura >= 20){
    Console.WriteLine ("Clima quente");
} 
else if (temperatura > 10) 
    Console.WriteLine ("Clima agradavel");
else{
    Console.WriteLine ("Clima frio");
}

// // Lógica Bolleana
bool A = true;
bool B = false;

bool resultad = !A || B && A;
Console.WriteLine (resultado);

// //Loops
for(int j = 0; j < 5; j++){
    Console.WriteLine ("Iteração: " + j);
}

int i = 0;
while(i < 5){
    Console.WriteLine ("Iteração: " + i);
    i++;
}

// //----------------------------------------------
// //vetores
// // Declaração e Inicialização
int[] idades = new int[3] { 20, 30, 40 };

//Lendo vetores
int[] numeros = new int[3] { 10, 20, 30 };

Console.WriteLine(numeros[0]); 
Console.WriteLine(numeros[2]); 
Console.WriteLine(numeros[1]); 

//Vetores bidimensionais
//Criação dos vetores bidimensiionais
int[,] matriz = new int[2, 2] {
    { 1, 2 },
    { 3, 4 }
};

// //Laço para ler um vetores bidimensionais
// for (int linha = 0; linha < matriz.GetLength(0); linha++) {
//     for (int coluna = 0; coluna < matriz.GetLength(1); coluna++) {
//         Console.WriteLine(matriz[linha, coluna]);
//     }
// }

// matriz 2,2
// int [,] m1 = new int[2,2];
// int [,] m2 = new int[2,2];

// int [,] CriaMatriz (tamanhoD1, tamanhoD2){
//     int [,] m = new int [tamanhoD1, tamanhoD2];
//     for (int linha = 0; linha < m.GetLength(0); linha++) {
//         for (int coluna = 0; coluna < m.GetLength(1); coluna++) {
//             m[linha,coluna] = int.Parse(Console.ReadLine());
//         }
//     }

//     return m;
// }

// int [,] m1 = CriaMatriz(2,2);
// int [,] m2 = CriaMatriz(2,2);

//exercicio da calculadora aula-3/desafio-2
// int soma(params int[] nums) {
//     int resultado = 0;
//     for(int i=0;i<nums.GetLength(0);i++) {
//         resultado+=nums[i];
//     }

//     return resultado;
// }

// int sub(params int[] nums) {
//     int resultado = 0;
//     for(int i=0;i<nums.GetLength(0);i++) {
//         resultado-=nums[i];
//     }

//     return resultado;
// }

// int escolha(string mensagem) {
//     Console.WriteLine(mensagem);
//     return int.Parse(Console.ReadLine());
// }
// int operacao(char op, params int[] nums) {
//     if (op == '+') {
//         return soma(nums);
//     }

//     if (op == '-') {
//         return sub(nums);
//     }

//     return 0;
// }

// int qtd;
// int[] nums;
// char op;

// qtd = escolha("Escolha a qtd de numeros");
// nums = new int[qtd];
// for(int i=0;i<qtd;i++) {
//     nums[i] = escolha("Escolha um numero");
// }

// Console.WriteLine("Escolha a operacao");
// op = Console.ReadLine()[0];
// Console.WriteLine(operacao(op,nums));