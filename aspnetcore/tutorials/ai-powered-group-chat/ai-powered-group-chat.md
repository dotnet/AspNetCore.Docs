---
title: Sample AI-Powered Group Chat with SignalR and OpenAI
author: kevinguo-ed
description: A tutorial explaining how SignalR and OpenAI are used together to build an AI-powered group chat
ms.author: wpickett
ms.date: 03/19/2025
uid: tutorials/ai-powered-group-chat
---

# AI-Powered Group Chat sample with SignalR and OpenAI

The AI-Powered Group Chat sample demonstrates how to integrate OpenAI's capabilities into a real-time group chat application using ASP.NET Core SignalR.

* View or download [the complete sample code](https://github.com/microsoft/SignalR-Samples-AI/tree/main/AIStreaming).

## Overview

Integrating AI into applications is becoming essential for developers aiming to enhance user creativity, productivity, and overall experience. AI-powered features, such as intelligent chatbots, personalized recommendations, and contextual responses, add significant value to modern apps. While many AI-powered applications, like those inspired by ChatGPT, focus on interactions between a single user and an AI assistant, there's growing interest in exploring AI's potential within team environments. Developers are now asking, "What value can AI add to a team of collaborators?"

This sample guide highlights the process of building a real-time group chat application. In this chat, a group of human collaborators can interact with an AI assistant that has access to the chat history. Any collaborator can invite the AI to assist by starting their message with `@gpt`. The finished app looks like this:

:::image type="content" source="./ai-powered-group-chat.jpg" alt-text="user interface for the AI-powered group chat":::

This sample uses OpenAI for generating intelligent, context-aware responses and SignalR for delivering the response to users in a group. You can find the complete code [in this repo](https://github.com/microsoft/SignalR-Samples-AI/tree/main/AIStreaming).

## Dependencies

Either Azure OpenAI or OpenAI can be used for this project. Make sure to update the `endpoint` and `key` in `appsettings.json`. `OpenAIExtensions` reads the configuration when the app starts, and the configuration values for `endpoint` and `key` are required to authenticate and use either service.

### [OpenAI](#tab/open-ai)

To build this application, you will need the following:
* ASP.NET Core: To create the web application and host the SignalR hub.
* [SignalR](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client): For real-time communication between clients and the server.
* [OpenAI Client](https://www.nuget.org/packages/OpenAI): To interact with OpenAI's API for generating AI responses.

### [Azure OpenAI](#tab/azure-open-ai)

To build this application, you will need the following:
* ASP.NET Core: To create the web application and host the SignalR hub.
* [SignalR](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR.Client): For real-time communication between clients and the server.
* [Azure OpenAI](https://www.nuget.org/packages/Azure.AI.OpenAI): `Azure.AI.OpenAI`

---

## Implementation

This section highlights the key parts of the code that integrate SignalR with OpenAI to create an AI-enhanced group chat experience.

### Data flow 

The following diagram highlights the step-by-step communication and processing involved in using OpenAI services, employing an iterative approach to responses and data handling:

:::image type="content" source="./sequence-diagram-ai-powered-group-chat.png" alt-text="sequence diagram for the AI-powered group chat":::

In the previous diagram:

* The Client sends instructions to the Server, which then communicates with OpenAI to process these instructions. 
* OpenAI responds with partial completion data, which the Server forwards back to the Client. This process repeats multiple times for an iterative exchange of data between these components.

### SignalR Hub integration

The `GroupChatHub` class manages user connections, message broadcasting, and AI interactions. 

When a user sends a message starting with `@gpt`:

* The hub forwards it to OpenAI, which generates a response. 
* The AI's response is streamed back to the group in real-time.

The following code snippet demonstrates how the `CompleteChatStreamingAsync` method streams responses from OpenAI incrementally:

```csharp
var chatClient = _openAI.GetChatClient(_options.Model);

await foreach (var completion in 
    chatClient.CompleteChatStreamingAsync(messagesInludeHistory))
{   
    // ...
    // Buffering and sending the AI's response in chunks
    await Clients.Group(groupName).SendAsync(
        "newMessageWithId",
        "ChatGPT",
        id,
        totalCompletion.ToString());
    // ...
}
```

In the previous code:

* `chatClient.CompleteChatStreamingAsync(messagesIncludeHistory)` initiates the streaming of AI responses.
* The `totalCompletion.Append(content)` line accumulates the AI's response.
* If the length of the buffered content exceeds 20 characters, the buffered content is sent to the clients using `Clients.Group(groupName).SendAsync`.

This ensures that the AI's response is delivered to the users in real-time, providing a seamless and interactive chat experience.

### Maintain context with history

Every request to [OpenAI's Chat Completions API](https://platform.openai.com/docs/guides/chat-completions) is stateless. OpenAI doesn't store past interactions. In a chat app, what a user or an assistant has said is important for generating a response that's contextually relevant. To achieve this, include chat history in every request to the Completions API. 

The `GroupHistoryStore` class manages chat history for each group. It stores messages posted by both the users and AI assistants, ensuring that the conversation context is preserved across interactions. This context is crucial for generating coherent AI responses.

The following code demonstrates how to store messages generated by the AI assistant in memory. The `UpdateGroupHistoryForAssistant` method is called to add the AI assistant's message to the group history, ensuring that the conversation context is maintained:

```csharp
public void UpdateGroupHistoryForAssistant(string groupName, string message)
{
    var chatMessages = _store.GetOrAdd(groupName, _ => InitiateChatMessages());
    chatMessages.Add(new AssistantChatMessage(message));
}
```

The `_history.GetOrAddGroupHistory` method is called to add the user's message to the group history, ensuring that the conversation context is maintained:

```csharp
_history.GetOrAddGroupHistory(groupName, userName, message);
```

### Stream AI responses

The `CompleteChatStreamingAsync` method streams responses from OpenAI incrementally, which allows the app to send partial responses to the client as they're generated. 

The code uses a <xref:System.Text.StringBuilder> to accumulate the AI's response. It checks the length of the buffered content and sends it to the clients when it exceeds a certain threshold, for example, 20 characters. This approach ensures that users see the AI's response as it forms, mimicking a human-like typing effect. 

```csharp
totalCompletion.Append(content);

if (totalCompletion.Length - lastSentTokenLength > 20)
{
    await Clients.Group(groupName).SendAsync(
        "newMessageWithId",
        "ChatGPT",
        id,
        totalCompletion.ToString());

    lastSentTokenLength = totalCompletion.Length;
}
``` 

## Explore further

This project opens up exciting possibilities for further enhancement:
1. **Advanced AI features**: Leverage other OpenAI capabilities like sentiment analysis, translation, or summarization. 
1. **Incorporating multiple AI agents**: You can introduce multiple AI agents with distinct roles or expertise areas within the same chat. For example, one agent might focus on text generation while the other provides image or audio generation. This can create a richer and more dynamic user experience where different AI agents interact seamlessly with users and each other.
1. **Share chat history between server instances**: Implement a database layer to persist chat history across sessions, allowing conversations to resume even after a disconnect. Beyond SQL or NO SQL based solutions, you can also explore using a caching service like Redis. It can significantly improve performance by storing frequently accessed data, such as chat history or AI responses, in memory. This reduces latency and offloads database operations, leading to faster response times, particularly in high-traffic scenarios. 
1. **Leveraging Azure SignalR Service**: [Azure SignalR Service](/azure/azure-signalr/signalr-overview) provides scalable and reliable real-time messaging for your application. By offloading the SignalR backplane to Azure, you can scale out the chat application easily to support thousands of concurrent users across multiple servers. Azure SignalR also simplifies management and provides built-in features like automatic reconnections.
