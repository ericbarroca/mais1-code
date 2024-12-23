// - Escreva um programa como o anterior, mas agora o usuário pode digitar entre 2 a 5 números para realizar uma operação. 

//Exemplo:
//     - Usuário digita 1 da enter, 5 da enter e 8 da enter. A operação deve usar estes 3 números.
//     - Usuário digita 1 da enter, 5 da enter, 8 da enter e 6 da enter. A operação deve usar estes 4 números.

//vou trabalhar em cima desse código que o professor fez na aula

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

// while (nums<2 && nums > 5){
//     qtd = escolha("Escolha a qtd de numeros");
// }

// nums = new int[qtd];
// for(int i=0;i<qtd;i++) {
//     nums[i] = escolha("Escolha um numero");
// }

// Console.WriteLine("Escolha a operacao");
// op = Console.ReadLine()[0];
// Console.WriteLine(operacao(op,nums));