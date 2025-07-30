---
title: Push notifications for ASP.NET Core Blazor Progressive Web Applications (PWAs)
ai-usage: ai-assisted
author: guardrex
description: Learn how to issue push notifications in Blazor Progressive Web Applications (PWAs).
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 07/30/2025
uid: blazor/progressive-web-app/push-notifications
---
# Push notifications for ASP.NET Core Blazor Progressive Web Applications (PWAs)

[!INCLUDE[](~/includes/not-latest-version.md)]

Blazor PWAs can receive and display *push notifications* (data messages) from a backend server, even when the user isn't actively using the app. For example, push notifications can be sent when a different user performs an action in their installed PWA or when the app or users interacting directly with the backend server app perform an action.

Use push notifications to:

* Notify users that something important has happened, prompting them to return to the app.
* Update data stored in the app, such as a news feed, so the user has fresh data on their next return to the app, even if they're offline when the push notification is issued.

The mechanisms for sending, receiving, and displaying a push notification are independent of Blazor WebAssembly. Sending a push notification is implemented by the backend server, which can use any technology. Receiving and displaying a push notification on the client is implemented in the service worker JavaScript (JS) file.

The example in this article uses push notifications to provide order status updates to the customers of a pizza restaurant based on the [Blazing Pizza Workshop PWA demonstration app](https://github.com/dotnet-presentations/blazor-workshop). You aren't required to participate in the online workshop to use this article, but the workshop is a helpful introduction to Blazor PWA development.

> [!NOTE]
> The Blazing Pizza app adopts the *repository pattern* to create an abstraction layer between the UI layer and the data access layer. For more information, see [Unit of Work (UoW) pattern](https://martinfowler.com/eaaCatalog/unitOfWork.html) and [Designing the infrastructure persistence layer](/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design).

## Establish public and private keys

Generate the cryptographic public and private keys for securing push notifications either locally, for example with PowerShell or IIS, or using an online tool. 

Placeholders used in this article's example code:

* `{PUBLIC KEY}`: The public key.
* `{PRIVATE KEY}`: The private key.

For this article's C# examples, update the `someone@example.com` email address to match the address used when creating the custom key pair.

When implementing push notifications, ensure that cryptographic keys are managed securely:

* **Key generation**: Use a trusted library or tool to generate the public and private keys. Avoid using weak or outdated algorithms.
* **Key storage**: Store private keys securely on the server, using a secure storage mechanism such as a hardware security module (HSM) or encrypted storage. Never expose private keys to the client.
* **Key usage**: Use the private key only for signing push notification payloads. Ensure that the public key is distributed securely to clients.

For more information on cryptographic best practices, see [Cryptographic Services](/dotnet/standard/security/cryptographic-services).

## Create a subscription

Before sending push notifications to a user, the app must ask the user for permission. If they grant permission to receive notifications, their browser generates a *subscription*, which includes a set of tokens the app can use to route notifications to the user.

Permission can be obtained at any time by the app, but we only recommend asking users for permission when it's clear why they would want to subscribe for notifications from the app. The following example asks users when they arrive on the checkout page (`Checkout` component) because at that point it's clear that the user is serious about placing an order.

If the user agrees to receive notifications, the following example sends the push notification subscription data to the server, where push notification tokens are stored in the database for later use.

Add a push notifications JS file to request a subscription:

* Call [`navigator.serviceWorker.getRegistration`](https://developer.mozilla.org/docs/Web/API/ServiceWorkerContainer/getRegistration) to get the service worker's registration.
* Call [`worker.pushManager.getSubscription`](https://developer.mozilla.org/docs/Web/API/PushManager/getSubscription) to determine if a subscription exists.
* If a subscription doesn't exist, create a new subscription using the [`PushManager.subscribe`](https://developer.mozilla.org/docs/Web/API/PushManager/subscribe) function and return the new subscription's URL and tokens.

In the Blazing Pizza app, the JS file is named `pushNotifications.js` and located in the public static assets folder (`wwwroot`) of the solution's Razor class library project (`BlazingPizza.ComponentsLibrary`). The `blazorPushNotifications.requestSubscription` function requests a subscription.

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

> [!NOTE]
> For more information on the preceding `arrayBufferToBase64` function, see [How can I convert an ArrayBuffer to a base64-encoded string? (Stack Overflow)](https://stackoverflow.com/a/9458996).

A subscription object and notification subscription endpoint is created on the server. The endpoint receives client web API calls with push notification subscription data, including cryptographic tokens. The data is stored in the database for each app user.

In the Blazing Pizza app, the subscription object is the `NotificationSubscription` class. The `P256dh` and `Auth` properties are the user's cryptographic tokens.

`BlazingPizza.Shared/NotificationSubscription.cs`:

```csharp
public class NotificationSubscription
{
    public int? NotificationSubscriptionId { get; set; }

    public string? UserId { get; set; }

    public string? Url { get; set; }

    public string? P256dh { get; set; }

    public string? Auth { get; set; }
}
```

The `notifications/subscribe` endpoint is defined in the app's `MapPizzaApi` extension method, which is called in the app's `Program` file to set up web API endpoints for the app. The user's notification subscription (`NotificationSubscription`), which includes their push notification tokens, is stored in the database. Only one subscription per user is stored. Alternatively, you could allow the user register multiple subscriptions from different browsers or devices.

```csharp
app.MapPut("/notifications/subscribe", 
    [Authorize] async (
    HttpContext context,
    PizzaStoreContext db,
    NotificationSubscription subscription) => 
    {
        var userId = GetUserId(context);

        if (userId is null)
        {
            return Results.Unauthorized();
        }

        // Remove old subscriptions for this user
        var oldSubscriptions = db.NotificationSubscriptions.Where(
            e => e.UserId == userId);
        db.NotificationSubscriptions.RemoveRange(oldSubscriptions);

        // Store the new subscription
        subscription.UserId = userId;
        db.NotificationSubscriptions.Add(subscription);

        await db.SaveChangesAsync();

        return Results.Ok(subscription);
    });
```

In `BlazingPizza.Client/HttpRepository.cs`, the `SubscribeToNotifications` method issues an HTTP PUT to the subscriptions endpoint on the server:

```csharp
public class HttpRepository : IRepository
{

	private readonly HttpClient _httpClient;

	public HttpRepository(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

    ...

    public async Task SubscribeToNotifications(NotificationSubscription subscription)
	    {
		    var response = await _httpClient.PutAsJsonAsync("notifications/subscribe", 
                subscription);
		    response.EnsureSuccessStatusCode();
	}
}
```

The repository interface (`BlazingPizza.Shared/IRepository.cs`) includes the method signature of `SubscribeToNotifications`:

```csharp
public interface IRepository
{
    ...

	Task SubscribeToNotifications(NotificationSubscription subscription);
}
```

Define a method to request a subscription and subscribe to notifications if the subscription is established. Save the subscription in the database for later use.

In the `Checkout` component of the Blazing Pizza app, the `RequestNotificationSubscriptionAsync` method performs the following duties:

* The subscription is created via JS interop by calling `blazorPushNotifications.requestSubscription`. The component injects the <xref:Microsoft.JSInterop.IJSRuntime> service to invoke the JS function.
* The `SubscribeToNotifications` method is called to save the subscription.

In `BlazingPizza.Client/Components/Pages/Checkout.razor`:

```csharp
async Task RequestNotificationSubscriptionAsync()
{
    var subscription = await JSRuntime.InvokeAsync<NotificationSubscription>(
        "blazorPushNotifications.requestSubscription");

    if (subscription is not null)
    {
        try
        {
            await Repository.SubscribeToNotifications(subscription);
        }
        catch (AccessTokenNotAvailableException ex)
        {
            ex.Redirect();
        }
    }
}
```

In the `Checkout` component, `RequestNotificationSubscriptionAsync` is called in the [`OnInitialized` lifecycle method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) and executes on component initialization. The method is asynchronous, but it can run in the background, and the <xref:System.Threading.Tasks.Task> that it returns can be discarded. Therefore, the method isn't called in the asynchronous lifecycle method for component initialization (`OnInitializedAsync`). This approach renders the component faster.

```csharp
protected override void OnInitialized()
{
    _ = RequestNotificationSubscriptionAsync();
}
```

To demonstrate how the code works, run the Blazing Pizza app and start placing an order. Go to the checkout screen to see the subscription request:

![The Blazing Pizza app requests permission from the user to show notifications.](~/blazor/progressive-web-app/push-notifications/_static/show-notifications-request.png)

Choose **Allow** and check in the browser developer tools console for errors. You can set a breakpoint in the `PizzaApiExtensions`'s `MapPut("/notifications/subscribe"...)` code and run the app with debugging to inspect the incoming data from the browser. The data includes an endpoint URL and cryptographic tokens.

After the user has either allowed or blocked notifications for a given site, the browser won't ask again. To reset the permission for further testing for either Google Chrome or Microsoft Edge, select the "information" icon (&#x1F6C8;) to the left of the browser's address bar and change **Notifications** back to **Ask (default)**, as seen in the following image:

![Selecting "Ask (default)" for "Notifications" from this app to reset notifications back to a disabled state.](~/blazor/progressive-web-app/push-notifications/_static/reset-notifications.png)

## Send a notification

Sending a notification involves performing some complex cryptographic operations on the server to protect the data in transit. The bulk of the complexity is handled for the app by a third-party NuGet package, [`WebPush`](https://www.nuget.org/packages/WebPush), which is used by the server project (`BlazingPizza.Server`) in the Blazing Pizza app.

The `SendNotificationAsync` method dispatches order notifications using the captured subscription. The following code makes uses of `WebPush` APIs for dispatching the notification. The payload of the notification is JSON serialized and includes a message and a URL. The message is displayed to the user, and the URL allows the user to reach the pizza order associated with the notification. Additional parameters can be serialized as required for other notification scenarios.

[!INCLUDE[](~/blazor/security/includes/secure-authentication-flows.md)]

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

The preceding example enables the server to send notifications, but the browser doesn't react to notifications without additional logic. Displaying notifications is covered in the [Display notifications](#display-notifications) section.

The browser's developer tools console indicates the arrival of notifications ten seconds after orders are placed in the Blazing Pizza app. On the **Application** tab, open the **Push Messaging** section. Select the the circle to **Start recording**:

![Browser developer tools console on the "Application" tab with "Push Messaging" open showing three push notifications to the app with their timestamps.](~/blazor/progressive-web-app/push-notifications/_static/developer-tools-console-notifications.png)

## Display notifications

The PWA's service worker (`service-worker.js`) must handle push notifications in order for the app to display them.

The following [`push` event handler](https://developer.mozilla.org/docs/Web/API/PushEvent) in the Blazing Pizza app calls [`showNotification`](https://developer.mozilla.org/docs/Web/API/ServiceWorkerRegistration/showNotification) to create a notification for the active service worker.

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
    })
  );
});
```

The preceding code doesn't take effect until after the next page load when the browser logs `Installing service worker...`. When struggling to get the service worker to update, use the **Application** tab in the browser's developer tools console. Under **Service Workers**, choose **Update** or use **Unregister** to force a new registration on the next load.

With the preceding code in place and new order placed by a user, the order moves into *Out for delivery* status after 10 seconds per the app's built-in demonstration logic. The browser receives a push notification:

![A pop-up notification indicating to the user that their pizza order has been dispatched.](~/blazor/progressive-web-app/push-notifications/_static/order-dispatched-notification.png)

When using the app in either Google Chrome or Microsoft Edge, the notification appears even if the user isn't actively using the Blazing Pizza app. However, the browser must be running, or the notification appears the next time that the browser is opened.

When using the installed PWA, the notification should be delivered even if the user isn't running the app.

## Handle notification clicks

Register a [`notificationclick` event handler](https://developer.mozilla.org/docs/Web/API/ServiceWorkerGlobalScope/notificationclick_event) to process a user selecting (clicking) a push notification on their device:

* Close the notification by calling [`event.notification.close`](https://developer.mozilla.org/docs/Web/API/Notification/close).
* Call [`clients.openWindow`](https://developer.mozilla.org/docs/Web/API/Clients/openWindow) to create a new top-level browsing context and load the URL passed to the method.

The following example in the Blazing Pizza app takes the user to the order status page for the order that pertains to the notification. The URL is provided by the `event.notification.data.url` parameter, which is sent by the server in the notification's payload.

In the service worker file (`service-worker.js`):

```javascript
self.addEventListener('notificationclick', event => {
  event.notification.close();
  event.waitUntil(clients.openWindow(event.notification.data.url));
});
```

If the PWA is installed on the device, the PWA is shown on the device. If the PWA isn't installed, the user is taken to the app's page in their browser.

## Additional resources

* [Push API (MDN documentation)](https://developer.mozilla.org/docs/Web/API/Push_API)
* [Message Encryption for Web Push (draft-ietf-webpush-encryption-08)](https://datatracker.ietf.org/doc/html/draft-ietf-webpush-encryption-08)
* [Push API (W3C Working Draft 03 September 2024)](https://www.w3.org/TR/push-api/)
* [Service Worker API (MDN documentation)](https://developer.mozilla.org/docs/Web/API/Service_Worker_API)
