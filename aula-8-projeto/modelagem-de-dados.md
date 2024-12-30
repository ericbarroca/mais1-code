# Modelagem de Dados (Data Access Layer & Repository Patterns)

A maioria dos softwares preciam armazenar informações, processá-las e apresenta-las para os usuários. Para nosso projeto isto não será diferente. O desafio conciste em deinir estruturas que façam sentido para o domínio de negócio e que possamos trabalhar com elas em nosso código. Por exemplo, imagina uma aplicação que precisa gerenciar estoque de uma loja de brinquedos. Quais informações são necessárias para que as pessoas possam gerenciar o estoque? Quais as características que os produto armazenados possuem e são relevantes para o negócio? Estes produtos devem ser categorizados e armazenados de acordo?

Em cima deste exemplo vamos podemos rapidamente extrair algumas coisas que podem ser importantes como:

- É um estoque de uma loja de brinquedos, logo todos os produtos são brinquedos.
- Brinquedos podem ter categorias: bonecos/bonecas, jogos lúdicos, esportes...
- Brinquedos podem ter restrições como faixa etária.
- Funcionários precisam saber quantas unidades de certo brinquedo existe no estoque
- Funcionários podem querer dar baixa ou adicionar coisas no estoque

Dadas essas primeiras impressões sobre o sistema podemos assumir algumas coisas para a criação da nossa camada de armazenamento. Para limites desta aula vamos pensar em tabelas, logo nossos dados serão armazenados em tabelas. Cada tabela representará alguma estrutura importante para o sistema e em nosso código uma tabela será equivalente a uma classe. O importante neste momento é identificar quais entidades do mundo real podemos transformar para o mundo da orientação a objeto armazenando informações e exibindo comportamentos relevantes ao negócio.

Neste caso a o `Produto` é um forte candidato a ser uma classe, como os seguintes atributos:
- Categoria
- Nome
- Marca
- Faixa Etária

Abaixo temos a primeira versão do código `C#` para a classe `Produto`.

```csharp
public class Produto {
    public string Categoria {get;set;}
    public string Nome {get;set;}
    public string Marca {get;set;}
    public string FaixaEtaria {get;set;}
}
```

Repare que apesar de ser um sistema de estoque nós não vamos colocar quantidade como um atributo de `Produto`, pois a quantidade não é uma característica do produto e sim do `Estoque`. O que nos leva a próxima classe, o `Estoque`. O estoque se pararmos para analisar pode ser considerado uma lista de produtos, porém ele tem mais algumas caracteríticas como a quantidade de cada produto, logo criaremos um classe chamada `ItemEstoque` primeiramente.

`ItemEstoque` tem os atributos:
- Produto
- Quantidade

Existem algumas possíveis modelagens para esta classe, podemos usar herança

```csharp
public class ItemEstoque:Produto {
    public int Quantidade {get;set;}
}
```
ou composição como abaixo.

```csharp
public class ItemEstoque {
    public Produto Produto {get;set;}
    public int Quantidade {get;set;}
}
```

Como estamos fazendo analogias a tabelas, vamos com composição neste momento, assumindo que `ItemEstoque` será uma tabela que se relaciona com a tabela `Produto`. 

Esta fora do nosso escopo neste momento realmetne modelar um banco de dados e criar as tabelas em si, por tanto vamos simular nosso sistema em memória. Para isso é importante ter a entidade `Estoque`, ela gerencia os itens do estoque, os armazenando e retirando.

Podemos a criar de diferentes formas, vamos usar um pouco do que aprendemos até agora. Porém precisamos pensar que queremos adicionar produtos ao estoque e não `ItemEstoque`, este é só uma abstração nossa para gerenciar o estoque, como podemos fazê-lo?

Existem diversas maneiras de modelar esta estrutura, nós usaremos interfaces e listas.

```csharp
public interface IEstoque
{
    bool Add(Produto produto, int qtd);
    bool Drop(Produto produto, int qtd);

    ItemEstoque Contains(Produto produto);
}

public class Estoque : IEstoque
{
    private List<ItemEstoque> items;

    public Estoque()
    {
        this.items = new List<ItemEstoque>();
    }

    public bool Add(Produto produto, int qtd)
    {
        if (qtd <= 0)
        {
            return false;
        }

        var item = Contains(produto);

        if (item is null)
        {
            ItemEstoque newItem = new ItemEstoque();
            newItem.Produto = produto;
            newItem.Quantidade = qtd;

            items.Add(newItem);
            return true;
        }

        item.Quantidade += qtd;
        return true;

    }

    public ItemEstoque Contains(Produto produto)
    {
        return items.SingleOrDefault(i => i.Produto.Nome == produto?.Nome);
    }

    public bool Drop(Produto produto, int qtd)
    {
        if (qtd <= 0)
        {
            return false;
        }

        var item = Contains(produto);

        if(item is null) {
            return false;
        }

        if (qtd > item.Quantidade) {
            return false;
        }

        item.Quantidade-=qtd;

        if (item.Quantidade == 0) {
            items.Remove(item);
        }
        
        return true;
    }
}
```

Basicamente se quisermos adicionar um produto ao estoque a classe estoque abstrai a conversão do produto em item de estoque e verifica se o mesmo já existe ou não. Caso exista só incrementa a sua quantidade. O mesmo vale para verificação de se o estoque contém certo produto ou na baixa do estoque.

Com isso criamos um modelo bem primitivo e simples para um gerenciador de estoque, que armazena em memória todas as mudanças ocorridas no estoque. Porém há muito espaço para melhorias, você consegue identificá-las?

## Referências

- [Padrões DAO e Repository - Carolina Dias Fonseca, Dev.io](https://dev.to/diariodeumacdf/padroes-dao-e-repository-13nj)


