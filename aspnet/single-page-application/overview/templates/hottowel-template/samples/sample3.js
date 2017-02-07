define(['durandal/app', 
        'durandal/viewLocator', 
        'durandal/system', 
        'durandal/plugins/router'],
    function (app, viewLocator, system, router) {

    // Enable debug message to show in the console 
    system.debug(true);

    app.start().then(function () {
        router.useConvention();
        viewLocator.useConvention();
        //Show the app by setting the root view model for our application.
        app.setRoot('viewmodels/shell', 'entrance');
    });
});