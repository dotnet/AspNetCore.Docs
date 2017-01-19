// Method added to proxy in JavaScript:
myHubProxy.server.method1 = function (param1, param2) {...};
//Multiple methods added to proxy in JavaScript using jQuery:
$.extend(myHubProxy.server, {
    method1: function (param1, param2) {...},
    method2: function (param3, param4) {...}
});