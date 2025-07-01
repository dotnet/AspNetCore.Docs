---
title: Push notifications for ASP.NET Core Blazor Progressive Web Applications (PWAs)
author: guardrex
description: Learn how to issue push notifications in Blazor Progressive Web Applications (PWAs).
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 07/01/2025
uid: blazor/progressive-web-app/push-notifications
---
# Push notifications for ASP.NET Core Blazor Progressive Web Applications (PWAs)

[!INCLUDE[](~/includes/not-latest-version.md)]

Blazor PWAs can receive and display *push notifications* from a backend server, even when the user isn't actively using the app. For example, push notifications can be sent when a different user performs an action in their installed PWA or when the app or users interacting directly with the backend server app perform an action.

Use push notifications to:

 * Notify users that something important has happened, prompting them to return to the app.
 * Update data stored in the app, such as a news feed, so the user has fresh data on their next return, even if they're offline at the time.

The example in this article uses push notifications to provide status updates to app users.

The mechanism for sending a push notification is entirely independent of Blazor WebAssembly, since it's implemented by the backend server which can use any technology.

The approaches demonstrated in this article send push notifications from an ASP.NET Core server to the [Blazing Pizza Workshop PWA demonstration app](https://github.com/dotnet-presentations/blazor-workshop).

The mechanism for receiving and displaying a push notification on the client is also independent of Blazor WebAssembly, since it's implemented in the service worker JavaScript file. This article covers the concepts with examples in the [Display notifications](#display-notifications) section.

## Public and private keys

Generate the cryptographic public and private keys either locally or using an online tool. Update the `someone@example.com` address in the C# code to match the address used when creating the custom key pair.

Placeholders used in this article's example code:

* `{PUBLIC KEY}`: The public key.
* `{PRIVATE KEY}`: The private key.

## Create a subscription

Before sending push notifications to a user, the app must ask the user for permission. If they agree, their browser generates a *subscription*, which is a set of tokens the app can use to route notifications to the user.

Permission can be obtained at any time by the app, but for the best chance of success, we recommend asking users only when it's clear why they would want to subscribe. You might want to implement a **Send me updates** button. For simplicity, the following example asks users when they arrive on the checkout page, since at that point where it's clear that the user is serious about placing an order.

Add a push notifications JavaScript file to request a subscription. In the Blazing Pizza app, the file is named `pushNotifications.js` and located in the public static assets folder (`wwwroot`) of the solution's Razor class library project (`BlazingPizza.ComponentsLibrary`).

`BlazingPizza.ComponentsLibrary/wwwroot/pushNotifications.js`:

```javascript
(function () {
    const applicationServerPublicKey = '{PUBLIC KEY}';

    window.blazorPushNotifications = {
        requestSubscription: async () => {
            const worker = await navigator.serviceWorker.getRegistration();
            const existingSubscription = await worker.pushManager.getSubscription();
            if (!existingSubscription) {
                const newSubscription = await subscribe(worker);
                if (newSubscription) {
                    return {
                        url: newSubscription.endpoint,
                        p256dh: arrayBufferToBase64(newSubscription.getKey('p256dh')),
                        auth: arrayBufferToBase64(newSubscription.getKey('auth'))
                    };
                }
            }
        }
    };

    async function subscribe(worker) {
        try {
            return await worker.pushManager.subscribe({
                userVisibleOnly: true,
                applicationServerKey: applicationServerPublicKey
            });
        } catch (error) {
            if (error.name === 'NotAllowedError') {
                return null;
            }
            throw error;
        }
    }

    function arrayBufferToBase64(buffer) {
        // https://stackoverflow.com/a/9458996
        var binary = '';
        var bytes = new Uint8Array(buffer);
        var len = bytes.byteLength;
        for (var i = 0; i < len; i++) {
            binary += String.fromCharCode(bytes[i]);
        }
        return window.btoa(binary);
    }
})();
```

Inject the <xref:Microsoft.JSInterop.IJSRuntime> service into the `Checkout` component (`BlazingPizza.Client/Components/Pages/Checkout.razor`).

```razor
@inject IJSRuntime JSRuntime
```

Define a `RequestNotificationSubscriptionAsync` method to request a subscription and subscribe to notifications if the subscription is established.

In the `@code` block of the `Checkout` component:

```csharp
private async Task RequestNotificationSubscriptionAsync()
{
    var subscription = await JSRuntime.InvokeAsync<NotificationSubscription>(
        "blazorPushNotifications.requestSubscription");

    if (subscription is not null)
    {
        try
        {
            await OrdersClient.SubscribeToNotifications(subscription);
        }
        catch (AccessTokenNotAvailableException ex)
        {
            ex.Redirect();
        }
    }
}
```

The `SubscribeToNotifications` method is in the HTTP repository implementation (`BlazingPizza.Client/HttpRepository.cs`):

```csharp
public async Task SubscribeToNotifications(NotificationSubscription subscription)
{
    var response = await httpClient.PutAsJsonAsync("notifications/subscribe", 
        subscription);
    response.EnsureSuccessStatusCode();
}
```

In the `Checkout` component, `RequestNotificationSubscriptionAsync` is called in the `OnInitialized` lifecycle method and executes on component initialization:

```csharp
protected override void OnInitialized()
{
    _ = RequestNotificationSubscriptionAsync();
}
```

The `RequestNotificationSubscriptionAsync` code invokes a JavaScript function that's found in `BlazingPizza.ComponentsLibrary/wwwroot/pushNotifications.js`. The JavaScript code calls the `pushManager.subscribe` API and returns the results to .NET.

If the user agrees to receive notifications, this code sends the data to the server where the tokens are stored in the database for later use.

To demonstrate how the code works, run the app and start placing an order. Go to the checkout screen to see the subscription request:

![The Blazing Pizza app requests permission from the user to show notifications.](~/blazor/progressive-web-app/push-notifications/_static/image1.png)

Choose **Allow** and check in the browser developer tools console for errors. A breakpoint on the server in `PizzaApiExtensions`'s `MapPut("/notifications/subscribe"...)` API method with the app run with debugging allows inspection of the incoming data from the browser, which includes an endpoint URL and cryptographic tokens.

Once the user has either allowed or blocked notifications for a given site, the browser won't ask again. To reset the permission for further testing for either Google Chrome or Microsoft Edge, select the "information" icon (&#x1F6C8;) to the left of the browser's address bar and change **Notifications** back to **Ask (default)** as seen in the following image:

![Selecting "Ask (default)" for "Notifications" from this app to reset notifications back to a disabled state.](~/blazor/progressive-web-app/push-notifications/_static/image2.png)

## Send a notification

Sending notifications involves performing some complex cryptographic operations on the server to protect the data in transit. Thankfully, the bulk of the complexity is handled for the app by a third-party NuGet package, [`WebPush`](https://www.nuget.org/packages/WebPush), used by the server project (`BlazingPizza.Server`).

The `SendNotificationAsync` method dispatches order notifications using the captured subscription. The following code makes uses of `WebPush` APIs for dispatching the notification:

```csharp
private static async Task SendNotificationAsync(Order order, 
    NotificationSubscription subscription, string message)
{
    var publicKey = "{PUBLIC KEY}";
    var privateKey = "{PRIVATE KEY}";

    var pushSubscription = new PushSubscription(subscription.Url, 
        subscription.P256dh, subscription.Auth);
    var vapidDetails = new VapidDetails("mailto:<someone@example.com>", publicKey, 
        privateKey);
    var webPushClient = new WebPushClient();

    try
    {
        var payload = JsonSerializer.Serialize(new
        {
            message,
            url = $"myorders/{order.OrderId}",
        });

        await webPushClient.SendNotificationAsync(pushSubscription, payload, 
            vapidDetails);
    }
    catch (Exception ex)
    {
        Console.Error.WriteLine($"Error sending push notification: {ex.Message}");
    }
}
```

Thus far, the server is capable of sending notifications, but the browser doesn't display them. That's because the service worker doesn't handle incoming notifications at this point. Even before the app is capable of displaying notifications, which are covered in the [Display notifications](#display-notifications) section, the browser's developer tools console indicates the arrival of notifications ten seconds after orders are placed. On the **Application** tab, open the **Push Messaging** section. Select the the circle to **Start recording**.

![Browser developer tools console on the "Application" tab with "Push Messaging" open showing three pushed notifications to the app with their timestamps.](~/blazor/progressive-web-app/push-notifications/_static/image3.png)

## Display notifications

The PWA's service worker (`service-worker.js`) must handle pushed notifications in order for the app to display them. The following event handler function is in the Blazing Pizza app.

In `BlazingPizza/wwwroot/service-worker.js`:

```javascript
self.addEventListener('push', event => {
  const payload = event.data.json();
  event.waitUntil(
    self.registration.showNotification('Blazing Pizza', {
      body: payload.message,
      icon: 'img/icon-512.png',
      vibrate: [100, 50, 100],
      data: { url: payload.url }
    });
  );
});
```

The preceding code doesn't take effect until after the next page load when the browser logs `Installing service worker...`. When struggling to get the service worker to update, use the dev tools **Application** tab. Under **Service Workers**, choose **Update** (or use **Unregister** to force a new registration on the next load).

With the preceding code in place and new order placed by a user, the order moves into *Out for delivery* status after 10 seconds per the app's built-in demonstration logic and the browser receives a push notification:

![A pop-up notification indicating to the user that their pizza order has been dispatched.](~/blazor/progressive-web-app/push-notifications/_static/image4.png)

When using either Google Chrome or the latest Microsoft Edge browser, the notification appears even if the user isn't on the Blazing Pizza app, but only if the browser is running (or the next time the browser is opened). When using the installed PWA, the notification should be delivered even if the user isn't running the app.

## Handle clicks on notifications

Handle clicks on notifications by registering an event listener for `notificationclick`. The following example in the Blazing Pizza app takes the user to the order status page for whichever order pertains to the notification. The URL is provided by the `event.notification.data.url` parameter, which is sent by server-side code with the notification.

In the service worker file (`service-worker.js`):

```javascript
self.addEventListener('notificationclick', event => {
  event.notification.close();
  event.waitUntil(clients.openWindow(event.notification.data.url));
});
```

If the PWA is installed on the device, the PWA is shown on the device. If the PWA isn't installed, the user is taken to the app's page in their browser.
