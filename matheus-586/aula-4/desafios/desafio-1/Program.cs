// - Escreva um programa que simule um sistema de login. O usuário deve digitar um nome de usuário e senha. Se o nome de usuário for "admin" e a senha for "1234", exiba uma mensagem de "Login bem-sucedido", caso contrário, peça para ele tentar novamente. O sistema deve permitir apenas três tentativas.

int tentativas = 0;
const string usuarioValido = "admin";
const string senhaValida = "1234";
bool loginEfetuado = false;

while (tentativas < 3 && !loginEfetuado)
{
    Console.Write("Digite o nome de usuário: ");
    string usuario = Console.ReadLine();

    Console.Write("Digite a senha: ");
    string senha = Console.ReadLine();

    if (usuario == usuarioValido && senha == senhaValida)
    {
        Console.WriteLine("Login bem-sucedido!");
        loginEfetuado = true;
    }
    else
    {
        tentativas++;
        Console.WriteLine($"Tentativa {tentativas}/3. Usuário ou senha inválidos. Tente novamente.");
    }
}

if (!loginEfetuado)
{
    Console.WriteLine("Número máximo de tentativas alcançado.");
}

Console.ReadKey();

