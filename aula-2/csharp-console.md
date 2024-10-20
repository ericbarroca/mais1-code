# Criando uma aplicação do tipo Console no C#

Para nossas aulas criaremos uma aplicação do tipo console no `C#`. Uma aplicação do tipo console é uma aplicação que usa como interface com o usuário o `CMD`. Com o `sdk`do `dotnet` instalado podemos fazer isso com o comando `dotnet new console`. Este comando ira gerar alguns arquivos e pastas, no momento o importante é encontrar o `Program.cs`, que terá um conteúdo parecido com o abaixo.

```c#
using System.CommandLine;

namespace scl;

class Program
{
    static async Task<int> Main(string[] args)
    {
       
    }
}
```