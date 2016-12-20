---
title: "Tutorial: Server Broadcast with SignalR 2 | Microsoft Docs"
author: tdykstra
description: "This tutorial shows how to create a web application that uses ASP.NET SignalR 2 to provide server broadcast functionality. Server broadcast means that commun..."
ms.author: riande
manager: wpickett
ms.date: 10/13/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-signalr
ms.prod: .net-framework
msc.legacyurl: /signalr/overview/getting-started/tutorial-server-broadcast-with-signalr
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\signalr\overview\getting-started\tutorial-server-broadcast-with-signalr.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/51339) | [View dev content](http://docs.aspdev.net/tutorials/signalr/overview/getting-started/tutorial-server-broadcast-with-signalr.html) | [View prod content](http://www.asp.net/signalr/overview/getting-started/tutorial-server-broadcast-with-signalr) | Picker: 59947

Tutorial: Server Broadcast with SignalR 2
====================
by [Tom Dykstra](https://github.com/tdykstra), [Tom FitzMacken](https://github.com/tfitzmac)

> This tutorial shows how to create a web application that uses ASP.NET SignalR 2 to provide server broadcast functionality. Server broadcast means that communications sent to clients are initiated by the server. This scenario requires a different programming approach than peer-to-peer scenarios such as chat applications, in which communications sent to clients are initiated by one or more of the clients.
> 
> The application that you'll create in this tutorial simulates a stock ticker, a typical scenario for server broadcast functionality.
> 
> This topic was originally written by Patrick Fletcher.
> 
> ## Software versions used in the tutorial
> 
> 
> - [Visual Studio 2013](https://www.microsoft.com/visualstudio/eng/2013-downloads)
> - .NET 4.5
> - SignalR version 2
>   
> 
> 
> ## Using Visual Studio 2012 with this tutorial
> 
> 
> To use Visual Studio 2012 with this tutorial, do the following:
> 
> - Update your [Package Manager](http://docs.nuget.org/docs/start-here/installing-nuget) to the latest version.
> - Install the [Web Platform Installer](https://www.microsoft.com/web/downloads/platform.aspx).
> - In the Web Platform Installer, search for and install **ASP.NET and Web Tools 2013.1 for Visual Studio 2012**. This will install Visual Studio templates for SignalR classes such as **Hub**.
> - Some templates (such as **OWIN Startup Class**) will not be available; for these, use a Class file instead.
> 
> 
> ## Tutorial Versions
> 
> For information about earlier versions of SignalR, see [SignalR Older Versions](../older-versions/index.md).
> 
> ## Questions and comments
> 
> Please leave feedback on how you liked this tutorial and what we could improve in the comments at the bottom of the page. If you have questions that are not directly related to the tutorial, you can post them to the [ASP.NET SignalR forum](https://forums.asp.net/1254.aspx/1?ASP+NET+SignalR) or [StackOverflow.com](http://stackoverflow.com/).


## Overview

In this tutorial, you'll create a stock ticker application that is representative of real-time applications in which you want to periodically "push," or broadcast, notifications from the server to all connected clients. In the first part of this tutorial, you'll create a simplified version of that application from scratch. In the remainder of the tutorial, you'll install a NuGet package that contains additional features, and review the code for those features.

The application that you'll build in the first part of this tutorial displays a grid with stock data.

![StockTicker initial version](tutorial-server-broadcast-with-signalr/_static/image1.png)

Periodically the server randomly updates stock prices and pushes the updates to all connected clients. In the browser the numbers and symbols in the **Change** and **%** columns dynamically change in response to notifications from the server. If you open additional browsers to the same URL, they all show the same data and the same changes to the data simultaneously.

This tutorial contains the following sections:

- [Prerequisites](#prerequisites)
- [Create the project](#createproject)
- [Set up the server code](#server)
- [Set up the client code](#client)
- [Test the application](#test)
- [Enable logging](#enablelogging)
- [Install and review the full StockTicker sample](#fullsample)
- [Next steps](#nextsteps)

The [Microsoft.AspNet.SignalR.Sample](http://nuget.org/packages/microsoft.aspnet.signalr.sample) NuGet package installs a sample simulated stock ticker application in a Visual Studio project.

> [!NOTE] If you don't want to work through the steps of building the application, you can install the SignalR.Sample package in a new Empty ASP.NET Web Application project. If you install the NuGet package without performing the steps in this tutorial, **you must follow the instructions in the readme.txt file**. To run the package you need to add an OWIN startup class which calls the ConfigureSignalR method in the installed package. You will receive an error if you do not add the OWIN startup class.


<a id="prerequisites"></a>

## Prerequisites

Before you start, make sure that you have Visual Studio 2013 installed on your computer. If you don't have Visual Studio, see [ASP.NET Downloads](../../../downloads/index.md) to get the free Visual Studio 2013 Express.

<a id="createproject"></a>

## Create the project

1. From the **File** menu, click **New Project**.
2. In the **New Project** dialog box, expand **C#** under **Templates** and select **Web**.
3. Select the **ASP.NET Empty Web Application** template, name the project *SignalR.StockTicker*, and click **OK**.

    ![New Project dialog box](tutorial-server-broadcast-with-signalr/_static/image2.png)
4. In the **New ASP.NET** Project window, leave **Empty** selected and click **Create Project**.

    ![New ASP Project dialog box](tutorial-server-broadcast-with-signalr/_static/image3.png)

<a id="server"></a>

## Set up the server code

In this section you set up the code that runs on the server.

### Create the Stock class

You begin by creating the Stock model class that you'll use to store and transmit information about a stock.

1. Create a new class file in the project folder, name it *Stock.cs*, and then replace the template code with the following code:

        using System;
        
        namespace SignalR.StockTicker
        {
            public class Stock
            {
                private decimal _price;
        
                public string Symbol { get; set; }
        
                public decimal Price
                {
                    get
                    {
                        return _price;
                    }
                    set
                    {
                        if (_price == value)
                        {
                            return;
                        }
        
                        _price = value;
        
                        if (DayOpen == 0)
                        {
                            DayOpen = _price;
                        }
                    }
                }
        
                public decimal DayOpen { get; private set; }
        
                public decimal Change
                {
                    get
                    {
                        return Price - DayOpen;
                    }
                }
        
                public double PercentChange
                {
                    get
                    {
                        return (double)Math.Round(Change / Price, 4);
                    }
                }
            }
        }

    The two properties that you'll set when you create stocks are the Symbol (for example, MSFT for Microsoft) and the Price. The other properties depend on how and when you set Price. The first time you set Price, the value gets propagated to DayOpen. Subsequent times when you set Price, the Change and PercentChange property values are calculated based on the difference between Price and DayOpen.

### Create the StockTicker and StockTickerHub classes

You'll use the SignalR Hub API to handle server-to-client interaction. A StockTickerHub class that derives from the SignalR Hub class will handle receiving connections and method calls from clients. You also need to maintain stock data and run a Timer object to periodically trigger price updates, independently of client connections. You can't put these functions in a Hub class, because Hub instances are transient. A Hub class instance is created for each operation on the hub, such as connections and calls from the client to the server. So the mechanism that keeps stock data, updates prices, and broadcasts the price updates has to run in a separate class, which you'll name StockTicker.

![Broadcasting from StockTicker](tutorial-server-broadcast-with-signalr/_static/image5.png)

You only want one instance of the StockTicker class to run on the server, so you'll need to set up a reference from each StockTickerHub instance to the singleton StockTicker instance. The StockTicker class has to be able to broadcast to clients because it has the stock data and triggers updates, but StockTicker is not a Hub class. Therefore, the StockTicker class has to get a reference to the SignalR Hub connection context object. It can then use the SignalR connection context object to broadcast to clients.

1. In **Solution Explorer**, right-click the project and click **Add | SignalR Hub Class (v2)**.
2. Name the new hub *StockTickerHub.cs*, and then click **Add**. SignalR NuGet packages will be added to your project.
3. Replace the template code with the following code:

        using System.Collections.Generic;
        using Microsoft.AspNet.SignalR;
        using Microsoft.AspNet.SignalR.Hubs;
        
        namespace SignalR.StockTicker
        {
            [HubName("stockTickerMini")]
            public class StockTickerHub : Hub
            {
                private readonly StockTicker _stockTicker;
        
                public StockTickerHub() : this(StockTicker.Instance) { }
        
                public StockTickerHub(StockTicker stockTicker)
                {
                    _stockTicker = stockTicker;
                }
        
                public IEnumerable<Stock> GetAllStocks()
                {
                    return _stockTicker.GetAllStocks();
                }
            }
        }

    The [Hub](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.hub(v=vs.111).aspx) class is used to define methods the clients can call on the server. You are defining one method: `GetAllStocks()`. When a client initially connects to the server, it will call this method to get a list of all of the stocks with their current prices. The method can execute synchronously and return `IEnumerable<Stock>` because it is returning data from memory. If the method had to get the data by doing something that would involve waiting, such as a database lookup or a web service call, you would specify `Task<IEnumerable<Stock>>` as the return value to enable asynchronous processing. For more information, see [ASP.NET SignalR Hubs API Guide - Server - When to execute asynchronously](../guide-to-the-api/hubs-api-guide-server.md).

    The HubName attribute specifies how the Hub will be referenced in JavaScript code on the client. The default name on the client if you don't use this attribute is a camel-cased version of the class name, which in this case would be stockTickerHub.

    As you'll see later when you create the StockTicker class, a singleton instance of that class is created in its static Instance property. That singleton instance of StockTicker remains in memory no matter how many clients connect or disconnect, and that instance is what the GetAllStocks method uses to return current stock information.
4. Create a new class file in the project folder, name it *StockTicker.cs*, and then replace the template code with the following code:

        using System;
        using System.Collections.Concurrent;
        using System.Collections.Generic;
        using System.Threading;
        using Microsoft.AspNet.SignalR;
        using Microsoft.AspNet.SignalR.Hubs;
        
        namespace SignalR.StockTicker
        {
            public class StockTicker
            {
                // Singleton instance
                private readonly static Lazy<StockTicker> _instance = new Lazy<StockTicker>(() => new StockTicker(GlobalHost.ConnectionManager.GetHubContext<StockTickerHub>().Clients));
        
                private readonly ConcurrentDictionary<string, Stock> _stocks = new ConcurrentDictionary<string, Stock>();
        
                private readonly object _updateStockPricesLock = new object();
        
                //stock can go up or down by a percentage of this factor on each change
                private readonly double _rangePercent = .002;
        
                private readonly TimeSpan _updateInterval = TimeSpan.FromMilliseconds(250);
                private readonly Random _updateOrNotRandom = new Random();
        
                private readonly Timer _timer;
                private volatile bool _updatingStockPrices = false;
        
                private StockTicker(IHubConnectionContext<dynamic> clients)
                {
                    Clients = clients;
        
                    _stocks.Clear();
                    var stocks = new List<Stock>
                    {
                        new Stock { Symbol = "MSFT", Price = 30.31m },
                        new Stock { Symbol = "APPL", Price = 578.18m },
                        new Stock { Symbol = "GOOG", Price = 570.30m }
                    };
                    stocks.ForEach(stock => _stocks.TryAdd(stock.Symbol, stock));
        
                    _timer = new Timer(UpdateStockPrices, null, _updateInterval, _updateInterval);
        
                }
        
                public static StockTicker Instance
                {
                    get
                    {
                        return _instance.Value;
                    }
                }
        
                private IHubConnectionContext<dynamic> Clients
                {
                    get;
                    set;
                }
        
                public IEnumerable<Stock> GetAllStocks()
                {
                    return _stocks.Values;
                }
        
                private void UpdateStockPrices(object state)
                {
                    lock (_updateStockPricesLock)
                    {
                        if (!_updatingStockPrices)
                        {
                            _updatingStockPrices = true;
        
                            foreach (var stock in _stocks.Values)
                            {
                                if (TryUpdateStockPrice(stock))
                                {
                                    BroadcastStockPrice(stock);
                                }
                            }
        
                            _updatingStockPrices = false;
                        }
                    }
                }
        
                private bool TryUpdateStockPrice(Stock stock)
                {
                    // Randomly choose whether to update this stock or not
                    var r = _updateOrNotRandom.NextDouble();
                    if (r > .1)
                    {
                        return false;
                    }
        
                    // Update the stock price by a random factor of the range percent
                    var random = new Random((int)Math.Floor(stock.Price));
                    var percentChange = random.NextDouble() * _rangePercent;
                    var pos = random.NextDouble() > .51;
                    var change = Math.Round(stock.Price * (decimal)percentChange, 2);
                    change = pos ? change : -change;
        
                    stock.Price += change;
                    return true;
                }
        
                private void BroadcastStockPrice(Stock stock)
                {
                    Clients.All.updateStockPrice(stock);
                }
        
            }
        }

    Since multiple threads will be running the same instance of StockTicker code, the StockTicker class has to be threadsafe.

    ### Storing the singleton instance in a static field

    The code initializes the static \_instance field that backs the Instance property with an instance of the class, and this is the only instance of the class that can be created, because the constructor is marked as private. [Lazy initialization](https://msdn.microsoft.com/en-us/library/dd997286.aspx) is used for the \_instance field, not for performance reasons but to ensure that the instance creation is threadsafe.

        private readonly static Lazy<StockTicker> _instance = new Lazy<StockTicker>(() => new StockTicker(GlobalHost.ConnectionManager.GetHubContext<StockTickerHub>().Clients));
        
        public static StockTicker Instance
        {
            get
            {
                return _instance.Value;
            }
        }

    Each time a client connects to the server, a new instance of the StockTickerHub class running in a separate thread gets the StockTicker singleton instance from the StockTicker.Instance static property, as you saw earlier in the StockTickerHub class.

    ### Storing stock data in a ConcurrentDictionary

    The constructor initializes the \_stocks collection with some sample stock data, and GetAllStocks returns the stocks. As you saw earlier, this collection of stocks is in turn returned by StockTickerHub.GetAllStocks which is a server method in the Hub class that clients can call.

        private readonly ConcurrentDictionary<string, Stock> _stocks = new ConcurrentDictionary<string, Stock>();

        private StockTicker(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
        
            _stocks.Clear();
            var stocks = new List<Stock>
            {
                new Stock { Symbol = "MSFT", Price = 30.31m },
                new Stock { Symbol = "APPL", Price = 578.18m },
                new Stock { Symbol = "GOOG", Price = 570.30m }
            };
            stocks.ForEach(stock => _stocks.TryAdd(stock.Symbol, stock));
        
            _timer = new Timer(UpdateStockPrices, null, _updateInterval, _updateInterval);
        }
        
        public IEnumerable<Stock> GetAllStocks()
        {
            return _stocks.Values;
        }

    The stocks collection is defined as a [ConcurrentDictionary](https://msdn.microsoft.com/en-us/library/dd287191.aspx) type for thread safety. As an alternative, you could use a [Dictionary](https://msdn.microsoft.com/en-us/library/xfhwa508.aspx) object and explicitly lock the dictionary when you make changes to it.

    For this sample application, it's OK to store application data in memory and to lose the data when the StockTicker instance is disposed. In a real application you would work with a back-end data store such as a database.

    ### Periodically updating stock prices

    The constructor starts up a Timer object that periodically calls methods that update stock prices on a random basis.

        _timer = new Timer(UpdateStockPrices, null, _updateInterval, _updateInterval);
        
        private void UpdateStockPrices(object state)
        {
            lock (_updateStockPricesLock)
            {
                if (!_updatingStockPrices)
                {
                    _updatingStockPrices = true;
        
                    foreach (var stock in _stocks.Values)
                    {
                        if (TryUpdateStockPrice(stock))
                        {
                            BroadcastStockPrice(stock);
                        }
                    }
        
                    _updatingStockPrices = false;
                }
            }
        }
        
        private bool TryUpdateStockPrice(Stock stock)
        {
            // Randomly choose whether to update this stock or not
            var r = _updateOrNotRandom.NextDouble();
            if (r > .1)
            {
                return false;
            }
        
            // Update the stock price by a random factor of the range percent
            var random = new Random((int)Math.Floor(stock.Price));
            var percentChange = random.NextDouble() * _rangePercent;
            var pos = random.NextDouble() > .51;
            var change = Math.Round(stock.Price * (decimal)percentChange, 2);
            change = pos ? change : -change;
        
            stock.Price += change;
            return true;
        }

    UpdateStockPrices is called by the Timer, which passes in null in the state parameter. Before updating prices, a lock is taken on the \_updateStockPricesLock object. The code checks if another thread is already updating prices, and then it calls TryUpdateStockPrice on each stock in the list. The TryUpdateStockPrice method decides whether to change the stock price, and how much to change it. If the stock price is changed, BroadcastStockPrice is called to broadcast the stock price change to all connected clients.

    The \_updatingStockPrices flag is marked as [volatile](https://msdn.microsoft.com/en-us/library/x13ttww7.aspx) to ensure that access to it is threadsafe.

        private volatile bool _updatingStockPrices = false;

    In a real application, the TryUpdateStockPrice method would call a web service to look up the price; in this code it uses a random number generator to make changes randomly.

    ### Getting the SignalR context so that the StockTicker class can broadcast to clients

    Because the price changes originate here in the StockTicker object, this is the object that needs to call an updateStockPrice method on all connected clients. In a Hub class you have an API for calling client methods, but StockTicker does not derive from the Hub class and does not have a reference to any Hub object. Therefore, in order to broadcast to connected clients, the StockTicker class has to get the SignalR context instance for the StockTickerHub class and use that to call methods on clients.

    The code gets a reference to the SignalR context when it creates the singleton class instance, passes that reference to the constructor, and the constructor puts it in the Clients property.

    There are two reasons why you want to get the context just once: getting the context is an expensive operation, and getting it once ensures that the intended order of messages sent to clients is preserved.

        private readonly static Lazy<StockTicker> _instance =
            new Lazy<StockTicker>(() => new StockTicker(GlobalHost.ConnectionManager.GetHubContext<StockTickerHub>().Clients));
        
        private StockTicker(IHubConnectionContext<dynamic> clients)
        {
            Clients = clients;
        
            // Remainder of constructor ...
        }
        
        private IHubConnectionContext<dynamic> Clients
        {
            get;
            set;
        }
        
        private void BroadcastStockPrice(Stock stock)
        {
            Clients.All.updateStockPrice(stock);
        }

    Getting the Clients property of the context and putting it in the StockTickerClient property lets you write code to call client methods that looks the same as it would in a Hub class. For instance, to broadcast to all clients you can write Clients.All.updateStockPrice(stock).

    The updateStockPrice method that you are calling in BroadcastStockPrice doesn't exist yet; you'll add it later when you write code that runs on the client. You can refer to updateStockPrice here because Clients.All is dynamic, which means the expression will be evaluated at runtime. When this method call executes, SignalR will send the method name and the parameter value to the client, and if the client has a method named updateStockPrice, that method will be called and the parameter value will be passed to it.

    Clients.All means send to all clients. SignalR gives you other options to specify which clients or groups of clients to send to. For more information, see [HubConnectionContext](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.hubs.hubconnectioncontext(v=vs.111).aspx).

### Register the SignalR route

The server needs to know which URL to intercept and direct to SignalR. To do that you'll add and OWIN startup class.

1. In **Solution Explorer**, right-click the project, and then click **Add | OWIN Startup Class**. Name the class **Startup.cs**.
2. Replace the code in **Startup.cs** with the following.

        using System;
        using System.Threading.Tasks;
        using Microsoft.Owin;
        using Owin;
        
        [assembly: OwinStartup(typeof(SignalR.StockTicker.Startup))]
        
        namespace SignalR.StockTicker
        {
            public class Startup
            {
                public void Configuration(IAppBuilder app)
                {
                    // Any connection or hub wire up and configuration should go here
                    app.MapSignalR();
                }
        
            }
        }

You have now completed setting up the server code. In the next section you'll set up the client.

<a id="client"></a>

## Set up the client code

1. Create a new HTML file in the project folder, and name it *StockTicker.html*.
2. Replace the template code with the following code.

        <!DOCTYPE html>
        <html xmlns="http://www.w3.org/1999/xhtml">
        <head>
            <title>ASP.NET SignalR Stock Ticker</title>
            <style>
                body {
                    font-family: 'Segoe UI', Arial, Helvetica, sans-serif;
                    font-size: 16px;
                }
                #stockTable table {
                    border-collapse: collapse;
                }
                    #stockTable table th, #stockTable table td {
                        padding: 2px 6px;
                    }
                    #stockTable table td {
                        text-align: right;
                    }
                #stockTable .loading td {
                    text-align: left;
                }
            </style>
        </head>
        <body>
            <h1>ASP.NET SignalR Stock Ticker Sample</h1>
        
            <h2>Live Stock Table</h2>
            <div id="stockTable">
                <table border="1">
                    <thead>
                        <tr><th>Symbol</th><th>Price</th><th>Open</th><th>Change</th><th>%</th></tr>
                    </thead>
                    <tbody>
                        <tr class="loading"><td colspan="5">loading...</td></tr>
                    </tbody>
                </table>
            </div>
        
            <!--Script references. -->
            <!--Reference the jQuery library. -->
            <script src="/Scripts/jquery-1.10.2.min.js" ></script>
            <!--Reference the SignalR library. -->
            <script src="/Scripts/jquery.signalR-2.1.0.js"></script>
            <!--Reference the autogenerated SignalR hub script. -->
            <script src="/signalr/hubs"></script>
            <!--Reference the StockTicker script. -->
            <script src="StockTicker.js"></script>
        </body>
        </html>

    The HTML creates a table with 5 columns, a header row, and a data row with a single cell that spans all 5 columns. The data row displays "loading..." and will only be shown momentarily when the application starts. JavaScript code will remove that row and add in its place rows with stock data retrieved from the server.

    The script tags specify the jQuery script file, the SignalR core script file, the SignalR proxies script file, and a StockTicker script file that you'll create later. The SignalR proxies script file, which specifies the "/signalr/hubs" URL, is dynamically generated and defines proxy methods for the methods on the Hub class, in this case for StockTickerHub.GetAllStocks. If you prefer, you can generate this JavaScript file manually by using [SignalR Utilities](http://nuget.org/packages/Microsoft.AspNet.SignalR.Utils/) and disable dynamic file creation in the MapHubs method call.
3. > [!IMPORTANT] Make sure that the JavaScript file references in *StockTicker.html* are correct. That is, make sure that the jQuery version in your script tag (1.10.2 in the example) is the same as the jQuery version in your project's *Scripts* folder, and make sure that the SignalR version in your script tag is the same as the SignalR version in your project's *Scripts* folder. Change the file names in the script tags if necessary.
4. In **Solution Explorer**, right-click *StockTicker.html*, and then click **Set as Start Page**.
5. Create a new JavaScript file in the project folder and name it *StockTicker.js*..
6. Replace the template code with the following code:

        // A simple templating method for replacing placeholders enclosed in curly braces.
        if (!String.prototype.supplant) {
            String.prototype.supplant = function (o) {
                return this.replace(/{([^{}]*)}/g,
                    function (a, b) {
                        var r = o[b];
                        return typeof r === 'string' || typeof r === 'number' ? r : a;
                    }
                );
            };
        }
        
        $(function () {
        
            var ticker = $.connection.stockTickerMini, // the generated client-side hub proxy
                up = '▲',
                down = '▼',
                $stockTable = $('#stockTable'),
                $stockTableBody = $stockTable.find('tbody'),
                rowTemplate = '<tr data-symbol="{Symbol}"><td>{Symbol}</td><td>{Price}</td><td>{DayOpen}</td><td>{Direction} {Change}</td><td>{PercentChange}</td></tr>';
        
            function formatStock(stock) {
                return $.extend(stock, {
                    Price: stock.Price.toFixed(2),
                    PercentChange: (stock.PercentChange * 100).toFixed(2) + '%',
                    Direction: stock.Change === 0 ? '' : stock.Change >= 0 ? up : down
                });
            }
        
            function init() {
                ticker.server.getAllStocks().done(function (stocks) {
                    $stockTableBody.empty();
                    $.each(stocks, function () {
                        var stock = formatStock(this);
                        $stockTableBody.append(rowTemplate.supplant(stock));
                    });
                });
            }
        
            // Add a client-side hub method that the server will call
            ticker.client.updateStockPrice = function (stock) {
                var displayStock = formatStock(stock),
                    $row = $(rowTemplate.supplant(displayStock));
        
                $stockTableBody.find('tr[data-symbol=' + stock.Symbol + ']')
                    .replaceWith($row);
                }
        
            // Start the connection
            $.connection.hub.start().done(init);
        
        });

    $.connection refers to the SignalR proxies. The code gets a reference to the proxy for the StockTickerHub class and puts it in the ticker variable. The proxy name is the name that was set by the [HubName] attribute:

        var ticker = $.connection.stockTickerMini

        [HubName("stockTickerMini")]
        public class StockTickerHub : Hub

    After all the variables and functions are defined, the last line of code in the file initializes the SignalR connection by calling the SignalR start function. The start function executes asynchronously and returns a [jQuery Deferred object](http://api.jquery.com/category/deferred-object/), which means you can call the done function to specify the function to call when the asynchronous operation is completed..

        $.connection.hub.start().done(init);

    The init function calls the getAllStocks function on the server and uses the information that the server returns to update the stock table. Notice that by default, you have to use camel casing on the client although the method name is pascal-cased on the server. The camel-casing rule only applies to methods, not objects. For example, you refer to stock.Symbol and stock.Price, not stock.symbol or stock.price.

        function init() {
            ticker.server.getAllStocks().done(function (stocks) {
                $stockTableBody.empty();
                $.each(stocks, function () {
                    var stock = formatStock(this);
                    $stockTableBody.append(rowTemplate.supplant(stock));
                });
            });
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            return _stockTicker.GetAllStocks();
        }

    If you wanted to use pascal casing on the client, or if you wanted to use a completely different method name, you could decorate the Hub method with the HubMethodName attribute the same way you decorated the Hub class itself with the HubName attribute.

    In the init method, HTML for a table row is created for each stock object received from the server by calling formatStock to format properties of the stock object, and then by calling supplant (which is defined at the top of *StockTicker.js*) to replace placeholders in the rowTemplate variable with the stock object property values. The resulting HTML is then appended to the stock table.

    You call init by passing it in as a callback function that executes after the asynchronous start function completes. If you called init as a separate JavaScript statement after calling start, the function would fail because it would execute immediately without waiting for the start function to finish establishing the connection. In that case, the init function would try to call the getAllStocks function before the server connection is established.

    When the server changes a stock's price, it calls the updateStockPrice on connected clients. The function is added to the client property of the stockTicker proxy in order to make it available to calls from the server.

        ticker.client.updateStockPrice = function (stock) {
            var displayStock = formatStock(stock),
                $row = $(rowTemplate.supplant(displayStock));
        
            $stockTableBody.find('tr[data-symbol=' + stock.Symbol + ']')
                .replaceWith($row);
            }

    The updateStockPrice function formats a stock object received from the server into a table row the same way as in the init function. However, instead of appending the row to the table, it finds the stock's current row in the table and replaces that row with the new one.

<a id="test"></a>

## Test the application

1. Press F5 to run the application in debug mode.

    The stock table initially displays the "loading..." line, then after a short delay the initial stock data is displayed, and then the stock prices start to change.

    ![Loading](tutorial-server-broadcast-with-signalr/_static/image6.png)

    ![Initial stock table](tutorial-server-broadcast-with-signalr/_static/image7.png)

    ![Stock table receiving changes from server](tutorial-server-broadcast-with-signalr/_static/image8.png)
2. Copy the URL from the browser address bar and paste it into one or more new browser window(s).

    The initial stock display is the same as the first browser and changes happen simultaneously.
3. Close all browsers and open a new browser, then go to the same URL.

    The StockTicker singleton object has continued to run in the server, so the stock table display shows that the stocks have continued to change. (You don't see the initial table with zero change figures.)
4. Close the browser.

<a id="enablelogging"></a>

## Enable logging

SignalR has a built-in logging function that you can enable on the client to aid in troubleshooting. In this section you enable logging and see examples that show how logs tell you which of the following transport methods SignalR is using:

- [WebSockets](http://en.wikipedia.org/wiki/WebSocket), supported by IIS 8 and current browsers.
- [Server-sent events](http://en.wikipedia.org/wiki/Server-sent_events), supported by browsers other than Internet Explorer.
- [Forever frame](http://en.wikipedia.org/wiki/Comet_(programming)#Hidden_iframe), supported by Internet Explorer.
- [Ajax long polling](http://en.wikipedia.org/wiki/Comet_(programming)#Ajax_with_long_polling), supported by all browsers.

For any given connection, SignalR chooses the best transport method that both the server and the client support.

1. Open *StockTicker.js* and add a line of code to enable logging immediately before the code that initializes the connection at the end of the file:

        // Start the connection
        $.connection.hub.logging = true;
        $.connection.hub.start().done(init);
2. Press F5 to run the project.
3. Open your browser's developer tools window, and select the Console to see the logs. You might have to refresh the page to see the logs of Signalr negotiating the transport method for a new connection.

    If you are running Internet Explorer 10 on Windows 8 (IIS 8), the transport method is WebSockets.

    ![IE 10 IIS 8 Console](tutorial-server-broadcast-with-signalr/_static/image9.png)

    If you are running Internet Explorer 10 on Windows 7 (IIS 7.5), the transport method is iframe.

    ![IE 10 Console, IIS 7.5](tutorial-server-broadcast-with-signalr/_static/image10.png)

    In Firefox, install the Firebug add-in to get a Console window. If you are running Firefox 19 on Windows 8 (IIS 8), the transport method is WebSockets.

    ![Firefox 19 IIS 8 Websockets](tutorial-server-broadcast-with-signalr/_static/image11.png)

    If you are running Firefox 19 on Windows 7 (IIS 7.5), the transport method is server-sent events.

    ![Firefox 19 IIS 7.5 Console](tutorial-server-broadcast-with-signalr/_static/image12.png)

<a id="fullsample"></a>

## Install and review the full StockTicker sample

The StockTicker application that is installed by the [Microsoft.AspNet.SignalR.Sample](http://nuget.org/packages/microsoft.aspnet.signalr.sample) NuGet package includes more features than the simplified version that you just created from scratch. In this section of the tutorial, you install the NuGet package and review the new features and the code that implements them. If you install the package without performing the earlier steps of this tutorial, you must add an OWIN startup class to your project. This step is explained in the readme.txt file for the NuGet package.

### Install the SignalR.Sample NuGet package

1. In **Solution Explorer**, right-click the project and click **Manage NuGet Packages**.
2. In the **Manage NuGet Packages** dialog box, click **Online**, enter *SignalR.Sample* in the **Search Online** box, and then click **Install** in the **SignalR.Sample** package.

    ![Install SignalR.Sample package](tutorial-server-broadcast-with-signalr/_static/image13.png)
3. In **Solution Explorer**, expand the *SignalR.Sample* folder which was created by installing the SignalR.Sample package.
4. In the *SignalR.Sample* folder, right-click *StockTicker.html*, and then click **Set As Start Page**.

    > [!NOTE] Installing The SignalR.Sample NuGet package might change the version of jQuery that you have in your *Scripts* folder. The new *StockTicker.html* file that the package installs in the *SignalR.Sample* folder will be in sync with the jQuery version that the package installs, but if you want to run your original *StockTicker.html* file again, you might have to update the jQuery reference in the script tag first.

### Run the application

1. Press F5 to run the application.

    In addition to the grid that you saw earlier, the full stock ticker application shows a horizontally scrolling window that displays the same stock data. When you run the application for the first time, the "market" is "closed" and you see a static grid and a ticker window that isn't scrolling.

    ![StockTicker screen start](tutorial-server-broadcast-with-signalr/_static/image14.png)

    When you click **Open Market**, the **Live Stock Ticker** box starts to scroll horizontally, and the server starts to periodically broadcast stock price changes on a random basis. Each time a stock price changes, both the **Live Stock Table** grid and the **Live Stock Ticker** box are updated. When a stock's price change is positive, the stock is shown with a green background, and when the change is negative, the stock is shown with a red background.

    ![StockTicker app, market open](tutorial-server-broadcast-with-signalr/_static/image15.png)

    The **Close Market** button stops the changes and stops the ticker scrolling, and the **Reset** button resets all stock data to the initial state before price changes started. If you open more browser windows and go to the same URL, you see the same data dynamically updated at the same time in each browser. When you click one of the buttons, all browsers respond the same way at the same time.

### Live Stock Ticker display

The **Live Stock Ticker** display is an unordered list in a div element that is formatted into a single line by CSS styles. The ticker is initialized and updated the same way as the table: by replacing placeholders in a &lt;li&gt; template string and dynamically adding the &lt;li&gt; elements to the &lt;ul&gt; element. The scrolling is performed by using the jQuery animate function to vary the margin-left of the unordered list within the div.

The stock ticker HTML:

    <h2>Live Stock Ticker</h2>
    <div id="stockTicker">
        <div class="inner">
            <ul>
                <li class="loading">loading...</li>
            </ul>
        </div>
    </div>

The stock ticker CSS:

    #stockTicker {
        overflow: hidden;
        width: 450px;
        height: 24px;
        border: 1px solid #999;
        }
    
        #stockTicker .inner {
            width: 9999px;
        }
    
        #stockTicker ul {
            display: inline-block;
            list-style-type: none;
            margin: 0;
            padding: 0;
        }
    
        #stockTicker li {
            display: inline-block;
            margin-right: 8px;   
        }
    
        /*<li data-symbol="{Symbol}"><span class="symbol">{Symbol}</span><span class="price">{Price}</span><span class="change">{PercentChange}</span></li>*/
        #stockTicker .symbol {
            font-weight: bold;
        }
    
        #stockTicker .change {
            font-style: italic;
        }

The jQuery code that makes it scroll:

    function scrollTicker() {
        var w = $stockTickerUl.width();
        $stockTickerUl.css({ marginLeft: w });
        $stockTickerUl.animate({ marginLeft: -w }, 15000, 'linear', scrollTicker);
    }

### Additional methods on the server that the client can call

The StockTickerHub class defines four additional methods that the client can call:

    public string GetMarketState()
    {
        return _stockTicker.MarketState.ToString();
    }
    
    public void OpenMarket()
    {
        _stockTicker.OpenMarket();
    }
    
    public void CloseMarket()
    {
        _stockTicker.CloseMarket();
    }
    
    public void Reset()
    {
        _stockTicker.Reset();
    }

OpenMarket, CloseMarket, and Reset are called in response to the buttons at the top of the page. They demonstrate the pattern of one client triggering a change in state that is immediately propagated to all clients. Each of these methods calls a method in the StockTicker class that effects the market state change and then broadcasts the new state.

In the StockTicker class, the state of the market is maintained by a MarketState property that returns a MarketState enum value:

    public MarketState MarketState
    {
        get { return _marketState; }
        private set { _marketState = value; }
    }
    
    public enum MarketState
    {
        Closed,
        Open
    }

Each of the methods that change the market state do so inside a lock block because the StockTicker class has to be threadsafe:

    public void OpenMarket()
    {
        lock (_marketStateLock)
        {
            if (MarketState != MarketState.Open)
            {
                _timer = new Timer(UpdateStockPrices, null, _updateInterval, _updateInterval);
                MarketState = MarketState.Open;
                BroadcastMarketStateChange(MarketState.Open);
            }
        }
    }
    
    public void CloseMarket()
    {
        lock (_marketStateLock)
        {
            if (MarketState == MarketState.Open)
            {
                if (_timer != null)
                {
                    _timer.Dispose();
                }
                MarketState = MarketState.Closed;
                BroadcastMarketStateChange(MarketState.Closed);
            }
        }
    }
    
    public void Reset()
    {
        lock (_marketStateLock)
        {
            if (MarketState != MarketState.Closed)
            {
                throw new InvalidOperationException("Market must be closed before it can be reset.");
            }
            LoadDefaultStocks();
            BroadcastMarketReset();
        }
    }

To ensure that this code is threadsafe, the \_marketState field that backs the MarketState property is marked as volatile,

    private volatile MarketState _marketState;

The BroadcastMarketStateChange and BroadcastMarketReset methods are similar to the BroadcastStockPrice method that you already saw, except they call different methods defined at the client:

    private void BroadcastMarketStateChange(MarketState marketState)
    {
        switch (marketState)
        {
            case MarketState.Open:
                Clients.All.marketOpened();
                break;
            case MarketState.Closed:
                Clients.All.marketClosed();
                break;
            default:
                break;
        }
    }
    
    private void BroadcastMarketReset()
    {
        Clients.All.marketReset();
    }

### Additional functions on the client that the server can call

The updateStockPrice function now handles both the grid and the ticker display, and it uses jQuery.Color to flash red and green colors.

New functions in *SignalR.StockTicker.js* enable and disable the buttons based on market state, and they stop or start the ticker window horizontal scrolling. Since multiple functions are being added to ticker.client, the [jQuery extend function](http://api.jquery.com/jQuery.extend/) is used to add them.

    $.extend(ticker.client, {
        updateStockPrice: function (stock) {
            var displayStock = formatStock(stock),
                $row = $(rowTemplate.supplant(displayStock)),
                $li = $(liTemplate.supplant(displayStock)),
                bg = stock.LastChange === 0
                    ? '255,216,0' // yellow
                    : stock.LastChange > 0
                        ? '154,240,117' // green
                        : '255,148,148'; // red
    
            $stockTableBody.find('tr[data-symbol=' + stock.Symbol + ']')
                .replaceWith($row);
            $stockTickerUl.find('li[data-symbol=' + stock.Symbol + ']')
                .replaceWith($li);
    
            $row.flash(bg, 1000);
            $li.flash(bg, 1000);
        },
    
        marketOpened: function () {
            $("#open").prop("disabled", true);
            $("#close").prop("disabled", false);
            $("#reset").prop("disabled", true);
            scrollTicker();
        },
    
        marketClosed: function () {
            $("#open").prop("disabled", false);
            $("#close").prop("disabled", true);
            $("#reset").prop("disabled", false);
            stopTicker();
        },
    
        marketReset: function () {
            return init();
        }
    });

### Additional client setup after establishing the connection

After the client establishes the connection, it has some additional work to do: find out if the market is open or closed in order to call the appropriate marketOpened or marketClosed function, and attach the server method calls to the buttons.

    $.connection.hub.start()
        .pipe(init)
        .pipe(function () {
            return ticker.server.getMarketState();
        })
        .done(function (state) {
            if (state === 'Open') {
                ticker.client.marketOpened();
            } else {
                ticker.client.marketClosed();
            }
    
            // Wire up the buttons
            $("#open").click(function () {
                ticker.server.openMarket();
            });
    
            $("#close").click(function () {
                ticker.server.closeMarket();
            });
    
            $("#reset").click(function () {
                ticker.server.reset();
            });
        });

The server methods are not wired up to the buttons until after the connection is established, so that the code can't try to call the server methods before they are available.

<a id="nextsteps"></a>

## Next steps

In this tutorial you've learned how to program a SignalR application that broadcasts messages from the server to all connected clients, both on a periodic basis and in response to notifications from any client. The pattern of using a multi-threaded singleton instance to maintain server state can also be also used in multi-player online game scenarios. For an example, see [the ShootR game that is based on SignalR](https://github.com/NTaylorMullen/ShootR).

For tutorials that show peer-to-peer communication scenarios, see [Getting Started with SignalR](introduction-to-signalr.md) and [Real-Time Updating with SignalR](tutorial-high-frequency-realtime-with-signalr.md).

To learn more advanced SignalR development concepts, visit the following sites for SignalR source code and resources:

- [ASP.NET SignalR](../../index.md)
- [SignalR Project](http://signalr.net/)
- [SignalR Github and Samples](https://github.com/SignalR/SignalR)
- [SignalR Wiki](https://github.com/SignalR/SignalR/wiki)

For a walkthrough on how to deploy a SignalR application to Azure, see [Using SignalR with Web Apps in Azure App Service](../deployment/using-signalr-with-azure-web-sites.md). For detailed information about how to deploy a Visual Studio web project to a Windows Azure Web Site, see [Create an ASP.NET web app in Azure App Service](https://azure.microsoft.com/en-us/documentation/articles/web-sites-dotnet-get-started/).