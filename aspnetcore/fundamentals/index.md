---
título: Fundamentos ASP.NET Core
autor: rick-anderson
tradutor: calkines
descrição: Este artigo fornece uma visão geral dos conceitos fundamentais a serem entendidos na criação de aplicações ASP.NET Core. 
palavras-chave: ASP.NET Core,fundamentals,overview
ms.autor: riande
gerente: wpickett
ms.data: 08/18/2017
ms.tópico: get-started-article
ms.assetid: a19b7836-63e4-44e8-8250-50d426dd1070
ms.tecnologia: aspnet
ms.produto: asp.net-core
uid: fundamentals/index
ms.custom: H1Hack27Feb2017
---

# Visão geral sobre os fundamentos do ASP.NET Core

Uma aplicação ASP.NET Core é um aplicativo de console que cria um servidor web em seu método `Main`:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program2x.cs)]

O método `Main` invoca o `WebHost.CreateDefaultBuilder`, que segue o Padrão de Construção para criar um host de aplicação web. O construtor tem métodos que definem o servidor web (por exemplo, `UseKestrel`) e a classe Startup (`UseStartup`). No exemplo anterior, um servidor web [Kestrel](xref:fundamentals/servers/kestrel) é automaticamente alocado. O host web do ASP.NET Core tentará executar via IIS, se este estiver disponível. Outros servidores web, como um [HTTP.sys](xref:fundamentals/servers/httpsys), podem ser usados ao invocar o método de extensão apropriado. `UseStartup` será explicado depois, na próxima seção.

`IWebHostBuilder`, o tipo de retorno da invocação ao `WebHost.CreateDefaultBuilder` fornece muitos métodos opcionais. Muitos destes métodos incluem `UseHttpSys` para hospedar a aplicação no HTTP.sys, e `UseContextRoot` para especificar o diretório de conteúdo raiz. Os métodos `Build` e `Run` criam o objeto `IWebHost` que hospedará a aplicação e começará a escutar as requisições HTTP.

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program.cs)]

O método `Main` usa o `WebHostBuilder`, que segue o Padrão de Construção para criar um host de aplicação web. O construtor tem métodos que definem o servidor web (por exemplo, `UseKestrel`) e a classe Startup (`UseStartup`). No exemplo sguinte, o servidor web [Kestrel](xref:fundamentals/servers/kestrel) é usado. Outros servidores web, como [WebListener](xref:fundamentals/servers/weblistener), podem ser usados invocando o método de extensão apropriado. `UseStartup` será explicado depois, na seção seguinte.

O `WebHostBuilder` fornece diversos métodos opcionais, incluindo `UseIISIntegration` para hosts que usam IIS e IIS Express, e `UseContextRoot` para especificar o diretório de conteúdo raiz. Os métodos `Build` e `Run` constroem o objeto `IWebHost` que hospedará a aplicação e começará a escutar as requisições HTTP.

---

## A Classe Startup

O método `UseStartup` no `WebHostBuilder` especifica a classe `Startup` para seu aplicativo:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program2x.cs?highlight=10&range=6-17)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program.cs?highlight=7&range=6-17)]

---

É na classe `Startup` que você define o pipeline de tratamento de solicitações e configura qualquer serviço exigido pela aplicação.
A classe `Startup` precisa ser pública e conter os seguintes métodos:

```csharp
public class Startup
{
    // Este método será chamado pelo runtime. Use este método para adicionar serviços ao recipiente.
    public void ConfigureServices(IServiceCollection services)
    {
    }

    // Este método será chamado pelo runtime. Use este método para configurar o pipeline de requisições HTTP.
    public void Configure(IApplicationBuilder app)
    {
    }
}
```

