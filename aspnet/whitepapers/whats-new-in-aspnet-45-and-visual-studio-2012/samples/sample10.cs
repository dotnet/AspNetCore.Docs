public async Task MyWebSocket(AspNetWebSocketContext context)
{
	WebSocket socket = context.WebSocket;
	while (true)
	{
		ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);

		// Asynchronously wait for a message to arrive from a client
		WebSocketReceiveResult result = 
		   await socket.ReceiveAsync(buffer, CancellationToken.None);

		// If the socket is still open, echo the message back to the client
		if (socket.State == WebSocketState.Open)
		{
		   string userMessage = Encoding.UTF8.GetString(buffer.Array, 0,
			   result.Count);
		   userMessage = "You sent: " + userMessage + " at " + 
			   DateTime.Now.ToLongTimeString();
		   buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(userMessage));

		   // Asynchronously send a message to the client
		   await socket.SendAsync(buffer, WebSocketMessageType.Text,
			   true, CancellationToken.None);
		}
		else { break; }
	}
}