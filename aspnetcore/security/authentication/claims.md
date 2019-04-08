---
title: Claims actions
author: rick-anderson
description: Learn how to build an ASP.NET Core app with email confirmation and password reset.
ms.author: riande
ms.date: 3/11/2019
uid: security/authentication/accconfirm
---

# Claims actions

By [Rick Anderson](https://twitter.com/RickAndMSFT), and [Kévin Chalet](https://github.com/PinpointTownes)

When using a remote auth providers such as Oauth, Facebook, OpenIdConnect, etc. user information is provided from the service in a JSON blob. That information needs to be mapped to Claims in a ClaimsIdentity for consumption by the rest of the application. Auth handlers like the Facebook handler map a few claims by default such as name and e-mail address. They don't try to map everything by default because they don't want to make the auth cookie too large.

Prior to 2.0 the recommended way to customize the claims mapping process was to hook into the OnCreatingTicket (Oauth) or OnUserInformationReceived (OIDC) events, inspecting the JSON, and creating your own claims. If you didn't like the claims the framework had mapped for you then you needed to use this event to remove them from the identity.
Example: https://stackoverflow.com/a/35634697/2588374. This would still be worth documenting for advanced scenarios.
