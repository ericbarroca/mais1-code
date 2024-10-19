# Ferramentas

Iniciaremos pelo estudo das ferramentas mais básicas que todo o desenvolvedor deve ter conhecimento de como usar. Elas são:

- `CMD/Shell`: São linguagens escripitadas que nos permitem dar comandos ao computador para uso de diversas aplicações e que nos permite ter agilidade, precisaão e possibilidade de automação de tarefas. No `Windows` usaremos o `CMD` e para quem estiver em `Linux` pode usar `shell/bash`.
- Versionador de Código (`GIT`): É um sistema de gerenciamento de código, ele permite que múltiplas pessoas trabalhem simultaneamente no mesmo código, backups e versionamentos. O mais utilizado é o `GIT`, que é o que utilizaremos.
- IDE (`Visual Code`): IDEs são os editores de código, onde escreveremos e testaremos nosso código. Existem milhares de IDEs cada uma com suas vantagens e desvantagens. Neste curso utilizaremos o `Visual Code`.

## CMD

### Instalação

O `CMD` não requer instalção, já vem junto do windows e para acessar basta diigitar na barra de pesquisa `CMD`. Você verá la lista uma aplicação chamada `Prompt de Comando`, basta abri-lá e você verá uma tela preta com o cursor.

### Uso

Nesta tela digitamos comandos para as ações que desejamos executar. Neste [site](https://myelo.elotouch.com/support/s/article/Common-Windows-Command-Prompt-CMD-Commands) temos uma lista de comandos mais usados.

## GIT

### Instalação

Para instalar o GIT acesse o [aqui](https://git-scm.com/book/pt-br/v2/Come%C3%A7ando-Instalando-o-Git) e siga as intruções para o seu sistema operacional.

Caso necessite de um passo a passo, pode seguir o do [Dicas de Programação](https://dicasdeprogramacao.com.br/como-instalar-o-git-no-windows/).

### Funcionamento

Quando usamos o GIT ele nos proporciona uma forma de armazenarmos, compartilharmos e editarmos nosso código de forma colaborativa e ordenada. 

Primeiro devemos entender que o GIT é um sistema de arquivos que os armazena de forma centralizada, porém permite que cópias sejam feitas, alteradas e depois sincronizadas. Vejam o artigo [ Começando - Sobre Controle de Versão](https://git-scm.com/book/pt-br/v2/Come%c3%a7ando-Sobre-Controle-de-Vers%c3%a3o).

Isso permite por exemplo que 2 pessoas ou mais alterem o mesmo arquivo de código e não exista perdas de trechos escritos por uma delas. Ainda indo além, como por exemplo, em um caso que essas pessoas tenham editado o mesmo trecho neste arquivo ele sinalizará um conflito quando a pessoa com as alterações conflitantes tenta enviá-las para o repositório, forçando a mesma a resolver este conflitos. 

Para melhorar ainda mais a colaboração na edição de código o Git nos permite separar frentes de trabalho através de `branches`. Imagine que existem 2 equipes trabalhando no mesmo software (mesma codebase), porém a equipe 1 está entregando uma funcionalidade e a equipe 2 outra. Não existe dependencia entra as funcionalidades, porém se estas equipes estiverem editando a mesma `branch` uma funcionalidade não pode ser lançada independentemente da outra. 

Para isso no Git é possível se trabalhar com múltiplas `branches`, onde a equipe 1 e 2 podem criar suas respectivas `branches` e trabalharem de forma independente nos seus lançamentos. E quando as 2 funcionalidades estiverem prontas basta juntá-las através do `merge`. Você pode se aprofundar no tema lendo [Branches no Git - Branches em poucas palavras](https://git-scm.com/book/pt-br/v2/Branches-no-Git-Branches-em-poucas-palavras).

### USO

O git contém uma série de comandos que podemos executar pelo CMD para que possamos interagir com o nosso repositório de código. No caso vamos usar o [GitHub](https://github.com/), então primeiramente criem uma conta no mesmo e me passem os usuários de vocês para que eu possa dar acesso a este repositório que é onde iremos trabalhar.

O git contém uma série de comandos que nos ajudam a interagir com um repositório, porém para a finalidade deste curso vamos passar por 7.

- `git clone <repositorio>`: Clona um repositório para a sua máquina.
- `git pull <branch>`: Atualiza a sua `branch` local com o conteúdo mais recente da `branch` selecionada do repositório.
- `git status`: Mostra as divergencia das suas alterações não comitadas versus a versão local. 
- `git add <arquivos>`: Adiciona arquivos a lista de mudanças a serem incluídas em um próximo `commit`.
- `git commit -m "<mensagem>"`: Cria um `commit` local com as mudanças da lista de mudanças (staged).
- `git push`: Envia as alterações comitadas para o repositório remoto (centralizado)
- `git checkout -b <branch>`: Cria uma nova `branch` a partir da `branch` que você se encontra localmente.

## Visual Code

### Instalação

Baixar e instalar o (Visual Code)[https://code.visualstudio.com/download]

### Uso

Através do `CMD` navegue até a pasta desejada e use o comando `code .`. Isto abrirá a pasta em que você se localiza na IDE.


## Referencias

- [Common Windows Command Prompt (CMD) Commands, elo](https://myelo.elotouch.com/support/s/article/Common-Windows-Command-Prompt-CMD-Commands)
- [Como instalar o GIT no Windows (Passo a passo!), Dicas de Programação](https://dicasdeprogramacao.com.br/como-instalar-o-git-no-windows/)
- [Começando - O Básico do GIT](https://git-scm.com/book/pt-br/v2/Come%C3%A7ando-O-B%C3%A1sico-do-Git).
- [Branches no Git - Branches em poucas palavras](https://git-scm.com/book/pt-br/v2/Branches-no-Git-Branches-em-poucas-palavras)

