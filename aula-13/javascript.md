# Javascript

`JavaScript` é uma linguagem de programação essencial para o desenvolvimento web. Ele permite criar páginas interativas e dinâmicas. Uma das funcionalidades do `JavaScript` é a capacidade de fazer chamadas a `APIs`, que permitem a comunicação entre o `front-end` (cliente) e o `backend` (servidor) para obter ou enviar dados. Nesta aula, vamos explorar como usar `JavaScript` em páginas `HTML` para realizar chamadas a `APIs REST`.

## Conceitos Básicos

`JavaScript` é uma linguagem de programação de script que pode ser usada para criar funcionalidades dinâmicas em páginas web. Ele pode ser incluído diretamente em um documento HTML ou em um arquivo separado. No exemplo abaixo usamos javascript para apresentar um popup na página `HTML`.

```html
<body>
    <script>
        // Exemplo de um alerta em JavaScript
        alert("Olá, mundo!");
    </script>
</body>
```

Os conceitos que vimos em `C#` de declaração de variáveis e funções se aplicam a `Javascript`, porém em os tipos de dados são atribuidos dinamicamente, ou seja não os espeficamos ao definir variáveis.

```html
<body>
    <script>
        var nome = "João"; // String
        let idade = 30; // Número
        const casado = true; // Booleano

        console.log(nome, idade, casado);
    </script>
</body>
```

No caso de funções isso implica em não precisar definir o tipo do retorno ou dos argumentos de uma.

```html
<body>
    <script>
        function saudacao(nome) {
            return "Olá, " + nome + "!";
        }

        console.log(saudacao("João"));
    </script>
</body>
```

O javascript nos permite inclusive manipular o `DOM`, que é a árvore de elementos `HTML`. Abaixo ao clicar no botão chamaremos a função `Javascript` que mudará o texto do elemento com `id=titulo`.

```html
<body>
    <h1 id="titulo">Título Original</h1>
    <button onclick="mudarTitulo()">Mudar Título</button>

    <script>
        function mudarTitulo() {
            document.getElementById("titulo").textContent = "Título Alterado";
        }
    </script>
</body>
```

## Realizando Chamadas a APIs REST com JavaScript

Para podermos chamar um endpoint de uma API precisamos saber o endereço dele e o verbo `HTTP`, com isso podemos usar a função `fetch` para pegar o `response` do servidor e assim obter a sua resposta. No exemplo abaixo faremos um `GET` para um endpoint do projeto `Api` desta aula. Lembrando que a porta 5115 pode mudar ao rodar na sua máquina, então sempre atualize o código abaixo.

```html
<body>
    <h1>Dados da API</h1>
    <div id="dados"></div>

    <script>
        // URL da API
        const url = "http://localhost:5115/dados";

        // Função para realizar uma requisição GET
        async function obterDados() {
            try {
                const response = await fetch(url);
                const dados = await response.json();
                document.getElementById("dados").textContent = JSON.stringify(dados, null, 2);
            } catch (error) {
                console.error("Erro ao obter dados:", error);
            }
        }

        // Chama a função ao carregar a página
        window.onload = obterDados;
    </script>
</body>
```

Para realizar um `POST`temos um código similar. Porém passamos uma intancia de um objeto para o `fetch`como argumento, preenchendo o verbo `HTTP`, os headers e o body com o objeto que queremos enviar na requisição.

```html
<body>
    <h1>Enviar Dados para a API</h1>
    <button onclick="enviarDados()">Enviar Dados</button>

    <script>
        // URL da API
        const url = "http://localhost:5115/dados";

        // Função para realizar uma requisição POST
        async function enviarDados() {
            const dados = {
                nome: "João"
            };

            try {
                const response = await fetch(url, {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify(dados)
                });

                const resultado = await response.json();
                console.log("Dados enviados:", resultado);
            } catch (error) {
                console.error("Erro ao enviar dados:", error);
            }
        }
    </script>
</body>
```
Em resumo:

- `fetch()`: A função `fetch()` é usada para fazer requisições `HTTP`. Ela retorna uma `Promise` que resolve para a resposta da requisição.
- `async` e `await`: Usados para escrever código assíncrono de forma mais legível.
- `try` e `catch`: Usados para tratar erros que possam ocorrer durante a execução da requisição.
- `headers`: Cabeçalhos `HTTP` que especificam o tipo de conteúdo.
- `body`: O corpo da requisição, geralmente usado em requisições `POST` e `PUT`.

## Separando Javascript do HTML

Por melhor organização e boas práticas o `Javascript` é separado do `HTML` em um arquivo ou múltplos arquivos próprios. Isso pode ser feito da seguinte forma:

- Crie um novo arquivo chamado `script.js`.

```js
// script.js

// Função para realizar uma requisição GET
async function obterDados() {
    const url = "http://localhost:5115/dados";
    try {
        const response = await fetch(url);
        const dados = await response.json();
        document.getElementById("dados").textContent = JSON.stringify(dados, null, 2);
    } catch (error) {
        console.error("Erro ao obter dados:", error);
    }
}

// Função para realizar uma requisição POST
async function enviarDados() {
    const url = "http://localhost:5115/dados";
    const dados = {
        nome: "João",
        idade: 30
    };

    try {
        const response = await fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(dados)
        });

        const resultado = await response.json();
        console.log("Dados enviados:", resultado);
    } catch (error) {
        console.error("Erro ao enviar dados:", error);
    }
}

// Chama a função ao carregar a página
window.onload = obterDados;
```
- Crie uma arquivo chamado `main.html`
- Neste arquivo, utilize a tag `<script>` dentro do `<body>` para vincular o arquivo JavaScript externo.

```html
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Exemplo JavaScript Externo</title>
</head>
<body>
    <h1>Dados da API</h1>
    <div id="dados"></div>

    <h1>Enviar Dados para a API</h1>
    <button onclick="enviarDados()">Enviar Dados</button>

    <script src="script.js"></script>
</body>
</html>
```