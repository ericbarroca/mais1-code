# HTML

Vamos nos aprofundar em como criar páginas (sites) em `HTML`. Diferente de linguagens de programação o `HTML` é uma linguagem de diagramação, logo não existe definição de lógica no mesmo, apenas quais elementos usar e onde vão aparecer.

```html
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Minha Primeira Página</title>
</head>
<body>
    <h1>Bem-vindo à minha primeira página!</h1>
    <p>Este é um parágrafo de exemplo.</p>
</body>
</html>
```

No exemplo acima esta página contém um elemento de texto com formato de título e outro logo abaixo com formato de parágrafo. Os elementos definitos nesta página `HTML` são:
- `DOCTYPE`: Declaração que define a versão do HTML.
- `<html>`: Elemento raiz de um documento HTML.
- `<head>`: Contém metadados sobre o documento, como o conjunto de caracteres e o título.
- `<body>`: Contém o conteúdo visível da página.
- `<h1>`: É um elemento texto como formatação de título
- `<p>`: É um elemento que define um parágrafo de texto

Para criar uma página `HTML` basta criar um arquivo com a extensão `html` e ao clicar para abri-lo ele já abrirá em seu browser. Tente isto com o arquivo do exemplo.

## Elementos HTML

Todo elemento respeita a sintaxe abaixo:

```
<nome-elemento>conteúdo</nome-elemento>
```
### `<body>`

E só podemos usar elementos já existentes na linguagem do `HTML`. O mais importante destes elementos é o `<body>`, dentro dele adicionaremos todos os elementos que queremos mostrar em uma página.

### Cabelhaços: `<h1>` a `<h6>`

Os elementos de cabeçalho são usados para definir títulos e subtítulos, com `<h1>` sendo o mais importante e `<h6>` o menos importante.

```html
<body>
    <h1>Este é um Cabeçalho de Nível 1</h1>
    <h2>Este é um Cabeçalho de Nível 2</h2>
    <h3>Este é um Cabeçalho de Nível 3</h3>
</body>
```

### Parágrafo: `<p>`

O elemento `<p>` é usado para definir um parágrafo de texto.

```html
<body>
    <p>Este é um parágrafo de exemplo.</p>
</body>
```

### Hyperlink: `<a>`

O elemento `<a>` é usado para criar links para outras páginas ou recursos. O atributo href especifica o destino do link.

```html
<body>
    <a href="https://www.exemplo.com">Visite o Exemplo</a>
</body>
```

### Imagem: `<img>`

O elemento `<img>` é usado para incorporar imagens. O atributo src especifica o caminho da imagem, enquanto alt fornece uma descrição alternativa.

```html
<body>
    <img src="imagem.jpg" alt="Descrição da Imagem">
</body>
```

### Listas: `<ul>`, `<ol>`, `<li>`

- Listas Não Ordenadas: Criadas com `<ul>` e `<li>`.
- Listas Ordenadas: Criadas com `<ol>` e `<li>`.

```html
<body>
    <ul>
        <li>Item da Lista 1</li>
        <li>Item da Lista 2</li>
        <li>Item da Lista 3</li>
    </ul>
    <ol>
        <li>Item da Lista 1</li>
        <li>Item da Lista 2</li>
        <li>Item da Lista 3</li>
    </ol>
</body>
```

### Agrupadores: `<div>` e `span`

O `<div>` é usado para agrupar blocos de elementos.

```html
<body>
    <div>
        <h2>Seção do Conteúdo</h2>
        <p>Texto dentro da div.</p>
    </div>
</body>
```

O `<span>` é usado para estilizar partes específicas de texto na mesma linha.

```html
<body>
    <p>Este é um <span style="color: red;">texto em destaque</span>.</p>
</body>
```

### Formulários: `<form>`, `<input>` e `<button>`

Os elementos de formulário são usados para armazenar informações fornecidas pelo usuário e enviá-las posteriormente em um requisição ao servidor.
- `<form>`: Define um formulário para entrada de dados.
- `<input>`: Cria diferentes tipos de campos de entrada.
- `<button>`: Cria um botão que pode ser clicado e se tiver o `type submit` pode enviar os dados do formulário.

```html
<body>
    <form action="/submit" method="post">
        <label for="nome">Nome:</label>
        <input type="text" id="nome" name="nome">
        <button type="submit">Enviar</button>
    </form>
</body>
```

### Tabelas: `<table>`, `<tr>`, `<td>` e `<th>`

- `<table>`: Define uma tabela.
- `<tr>`: Define uma linha.
- `<td>`: Define uma célula.
- `<th>`: Define um cabeçalho de coluna.

```html
<body>
    <table>
        <tr>
            <th>Nome</th>
            <th>Idade</th>
        </tr>
        <tr>
            <td>João</td>
            <td>30</td>
        </tr>
        <tr>
            <td>Maria</td>
            <td>25</td>
        </tr>
    </table>
</body>
```