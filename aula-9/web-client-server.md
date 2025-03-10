# Desenvolvimento Web - Client/Server

O modelo `cliente-servidor` é um dos paradigmas mais fundamentais na arquitetura de redes e desenvolvimento web. Ele descreve a interação entre dois componentes principais: o cliente e o servidor.

## O que é o Modelo Cliente-Servidor?

O modelo `cliente-servidor` é uma arquitetura em que o cliente faz solicitações de serviços e o servidor fornece esses serviços. O cliente é geralmente um navegador web ou um aplicativo que acessa serviços hospedados em um servidor.

- `Cliente`: Envia solicitações ao servidor. Pode ser um navegador web, um aplicativo móvel, ou qualquer dispositivo conectado à internet.

- `Servidor`: Recebe e processa as solicitações do cliente, retornando os dados ou serviços solicitados.

## Como Funciona?

<p align="center">
    <img src="client-server.drawio.png">
</p>

O cliente envia uma solicitação ao servidor (`Request`). Por exemplo, quando você digita uma `URL` em um navegador e pressiona `Enter`, o navegador envia uma solicitação `HTTP` para o servidor. O servidor recebe a solicitação, processa-a e prepara uma resposta. Durante essa requisição o servidor pode consultar um banco de dados, executar lógica de negócios, etc.

Após o processamento o servidor envia a resposta de volta ao cliente. Esta resposta pode ser uma página `HTML`, dados em formato `JSON`, arquivos, etc. Após isso, o cliente recebe a resposta e a processa ou exibe ao usuário. Por exemplo, o navegador renderiza a página `HTML` para o usuário visualizar.

## Protocolo HTTP
O protocolo `HTTP` (HyperText Transfer Protocol) é a base para a comunicação entre clientes e servidores na web. Funciona sobre o protocolo `TCP/IP` e define como as mensagens são formatadas e transmitidas, e como os servidores e navegadores devem responder às várias solicitações. Neste tipo de comunicação, diferentes métodos `HTTP` são usados para operações diferentes, como `GET` (recuperar dados), `POST` (enviar dados), `PUT` (atualizar dados), `DELETE` (excluir dados), etc.

## Vantagens do Modelo Cliente-Servidor

- Modularidade: Separação clara entre cliente e servidor, facilitando a manutenção e atualização.

- Escalabilidade: Servidores podem ser escalados verticalmente (mais recursos) ou horizontalmente (mais servidores) para lidar com maior carga.

- Flexibilidade: Facilita a comunicação entre diferentes plataformas e dispositivos.

## Desvantagens do Modelo Cliente-Servidor

- Ponto Único de Falha: O servidor é um ponto crítico, e se ele falhar, todos os clientes dependentes podem ser afetados.

- Latência: A comunicação entre cliente e servidor pode introduzir latência, especialmente em conexões de longa distância.

## Exemplos Práticos

- Aplicações Web Tradicionais: Navegadores web fazem solicitações a servidores web para obter páginas `HTML` e recursos.

- `APIs RESTful`: Clientes (como aplicativos móveis) fazem solicitações `HTTP` a `APIs RESTful` hospedadas em servidores para obter ou enviar dados.

- Aplicações de Chat em Tempo Real: Clientes enviam mensagens a um servidor, que as distribui para outros clientes conectados.

## Referências

- [Modelo client-servidor, Wikipedia](https://pt.wikipedia.org/wiki/Modelo_cliente%E2%80%93servidor)
- [EEL878 - redes de Computadores I, Luís Henrique Maciel Kosmalski Costa - UFRJ](https://www.gta.ufrj.br/ensino/eel878/redes1-2020-4/slides/Parte2_Aplicacoes_1P.pdf)
- [Visão geral do ASP.NET Core MVC, Microsoft](https://learn.microsoft.com/pt-br/aspnet/core/mvc/overview?view=aspnetcore-9.0&WT.mc_id=dotnet-35129-website)