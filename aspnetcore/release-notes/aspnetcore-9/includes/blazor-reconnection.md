### Improved Blazor Server reconnection experience:

The following enhancements have been made to the default Blazor Server reconnection experience:

* Reconnect timing now uses an exponential backoff strategy. The first several reconnection attempts happen in rapid succession, and then a delay gradually gets introduced between attempts.

  This behavior can be customized by specifying a function to compute the retry interval. For example:

  ```js
  Blazor.start({
    circuit: {
      reconnectionOptions: {
        retryIntervalMilliseconds: (previousAttempts, maxRetries) => previousAttempts >= maxRetries ? null : previousAttempts * 1000,
      },
    },
  });
  ```

* A reconnect attempt is immediate when the user navigates back to an app with a disconnected circuit. In this case, the automatic retry interval is ignored. This behavior especially improves the user experience when navigating to an app in a browser tab that has gone to sleep.

* If a reconnection attempt reaches the server, but reconnection fails because the server had already released the circuit, a refresh occurs automatically. A manual refresh isn't needed if successful reconnection is likely.

* The styling of the default reconnect UI has been modernized.
