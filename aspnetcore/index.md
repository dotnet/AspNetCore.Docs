---
título: Introdução ao ASP.NET Core
author: rick-anderson
tradutor: Calkines
descrição: 
palavra-chave: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 08/03/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: index
---

# Intrudução ao ASP.NET Core

Por [Daniel Roth](https://github.com/danroth27), [Rick Anderson](https://twitter.com/RickAndMSFT), e [Shaun Luttin](https://twitter.com/dicshaunary)

O ASP.NET Core é um framework multi-plataforma, alta-performance, [open-source](https://github.com/aspnet/home) para construção moderna, baseada na nuvem e aplicações conectadas à internet. Com o ASP.NET Core, você pode:

* Construir apps e serviços web, IoT apps, e backends para mobile.
* Usar suas ferramentas de desenvolvimento favoritas no Windows, macOS e Linux.
* Implementar para nuvem ou local
* Executar no [.NET Core ou .NET Framework](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).

## Por que usar o ASP.NET Core?

Milhões de devenvolvedores tem usado ASP.NET (e continuam a usá-lo) para criar web apps. O ASP.NET Core é um novo design do ASP.NET, com mudanças arquiteturais que resultaram em um framework mais exuto e modular.

O ASP.NET fornece os seguintes benefícios:

* Um meio unificado para contrução de web UI e web APIs.
* Integração com [modernos frameworks de cliente](xref:client-side/index) e fluxos de desenvolvimento.
* Um [sistema de configuração](xref:fundamentals/configuration) preparado para nuvem e beaseado em ambiente.
* Um sistema de [injeção de dependendência](xref:fundamentals/dependency-injection) embutido.
* Um pipeline de requicições HTTP, leve, de alta performance e modular.
* Habilidade de hospagem em IIS ou em seu próprio processo.
* Pode executar no [.NET Core](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server), que suporta um verdadeiro sistema de versionamente lado-a-lado.
* Ferrametas que simplificam o desenvolvimento web moderno.
* Habilidade de executar no Windows, macOS e Linux.
* Código aberto e com foco na comunidade.

O ASP.NET Core é entregue totalmente via pacotes [NuGet](https://www.nuget.org/). Isso lhe permite otimizar seu aplicativo para incluir somente os pacotes NuGet que você precisa. Os benefícios de uma de aplicação menor incluem maior segurança, serviços reduzidos e melhoria de performance.

## Construir web APIs e web UI usando ASP.NET Core MVC

O ASP.NET Core MVC fornece recursos que ajudam na você a construir [web APIs](xref:tutorials/index#building-web-apis) e [web apps](xref:tutorials/index#building-web-applications):

* O [Padrão Model-View-Controller (MVC)](xref:mvc/overview) ajuda tornar seus web APIs e web apps mais [testáveis](testing/index.md).
* [Páginas Razor](xref:mvc/razor-pages/index) (novas na versão 2.0) é um modelo de programação baseada em páginas que fazem a construção de web UI mais fáceis e produtivas.
* A [sintaxe razor](xref:mvc/views/razor) fornece um linguagem produtiva para [Páginas Razor](xref:mvc/razor-pages/index) e [Exibições MVC](xref:mvc/views/overview).
* [Tags Facilitadoras](xref:mvc/views/tag-helpers/intro) habilita o lado servidor a participar da criação e renderização de elementos HTML nos arquivos Razor.
* Suporte nativo para [negociação de conteúdo e multiplo formato de dados](xref:mvc/models/formatting.md) permite aos seus web APIs 
atinjam um ampla gama de clientes, incluindo navegadores e dispositivos móveis.
* O [Vinculo de Modelo](xref:mvc/models/model-binding) mapeia automaticamente dados de requisições HTTP para parâmetros de métodos de ação.
* A [Validação de Modelo](xref:mvc/model/validation) realiza automaticamente validações do lado do cliente ou servidor.

## Desenvolvimento do lado Cliente.

O ASP.NET Core foi desenvolvido para integrar perfeitamente com uma variedade de frameworks para cliente, incluindo [AngularJS](xref:client-side/angular), [KnockoutJS](xref:client-side/knockout), e [Bootstrap](xref:client-side/bootstrap). Veja [Desenvolvimento client-side](xref:client-side/index.md) para mais detalhes.


## Próximas etapas

Para mais informações, veja os recursos seguintes:

* [Tutoriais ASP.NET Core](xref:tutorials/index)
* [Fundamentos ASP.NET Core](xref:fundamentals/index)
* [Boletim semanal da comunidade ASP.NET](https://live.asp.net/) cobre o progresso do time e seus planos, novos blogs funcionais e software de terceiros.
