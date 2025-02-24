# API - ASPNET e MVC

Apesar de na aula anterior ter apresentado o conceito de `MVC`, nós não criaremos projetos mvc. Isso pois a criação de `APIs` não precisa necessariamente de todas as bibliotecas e código presente no padrão `MVC` do `aspnet`. Porém, nós seguiremos o padrão do `MVC` como arquitetura para separar as responsabilidades de nossas `APIS`.

Para isso no seu terminal digite:

```bash
dotnet new web -o TodoApi
cd TodoApi
code .
```

Uma vez dentro da pasta da aplicação que acabamos de criar, podemos navegar até o arquivo principal, o `Program.cs`. Nele teremos o código abaixo:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
```

A primeira e segunda linhas, instruem o framework a criar uma aplicação web para nós. Porém a terceira linha é aonde começamos a definir os `endpoints` de nossa `API` e dar forma a ela através da nossa variável `app`. Neste caso estamos criando um `endpoint` padrão (`/`) que retorna uma `string` e é acessado pelo verbo `HTTP` `GET` (`MapGet` é a função que deine isso).

Por último o `app.Run()` sobe a nossa aplicação servidor em uma porta disponível em nossa máquina, e quando dermos `dotnet run` ele nos informará o endereço da `API` que podemos digitar na barra de endereço do navegador.

Agora vamos criar uma api que dornece uma lista de livros e dado o nome de um livro retorna mais informações sobre este. Para isso vamos criar nossas `models`:

- `Livro`: Data Model, representando um recurso Livro com nome, autor e editora.
- `Biblioteca`: Repository ou Service, é uma classe que serve para manipular os dados do modelo, como por exemplo buscar um livro pelo nome ou listar todos os livros.

```csharp
public class Livro {

    public Livro(string nome, string autor, string editora) {
        Nome = nome;
        Autor = autor;
        Editora = editora;
    }

    public string Nome {get; set;}

    public string Autor {get; set;}

    public string Editora {get; set;}
}

public class Biblioteca {

    private List<Livro> livros;

    public Biblioteca() {
        livros = new List<Livro>() {
            new Livro("A jornada para o oeste", "Anthony C. Yu", "The University of Chicago Press"),
            new Livro("Competição Analítica", "Thomas H. Davenport", "Alta Books"),
            new Livro("Todos os nossos ontens", "Natalia Ginzburg", "Companhia das Letras")
        };
    }

    public List<Livro> ListarLivros() {
        return livros;
    }

    public Livro BuscarLivro(string nome) {

        return livros.SingleOrDefault(l=>l.Nome==nome);
    }
}
```

Reparem que na classe `Biblioteca` iniciamos a lista de livros em seu construtor de forma `hardcoded`, em um sistema real essa lista seria populada através de buscas em um banco de dados.

Após a criação das `Models` podemos voltar para os `endpoints` e o nosso `server`. Nele criaremos 2 `endpoints`:

- `GET` `/livros`: Lista todos os livros.
- `GET` `/livros/{nome}`: Busca um livro pelo nome, se não encontrar retorna `404` que é o status `HTTP` para `NotFound`.

O código da nossa `API` está disponível abaixo.

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<Biblioteca>();

var app = builder.Build();

app.MapGet("/livros", (Biblioteca biblioteca) => biblioteca.ListarLivros());

app.MapGet("/livros/{nome}", (Biblioteca biblioteca, string nome) =>
{
    var livro = biblioteca.BuscarLivro(nome);

    if (livro is null) {
        return Results.NotFound();
    }

    return Results.Ok(livro);
});

app.Run();

```

Aqui temos algumas coisas novas que neecessitam explicação e contextualização. Na linha 2 agora temos este código:
`builder.Services.AddSingleton<Biblioteca>();`. Ele faz injeção de depência em nossa `API` para que possamos usar uma instância da classe `Biblioteca` em qualquer `endpoint`, porém o que é `Injeção de Dependência`?

`Injeção de Dependência` é um padrão de design que ajuda a aumentar a flexibilidade e a testabilidade de um aplicativo. Onde a dependência é qualquer objeto que uma classe precisa para funcionar corretamente e a injeção é a prática de fornecer essas dependências para uma classe, em vez de a própria classe criar ou gerenciar essas dependências. Ou seja, em nosso código ao invés do objeto do tipo `WebApplication` armazenado na variável `app` criar uma instância da nossa classe `Biblioteca` para poder usar em seus `endpoints`, nós pedimos para o `builder` criar uma instância e fornecer a classe `app`.

Voltando ao código, depois temos o trecho que adiciona os 2 `endpoints`, reparem que o primeiro é bem simples. Usamos a `lambda` para criar uma função anônima que recebe um objeto do tipo do nossa model `Biblioteca`
e chama a função de listar os livros. O segundo, é o `endpoint` de busca de livro, onde a função anônima recebe 2 parametros, a classe `Biblioteca` e o nome do livro a ser buscado. É importante reparar que a variável nome contrém o mesmo nome que está entre chames no nome do `endpoint` (`{nome}`), isso faz com que este campo no caminho da `URL` seja passado para a nossa `API`.

Por fim este endpoint retorna a execução das funções da classe `Results`, isso serve para que possamos trabalhar com os status de retorno corretos do `HTTP`, `NotFound` para quando não foi encontrado e `OK` (`202`) para quando encontra o livro e devolve as informações do `Livro` como `JSON`.

