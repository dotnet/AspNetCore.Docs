# Contruibuindo com a documentação do ASP.NET

Este documento cobre o processo de contribuição a artigos e códigos exemplos, que estão hospedados no [site de Documentação ASP.NET](https://docs.microsoft.com/aspnet/). Contribuições podem ser simples, como correções de ortográfia, ou complexas, como novos artigos.

## Como fazer correções simples ou sugestões

Artigos são armazenados no repositório como arquivos com Estilo de Marcação. Mudanças simples no conteúdo desses arquivos podem ser feitas pelo navegador, selecionando o atalho **Editar** no canto direito da janela de navegação. (Em janelas de navegação estreitas você vai precisar expandir a barra de **opções** para ver o atalho **Editar**.) Siga as instruções para criar uma requisição de envio (PR, pull request). Nós revisaremos a requisição, podendo aceitá-la ou sugerir mudanças.

## Como fazer contribuições mais complexas

Você vai precisar de um entendimento básico do [Git e GitHub.com](https://guides.github.com/activities/hello-world/).

* Abrir uma [questão](https://github.com/aspnet/Docs/issues/new), descrevendo o que você quer fazer, como alterar um artigo existênte ou criar um novo. Aguarde a aprovação do time antes de você investir muito tempo.
* Bifurcar o repositório [aspnet/Docs] (https://github.com/aspnet/Docs/) e criar uma ramificação para suas mudanças.
* Enviar uma solicitação de mudança (PR) para o repositório principal, juntamente com suas alterações.
* Se o rótulo 'grupo-requerido' for atribuído à sua solicitação de mudança, [preencha o Termo de Licenciamente de Contribuição (CLA)](https://cla2.dotnetfoundation.org/)
* Responda o questionário de retorno da Solicitação de Mudança.

Serve como exemplo este processo, que levou a publicação de um novo artigo: veja [questão 67](https://github.com/dotnet/docs/issues/67) e [solitação de mudança 798](https://github.com/dotnet/docs/pull/798) no repositório .NET. O novo artigo é [Documentando seu código](https://docs.microsoft.com/dotnet/articles/csharp/codedoc).

## Sintaxe do Estilo de Marcação

Artigos são escritos em [Estilo de Marcação DocFx-flavored](http://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html), que é um super conjunto do [Estilo de Marcação GitHub-flavored (GFM)](https://guides.github.com/features/mastering-markdown/). Para exemplos da sintaxe DFM para funcionalidades de UI, geralmente usadas na documentação do ASP.NET, veja [Modelo de Metadados e Estilo de Marcação](https://github.com/dotnet/docs/blob/master/styleguide/template.md) no repositório .NET de guia de estilos.

## Convenção de estrutura de pastas

Para cada arquivo de Estilo de Marcação pode haver uma pasta para imagens e outra para códigos de demonstração. Por exemplo, se o artigo for [fundamentos/configuração.md] (https://github.com/aspnet/Docs/blob/master/aspnetcore/fundamentals/configuration.md), as imagens estarão em [fundamentos/configuração/\estatico](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/configuration/_static) e os arquivos de projetos de aplicações demonstrativas estarão em [fundamentos/configuração/demonstração](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/configuration/sample). Uma imagem no arquivo *fundamentos/configuração.md* é renderizada pelo seguinte Estilo de Marcação.
```
![descrição da imagem para tecla alt](configuration/_static/imagename.png)
```
**Todas** imagens precisam ter [texto alternativo](https://wikipedia.org/wiki/Alt_attribute).

Nomes de arquivos de Estilo de Marcação e nomes de arquivos de imagem precisam ser escritos em letras minúsculas.

## Atalhos internos

Atalhos internos devem usar o `uid` do artigo destino com um atalho xref:

`[texto de atalho](xref:uid_do_tópico)`

Veja [Referência cruzada DocFX](http://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html#cross-reference) para mais informações.


## Trechos de código

Geralmente artigos contêm trechos de código para ilustrar alguns pontos. O DFM permite que você copie o código em um arquivo de Estilo de Marcação ou referencie um arquivo de código separado. Nós preferimos usar arquivos de código separados sempre que possível, assim minimizamos as chances de erros no código. Os arquivos de código precisam ser armazenados no repositório usando a estrutura de pastas, para projeto de demonstração, descrita acima.

Aqui estão alguns exemplos da [Sintaxe de trechos de código DFM](http://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html#code-snippet) que seria usada em um arquivo *configuração.md*.

Para renderizar um arquivo de código completo como um trecho:

```
[!código-csharp[Main](configuração/demonstração/Program.CS)]
```
Para renderizar uma parte de um arquivo como um trecho utilizando os números das linhas:

```
[!código-csharp[Main](configuração/demonstração/Program.cs?range=1-10,20,30,40-50]
[!código-html[Main](configuração/demonstração/Exibições/Inicial/Index.cshtml?range=1-10,20,30,40-50]
```

Para trechos C#, você pode referenciar uma [Região C#](https://docs.microsoft.com/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-region). Sempre que possível, use regiões em vez de números de linhas, porque estes, no arquivo de código, tendem a mudar e perder a sincronia com o a referencia no arquivo de Estilo de Marcação. Regiões C# podem ser embutidas, e se você referenciar a região externa, as diretivas de `#region` interna e a `#endregion` não são renderizadas naquele trecho.

Para renderizar uma região C# com nome de "trecho_Exemplo":

```
[!código-csharp[Main](configuração/demonstração/Program.cs?name=trecho_Examplo)]
```

Para destacar as linhas selecionadas em um trecho renderizado (usualmente renderizado com cor de fundo amarela):

```
[!código-csharp[Main](configuração/demonstração/Program.cs?name=trecho_Exemplo&highlight=1-3,10,20-25)]
[!código-csharp[Main](configuração/demonstração/Program.cs?range=10-20&highlight=1-3]
[!código-html[Main](configuração/demonstração/Exibições/Inicial/Index.cshtml?range=10-20&highlight=1-3]
[!código-javascript[Main](configuração/demonstração/Project.json?range=10-20&highlight=1-3]
```

## Teste suas mudanças com o DocFX

Teste suas mudanças com a [ferramenta de linha de comando DocFX](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html#2-use-docfx-as-a-command-line-tool), que cria uma versão hospedada localmente do site. O DocFX não renderiza estilos e extensões de site criados para docs.microsoft.com.

O DocFX requer o .NET Framework para sistemas Windows, ou Mono para sistemas Linux e macOS.

### Instruções para usuários Windows

* Baixe e descompacte o arquivo *docfx.zip* de [liberações DocFX](https://github.com/dotnet/docfx/releases).
* Adicione o DocFX no seu endereço.
* Em uma janela de comando Windows, navegue até a pasta apropriada que contem o arquivo *docfx.json* (*aspnet* para conteúdo ASP.NET ou *aspnetcore* para conteúdo ASP.NET Core) e execute os seguintes comandos:

   ```
   docfx --serve
   ```
* De algum navegador, informe o endereço `http://localhost:8080`.

### Instruções para usuários Mono

* Instale o Mono via Homebrew - `brew install mono`.
* Baixe a [última versão do DocFX](https://github.com/dotnet/docfx/releases).
* Extraia para `\bin\docfx`.
* Crie um atalho para **docfx**:

  ```
  function docfx {
    mono $HOME/bin/docfx/docfx.exe
  }
    
  function docfx-serve {
    mono $HOME/bin/docfx/docfx.exe serve _site
  }
  ```

* Execute **docfx** no diretório `Docs\aspnet` ou `Docs\aspnetcore` para construir o site, e **docfx-serve** para exibir o site em `http://localhost:8080`.

## Voz e Tom

Nosso objetivo é escrever esta documentação de forma fácil e que seja compreendida por a maior parte possível de nossos leitores. Com esse objetivo nós estabelecemos diretrizes para estilo de escrita que pedimos aos nossos contribuidores para seguir. Para mais informações veja [Diretrizes de voz e tom](https://github.com/dotnet/docs/blob/master/styleguide/voice-tone.md) no repositório .NET.

## Redirecionamentos

Se você deletar um artigo, alterar seu nome, ou mover para uma pasta diferente, crie um redirecionamento para que as pessoas que anotaram o artigo não receba erros de navegação estilo 404. Adicione redirecionamentos ao [arquivo principal de redirecionamento](https://github.com/aspnet/Docs/blob/master/.openpublishing.redirection.json).
