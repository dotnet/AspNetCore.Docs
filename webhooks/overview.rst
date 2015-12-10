Overview of ASP.NET WebHooks
============================

WebHooks is a lightweight HTTP pattern providing a simple pub/sub model 
for wiring together Web APIs and SaaS services. When an event happens in 
a service, a notification is sent in the form of an HTTP POST request to 
registered subscribers. The POST request contains information about the 
event which makes it possible for the receiver to act accordingly. 

Because of their simplicity, WebHooks are already exposed by a large 
number of services including `Dropbox <http://dropbox.com/>`_, `GitHub <http://www.github.com/>`_, `Bitbucket <https://bitbucket.org/>`_, 
`MailChimp <http://www.mailchimp.com/>`_, `PayPal <http://www.paypal.com/>`_, `Slack <http://www.slack.com>`_, 
`Stripe <http://www.stripe.com>`_, `Trello <http://www.trello.com/>`_, and many more. For example, a WebHook can indicate that a file 
has changed in Dropbox_, or a code change has been committed in GitHub, 
or a payment has been initiated in PayPal_, or a card has been created in 
Trello_. The possibilities are endless! 

Microsoft ASP.NET WebHooks makes it easier to both send and receive WebHooks as part of your ASP.NET application:

* On the receiving side, it provides a common model for receiving and 
  processing WebHooks from any number of WebHook providers. It comes out 
  of the box with support for Dropbox_, GitHub_, Bitbucket_, MailChimp_, PayPal_, `Pusher <http://www.pusher.com>`_, 
  `Salesforce <http://www.salesforce.com>`_, Slack_, Stripe_, Trello_, and `WordPress <http://www.wordpress.com>`_ but it is easy to add support for 
  more. 

* On the sending side it provides support for managing and storing 
  subscriptions as well as for sending event notifications to the right 
  set of subscribers. This allows you to define your own set of events 
  that subscribers can subscribe to and notify them when things happens. 

The two parts can be used together or apart depending on your scenario. 
If you only need to receive WebHooks from other services then you can 
use just the receiver part; if you only want to expose WebHooks for 
others to consume, then you can do just that. 

The code targets ASP.NET Web API 2 and ASP.NET MVC 5 and is available as `OSS on GitHub <https://github.com/aspnet/WebHooks>`_.

WebHooks Overview
-----------------

WebHooks is a pattern which means that it varies how it is used from service to service but the basic idea is the same. 
You can think of WebHooks as a simple pub/sub model where a user can subscribe to events happening elsewhere. The event 
notifications are propagated as HTTP POST requests containing information about the event itself. 

Typically the HTTP POST request contains a JSON object or HTML form data determined by the WebHook sender including 
information about the event causing the WebHook to trigger. For example, an example of a WebHook POST request body 
from GitHub_ looks like this as a result of a new issue being opened in a particular repository::

  {
    "action": "opened",
    "issue": {
        "url": "https://api.github.com/repos/octocat/Hello-World/issues/1347",
        "number": 1347,
        ...
    },
    "repository": {
        "id": 1296269,
        "full_name": "octocat/Hello-World",
        "owner": {
            "login": "octocat",
            "id": 1
            ...
        },
        ...
    },
    "sender": {
        "login": "octocat",
        "id": 1,
        ...
    }
  }    

To ensure that the WebHook is indeed from the intended sender, the POST request is secured in some way and then 
verified by the receiver. For example, `GitHub WebHooks <https://developer.github.com/webhooks/>`_ includes an *X-Hub-Signature* HTTP header with a hash of the request 
body which is checked by the receiver implementation so you don’t have to worry about it.

The WebHook flow generally goes something like this:

* The WebHook sender exposes events that a client can subscribe to. The events describe observable changes to the system, 
  for example that a new data item has been inserted, that a process has completed, or something else. 
* The WebHook receiver subscribes by registering a WebHook consisting of four things: 

    #. A URI for where the event notification should be posted in the form of an HTTP POST request; 
    #. A set of filters describing the particular events for which the WebHook should be fired; 
    #. A secret key which is used to sign the HTTP POST request;
    #. Additional data which is to be included in the HTTP POST request. This can for example be additional HTTP header
       fields or properties included in the HTTP POST request body.

* Once an event happens, the matching WebHook registrations are found and HTTP POST requests are submitted. Typically, the 
  generation of the HTTP POST requests are retried several times if for some reason the recipient is not responding or the 
  HTTP POST request results in an error response. 

WebHooks Processing Pipeline
----------------------------

The Microsoft ASP.NET WebHooks processing pipeline for incoming WebHooks looks like this:

.. image:: _static/WebHookReceivers.png

The two key concepts here are *Receivers* and *Handlers*:

* *Receivers* are responsible for handling the particular flavor of WebHook from a given sender and for enforcing security checks
  to ensure that the WebHook request indeed is from the intended sender.
 
* *Handlers* are typically where user code runs processing the particular WebHook.

In the following nodes these concepts are described in more details.

