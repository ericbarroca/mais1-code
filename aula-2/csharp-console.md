# Criando uma aplicação do tipo Console no C#

Para nossas aulas criaremos uma aplicação do tipo console no `C#`. Uma aplicação do tipo console é uma aplicação que usa como interface com o usuário o `CMD`. Com o `sdk`do `dotnet` instalado podemos fazer isso com o comando `dotnet new console`. Este comando ira gerar alguns arquivos e pastas, no momento o importante é encontrar o `Program.cs`, que terá um conteúdo parecido com o abaixo.

```cs
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
```

Esta versão simplidicada existe na nova versão do framework, antes este código era assim:

```csharp
using System.CommandLine;

namespace scl;

class Program
{
    static async Task<int> Main(string[] args)
    {
       Console.WriteLine("Hello, World!");
    }
}
```

Por de trás dos panos ainda ocorre a mesma coisa, é só uma simplificação visual que agora é oferecida na versão mais recente.

## Executando uma aplicação console

Para executar a sua aplicação basta executar o comando `dotnet run` de dentro da pasta em que ela foi criada.