* `ConfigureServices` define os [Serviços](#services) usados por sua aplicação (como exemplo, ASP.NET Core MVC, Entity Framework Core, Idnetity, etc.).

* `Configure` define o [middleware](xref:fundamentals/middleware) no pipeline de requisições.

Para mais informações, veja [Startup de aplicação](xref:fundamentals/startup).

## Serviços

Um serviço é um componente que é projetado para ser consumido de forma comum na aplicação. Serviços são disponibilizados através de [injeção de dependência](xref:fundamentals/dependency-injection) (DI, dependency injection). O ASP.NET Core inclui um controle nativo de inversão de dependência (IoC, inversion of control), que suporta [injeção de construtor](xref:mvc/controllers/dependency-injection#constructor-injection) por padrão. O container nativo pode ser substituído pelo container de sua escolha. Além disso, traz o benefício do baixo acopalhamento, DI faz que os serviços permaneçam disponíveis através de sua aplicação. Por exemplo, [logging](xref:fundamentals/logging) está disponível através de sua aplicação.

Para mais informações, veja [Injeção de Dependência](xref:fundamentals/dependency-injection).

## Middleware

No ASP.NET Core, você compõem seu pipeline de requisições usando [Middleware](xref:fundamentals/middleware). O ASP.NET Core middleware realiza uma lógica assíncrona no `HttpContext` e então invoca o próximo middleware ou termina a requisição diretamente. Um componente middleware chamado "XYZ" é adicionado invocando um método de extensão `UseXYZ` no método `Configure`.

O ASP.NET Core vem com um rico conjunto de middlewares pré-fábricados:

* [Arquivos Estáticos](xref:fundamentals/static-files)

* [Rotas](xref:fundamentals/routes)

* [Authentication](xref:security/authentication/index)

Você pode usar qualquer [OWIN](http://owin.org)-based middleware com ASP.NET Core, além de poder escrever seus próprio middleware customizado.

Para mais informações, veja [Middleware](xref:fundamentals/middleware) e [Interface Web Aberta para .NET (OWIN)](xref:fundamentals/owin).

## Servidores

O modelo de host do ASP.NET Core não escuta requisições diretamente; em vez disso, ele depende de uma implementação de um servidor HTTP para encaminhar as requisições para a aplicação. A requisição encaminhada é envolvida por um conjunto de objetos característicos que você pode acessar através de interfaces. A aplicação compõe este conjunto em um `HttpContext`. O ASP.NET Core incluí um servidor web gerenciado, multi-plataforma, chamado [Kestrel](xref:fundamentals/servers/kestrel). O Kestrel é geralmente executado por trás de um servidor web de produção como o [IIS](https://www.iis.net/) ou [ngix](http://ngix.org).

Para mais informações, veja [Servidores](xref:fundamentals/servers/index) e [Hospedagem](xref:fundamentals/hosting).

## Diretório de Conteúdo Raiz

O diretório de conteúdo raiz é o diretório base de qualquer conteúdo usado pelo aplicativo, como exibições, [Páginas Razor](xref:mvc/razor-pages/index), e ativos estáticos. Por padrão, o direitório de conteúdo raiz é o mesmo daquele em que a aplicação está sendo hospedada. Um local alternativo para o diretório de conteúdo raiz é especificado no `WebHostBuilder`.

## Diretório Web

O diretório de web raiz de um aplicação é aquele diretório do projeto que contem recursos, públicos ou estáticos, como CSS, JavaScript e arquivos de imagem. Por padrão, o middleware de arquivos estáticos servirá apenas arquivos do direitório de web raiz e seus sub-diretórios. Veja [trabalhando com arquivos estáticos](xref:fundamentals/static-files) para mais informações. O caminho do diretório de web raiz padrão é */wwwroot*, mas você pode especificar um local diferente usando o `WebHostBuilder`.

## Configuração

O ASP.NET Core usa um novo modelo de configuração para manipular pares simples de nome-valor. O novo modelo de configuração não é baseado no `System.Configuration` ou *web.config*; em vez disso, ele resgata as configurações de um conjunto de provedores de configuração. Os provedores de configuração embutidos suportam um variedade de formato de arquivos (XML, JSON, INI) e variáveis de ambiente para permitir configuração baseada em ambiente. Você também pode escrever seu próprio providor de configuração.

Para mais informações, veja [Configuração](xref:fundamentals/configuration).

## Ambientes

Ambientes, como "Desenvolvimento" ou "Produção", são a primeira noção de classe no ASP.NET Core e podem ser configurados usando variáveis de ambiente.

Para mais informações, veja [Trabalhando com Ambientes Múltiplos](xref:fundamentals/environments).

## .NET Core vs. .NET Framework runtime

Uma aplicação ASP.NET Core pode objetivar um runtime .NET Core ou um runtime .NET Framework. Para mais informações, veja [Escolhendo entre .NET Core and .NET Framework](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).

## Informações Adicionais

Veja também os tópicos seguintes:

- [Manipulação de Erro](xref:fundamentals/error-handling)
- [Provedores de Arquivo](xref:fundamentlas/file-providers)
- [Localização e Globalização](xref:fundamentals/localization)
- [Logging](xref:fundamentals/logging)
- [Gerenciamente de Estado da Aplicação](xref:fundamentals/app-state)

