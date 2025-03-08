# CSS

Nessa aula vamos estilizar nossa páginas `HTML` com `CSS`. `CSS`, ou Cascading Style Sheets, é a linguagem usada para estilizar documentos `HTML`. Ela permite que os desenvolvedores controlem a aparência visual de uma página web, incluindo layout, cores, fontes e muito mais. Nesta aula, vamos explorar os conceitos básicos de `CSS`, como funciona, e como aplicá-lo a documentos `HTML`.

## Sintaxe

`CSS` é composto por seletores e declarações. Um seletor aponta para o elemento `HTML` que você deseja estilizar, e uma declaração especifica o estilo a ser aplicado. As declarações são compostas por propriedades e valores.

```css
seletor {
    propriedade: valor;
}
```

Vamos começar com um exemplo simples de como aplicar `CSS` a um documento `HTML`.

```html
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Exemplo CSS Básico</title>
    <style>
        body {
            background-color: #f0f0f0;
            font-family: Arial, sans-serif;
        }
        h1 {
            color: #333;
            text-align: center;
        }
        p {
            color: #666;
            padding: 20px;
        }
    </style>
</head>
<body>
    <h1>Exemplo de Estilos CSS</h1>
    <p>Este é um parágrafo estilizado com CSS.</p>
</body>
</html>
```

Percebam que esta página `HTML` tem o elemento `<style>`, ele permite definirmos `CSS` dentro de uma página `HTML`. Isso se chama `embedded css`. Agora vamos analisar o código `CSS` em si. 

<details>
<summary><b>Quantos seletores temos?</b></summary>

Temos 3 seletores: `body`, `h1` e `p`.
</details>

Estes seletores presentes são identificadores de tipo, eles selecionam todos os elementos presentes na página `HTML` que sejam daquele tipo e aplicam os valores as propriedades especificadas no `CSS`. Nesta página por exemplo o seletor `body` do `CSS` seleciona todos os elementos `<body>` do `HTML` e muda a cor de fundo e a fonte usada.

## Seletores

Existem diversos tipos de seletores, vamos ver alguns.

### Seletor de Tipo

Selecionam todos os elementos de um tipo específico. No exemplo abaixo mudamos a cor do texto de todos os parágrafos para azul.

```css
p {
    color: blue;
}
```

### Seletor de Classe

Selecionam elementos com uma classe específica (atributo `class`). Classes são definidas com um ponto (.) seguido pelo nome da classe.

```html
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Exemplo CSS Básico</title>
    <style>
        .minha-classe {
            color: green;
        }
    </style>
</head>
<body>
    <h1 class="minha-classe">Exemplo de Estilos CSS</h1>
    <p>Este é um parágrafo estilizado com CSS.</p>
</body>
</html>
```
### Seletor de ID

Selecionam um elemento único com um ID específico. IDs são definidos com um hashtag (#) seguido pelo nome do ID.

```html
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Exemplo CSS Básico</title>
    <style>
        #meu-id {
            color: red;
        }
    </style>
</head>
<body>
    <h1 id="meu-id">Exemplo de Estilos CSS</h1>
    <p>Este é um parágrafo estilizado com CSS.</p>
</body>
</html>
```

### Seletor de Atributo

Selecionam elementos com um atributo específico.

```html
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Exemplo CSS Básico</title>
    <style>
        input[type="text"] {
            border: 1px solid black;
        }

    </style>
</head>
<body>
    <h1>Exemplo de Estilos CSS</h1>
    <input type="text"/>
</body>
</html>
```

### Seletor de Descendentes

Selecionam elementos que são descendentes de um elemento específico. No exemplo abaixo só serão estilizados elementos que sejam `<p>` e sejam descentes de uma `<div>`.

```html
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Exemplo CSS Básico</title>
    <style>
        div p {
            color: purple;
        }
    </style>
</head>
<body>
    <h1>Exemplo de Estilos CSS</h1>
    <p>Este é um parágrafo.</p>
    <div>
        <p>Este é um parágrafo estilizado com CSS.</p>
    </div>
</body>
</html>
```

## Propriedades CSS

Cada elemento tem seu conjunto de propriedades que pode ser alterado no `CSS`. Para saber as propriedades que um elemento suporta leia sua documentação `CSS`. Porém algumas propriedades são comuns entre elementos. Exemplos:

- Cor e Fundo

```css
color: blue; /* Cor do texto */
background-color: yellow; /* Cor de fundo */
```

- Elementos Texto

```css
font-size: 16px; /* Tamanho da fonte */
font-weight: bold; /* Espessura da fonte */
text-align: center; /* Alinhamento do texto */
```

- Diagramação de Elementos

```css
margin: 10px; /* Margem externa */
padding: 10px; /* Preenchimento interno */
```

- Bordas

```css
border: 1px solid black; /* Borda sólida */
border-radius: 5px; /* Bordas arredondadas */
```

- Layout

```css
display: block; /* Exibição em bloco */
display: inline-block; /* Exibição em linha e bloco */
display: flex; /* Layout flexível */
```

## Hierarquia e Especificidade

CSS usa uma hierarquia e regras de especificidade para determinar quais estilos são aplicados quando há conflitos. Regras mais específicas têm prioridade sobre regras menos específicas.

Os conflitos são definidos como dos seletores que tem ser aplicados em 1 mesmo elemento. Exemplo:

```html
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Exemplo CSS Básico</title>
    <style>
        .minha-classe {
            color: green;
            background-color: red
        }
        div p {
            color: purple;
        }
    </style>
</head>
<body>
    <h1>Exemplo de Estilos CSS</h1>
    <p class="minha-classe">Este é um parágrafo.</p>
    <div>
        <p>Este é um parágrafo estilizado com CSS.</p>
    </div>
</body>
</html>
```

A regra a ser seguida para aplicar os estilos é na seguinte ordem:
- IDs (`#meu-id`) têm maior especificidade.
- Classes (`.minha-classe`) têm média especificidade.
- Elementos (`p`) têm menor especificidade.

Se 2 regras de `CSS` tiverem a mesma especificidade a última declarada tem priporidade.

## Separando CSS do HTML

Por melhor organização e boas práticas o `CSS` é separado do `HTML` em um arquivo ou múltplos arquivos próprios. Isso pode ser feito da seguinte forma:

- Crie um arquivo chamado `estilos.css`

```css
/* estilos.css */
body {
    background-color: #f0f0f0;
    font-family: Arial, sans-serif;
}

h1 {
    color: #333;
    text-align: center;
}

p {
    color: #666;
    padding: 20px;
}
```

- crie um arquivo chamado `main.html` referenciando o arquivo `estilos.css` usando `<link rel="stylesheet" href="estilos.css">`. A tag `<link>` no `<head>` especifica o caminho para o arquivo CSS (`href="estilos.css"`) e define que é uma folha de estilos (`rel="stylesheet"`).

```html
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Exemplo CSS Externo</title>
    <link rel="stylesheet" href="estilos.css">
</head>
<body>
    <h1>Exemplo de Estilos CSS</h1>
    <p>Este é um parágrafo estilizado com CSS.</p>
</body>
</html>
```