Para chamar os endpoints no browser digite na barra de endereço:

```bash
http://localhost:5113/livros
http://localhost:5113/livros/A%20jornada%20para%20o%20oeste
```
Agora vamos criar os endpoints para adicionarmos novos livros e atualizarmos livros. No arquivo `Program.cs` adicionaremos o conteúdo abaixo antes da linha `app.Run();`:

```csharp
app.MapPost("/livros", (Biblioteca biblioteca, Livro livro) =>
{
    var livroExistente = biblioteca.BuscarLivro(livro.Nome);

    if (!(livroExistente is null)) {
        return Results.BadRequest("Livro ja existe");
    }

    biblioteca.Upsert(livro);

    return Results.Created();
});

app.MapPut("/livros", (Biblioteca biblioteca, Livro livro) =>
{
    var livroExistente = biblioteca.BuscarLivro(livro.Nome);

    if (livroExistente is null) {
        return Results.BadRequest("Livro não existe");
    }

    biblioteca.Upsert(livro);

    return Results.Accepted();
});
```
E na classe `Biblioteca` adicionaremos a função de `Upsert`:

```csharp
public void Upsert(Livro livro) {

    var livroExistente = BuscarLivro(livro.Nome);

    if (livroExistente is null) {
        livros.Add(livro);
        return;
    }

    livroExistente.Autor = livro.Autor;
    livroExistente.Editora = livro.Editora;
    livroExistente.Nome = livro.Nome;

    }
```

Estes códigos realizam a operação de adicionar ou atualizar um livro a nossa biblioteca. Na nossa API temos 2 endpoints distintos, 1 para adicionar (`POST`) e 1 para atualizar (`PUT`). Porém, ambos chamam o mesmo código na biblioteca, a função de Upssert.

Fazemos isso pois podemos dar tratamentos diferentes a criação e a atualização na camada da API, como por exemplo o erro a ser retornado.

Para testarmos estes novos `endpoints` precisamos conseguir fazer `PUTs` ou `POSTs`, o que não é possível diretamente pela barra de endereço do navegador, que só realiza `GETs`. Para isso vamos usar uma linha de comando em nosso terminal, mas especificamente o `curl`.

O `curl` nos permite fazer todos os tipos de requests HTTP, abaixo segue um exemplo de `POST` e outro de `PUT`.

```bash
curl -d "{\"Autor\":\"Eric\", \"Nome\":\"Livro\", \"Editora\": \"A\"}" -H "Content-Type: application/json" -X POST http://localhost:5054/livros 
```

```bash
curl -d "{\"Autor\":\"Eric\", \"Nome\":\"Livro\", \"Editora\": \"B\"}" -H "Content-Type: application/json" -X PUT http://localhost:5054/livros 
```

Nestes comandos reparem que o `-d` é o parametro que premite passarmos o `JSON` que representa o nosso objeto a ser recebido pelo endpoint, no caso o objeto da classe `Livro`. O `JSON` nada mais é que a representação em texto do conteúdo de um objeto, respeitando as propriedades definidas na classe e especificando valores para cada uma. Neste caso um `Livro` tem as propriedades `Nome`, `Autor` e `Editora`, então o `JSON` vai especificar e dar valor a cada uma delas. Além disso, em JSON as `{}` representam um objeto.

Depois disso precisamos especificar no `curl` que a requisição vai passar um objeto `JSON`, fazemos isso pelo argumento `-H` especificando o `Content-Type`. Finalmente usamos o `-X POST` para especificar o verbo HTTP a ser usado seguido do caminho do nosso `endpoint`.

## Desafio - Implementação DELETE

<details>
<summary><b>Implementem um endpoint em que seja possível deletar um Livro da biblioteca, esse endpoint deve somente receber o nome do Livro</b></summary>

Na classe `Program.cs` adicione o endpoint de delete.

```csharp
app.MapDelete("livros/{nome}", (Biblioteca biblioteca, string nome) => {
    var livroExistente = biblioteca.BuscarLivro(nome);

    if (!biblioteca.Delete(nome)) {
        return Results.BadRequest("Livro não existe");
    }

    return Results.Ok();
});
```

Na classe da `Biblioteca` adicione a função de `Delete`:

```csharp
public bool Delete(string nome) {
    var livroExistente = BuscarLivro(nome);

    if (livroExistente is null) {
        return false;
    }

    return livros.Remove(livroExistente);
}
```

Para testar o `DELETE` podemos usar o comando `curl` abaixo:

```bash
curl -X DELETE http://localhost:5054/livros/Livro
```
</details>
## Referências

- [Tutorial: Criar uma API mínima com o ASP.NET Core, Microsoft](https://learn.microsoft.com/pt-br/aspnet/core/tutorials/min-web-api?view=aspnetcore-9.0&tabs=visual-studio)
- [Introdução ao ASP.NET Core MVC, Microsoft](https://learn.microsoft.com/pt-br/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-9.0&WT.mc_id=dotnet-35129-website&tabs=visual-studio)
- [Visão geral do ASP.NET Core MVC, Microsoft](https://learn.microsoft.com/pt-br/aspnet/core/mvc/overview?view=aspnetcore-9.0&WT.mc_id=dotnet-35129-website)