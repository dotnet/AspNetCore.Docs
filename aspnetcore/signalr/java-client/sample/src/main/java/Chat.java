// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

import com.microsoft.aspnet.signalr.HubConnection;
import com.microsoft.aspnet.signalr.HubConnectionBuilder;
import com.microsoft.aspnet.signalr.LogLevel;

import java.util.Scanner;

public class Chat {
    public static void main(String[] args) throws Exception {
        System.out.println("Enter the URL of the SignalR Chat you want to join");
        Scanner reader = new Scanner(System.in);  // Reading from System.in
        String input;
        input = reader.nextLine();

        HubConnection hubConnection = new HubConnectionBuilder()
                .withUrl(input)
                .configureLogging(LogLevel.Information)
                .build();

        hubConnection.on("Send", (message) -> {
            System.out.println("New Message: " + message);
        }, String.class);

        //This is a blocking call
        hubConnection.start();

        while (!input.equals("leave")){
            input = reader.nextLine();
            hubConnection.send("Send", input);
        }

        hubConnection.stop();
    }
}
