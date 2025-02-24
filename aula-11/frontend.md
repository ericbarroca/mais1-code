# Frontend

Até o momento focamos no desenvolvimento `backend`. Aprendemos sobre `C#` e suas estruturas, sobre programação orientada a objetos e conceitos de engenharia de software como modelagem da camada de acesso a dados, models e `APIs`.

Então chegou o momento de termos algo mais elaborado para que nossos usuários possam iteragir com nosso sistema através do seu navegador, um site. E para o desenvolvimento de tal, precisamos aprender sobre programação `frontend`.

## Introdução

A programação `frontend` envolve a criação da interface de usuário e a experiência de interação de um site ou aplicativo. Ela se concentra na parte do software com a qual os usuários interagem diretamente. Nesta aula, vamos explorar os conceitos básicos de `HTML`, `CSS` e `JavaScript`, as três tecnologias fundamentais da programação frontend.

Iremos começar pelo mais simples dos 3, o `HTML`. O `HTML` (HyperText Markup Language) é a linguagem de marcação utilizada para criar a estrutura de páginas web. Ele é responsável por definir e posicionar os elementos no navegador.

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

No exemplo acima temos uma página `HTML` com os elementos:
- `DOCTYPE`: Declaração que define a versão do HTML.
- `<html>`: Elemento raiz de um documento HTML.
- `<head>`: Contém metadados sobre o documento, como o conjunto de caracteres e o título.
- `<body>`: Contém o conteúdo visível da página.
- `<h1>`: É um elemento texto como formatação de título
- `<p>`: É um elemento que define um parágrafo de texto

Porém, como o navegador consegue entender isso? 

## Navegador: Interpretando HTML

Quando através do seu navegador você faz um requisição para um site (modelo cliente-servidor), o servidor deste site que processou a requisição te devolve uma `response` com dados. No caso de sites, estes dados são o `HTML`, `CSS` e `javascript` para a página que você está solicitando. Focando somente no `HTML` por hora, o navegador precisa fazer a interpretação do mesmo para saber quais elementos e como mostrá-los na tela para o usuário. Isto é feito através da árvore `DOM` (Document Object Model).

O `DOM` é uma estrutura de dados que o navegador gera ao interpretar o `HTML` que vai determinar a estrutura hierarquica dos objetos na tela, onde cada objeto será um nó na árvore. Esta estrutura é depois passada adiante para ser combinada com a gerada pelo `CSS`.

Após isso ocorre o `paiting` onde o navegador le esta árvore e desenha os elementos na tela, como caixas de texto, parágrados, imagens e outras coisas.

## Navegador: De onde vem as páginas HTML

Nós falamos que as páginas `HTML` podem vir das `responses` do servidor quando requisitado, porém existe outra forma de uma navegador receber uma página web. Nem sempre é desejado que toda requisição que fizermos devolva a página inteira novamente, para isso existem frameworks que sabem alterar apenas a parte necessária da página, e eles são executados no próprio navegador através de `javascript`. Esse tipo de site é chamado de `SPA` (Single Page Application). Logo, o que ocorre é:
- Acessamos um site no nosso navegador.
- Ele carrega a sua página de um diretório estático no servidor apenas nessa primeira requisição.
- A página carregada contém todos os elementos necessários para todo o site, mesmo que eles não sejam visíveis no momento.
- O usuário iterage com o site, e conforme ele vai pedindo dados e fazendo diferente requisições as `APIs`, (que retornam apenas dados em `JSON`) o framework vai recalculando os elementos da página.