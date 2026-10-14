#define DEFAULT
#if DEFAULT
#region snippet_MainWindowClass
using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRChatClient
{
    public partial class MainWindow : Window
    {
        private readonly HubConnection _connection;
        public MainWindow()
        {
            InitializeComponent();
            
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:53353/ChatHub")
                .Build();

            #region snippet_ClosedRestart
            _connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0,5) * 1000);
                await _connection.StartAsync();
            };
            #endregion
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            #region snippet_ConnectionOn
            _connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Dispatcher.Invoke(() =>
                {
                   var newMessage = $"{user}: {message}";
                   messagesList.Items.Add(newMessage);
                });
            });
            #endregion

            try
            {
                await _connection.StartAsync();
                messagesList.Items.Add("Connection started");
                connectButton.IsEnabled = false;
                sendButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            #region snippet_ErrorHandling
            try
            {
                #region snippet_InvokeAsync
                await _connection.InvokeAsync("SendMessage", 
                    userTextBox.Text, messageTextBox.Text);
                #endregion
            }
            catch (Exception ex)
            {                
                messagesList.Items.Add(ex.Message);                
            }
            #endregion
        }
    }
}
#endregion

#elif RETRY
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRChatClient
{
    public partial class MainWindow : Window
    {
        private readonly HubConnection _connection;
        public MainWindow()
        {
            InitializeComponent();

#region snippet_AutomaticReconnect
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:53353/ChatHub")
                .WithAutomaticReconnect(new[] { TimeSpan.Zero, TimeSpan.Zero, TimeSpan.FromSeconds(10) })
                .Build();

            // .WithAutomaticReconnect(new[] { TimeSpan.Zero, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(30) }) yields the default behavior.
#endregion

#region snippet_ClosedAfterDisconnect
            _connection.Closed += error =>
            {
                Debug.Assert(_connection.State == HubConnectionState.Disconnected);
            
                // Notify users the connection has been closed or manually try to restart the connection.
            
                return Task.CompletedTask;
            };
            #endregion

            #region snippet_Reconnecting
            _connection.Reconnecting += error =>
            {
                Debug.Assert(_connection.State == HubConnectionState.Reconnecting);
            
                // Notify users the connection was lost and the client is reconnecting.
                // Start queuing or dropping messages.
            
                return Task.CompletedTask;
            };
            #endregion

            #region snippet_Reconnected
            _connection.Reconnected += connectionId =>
            {
                Debug.Assert(_connection.State == HubConnectionState.Connected);
            
                // Notify users the connection was reestablished.
                // Start dequeuing messages queued while reconnecting if any.
            
                return Task.CompletedTask;
            };
#endregion
        }

        private async void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            _connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                Dispatcher.Invoke(() =>
                {
                   var newMessage = $"{user}: {message}";
                   messagesList.Items.Add(newMessage);
                });
            });

            try
            {
#region snippet_ConnectWithInitialReconnect
                await ConnectWithRetryAsync(_connection, default);     
#endregion
                messagesList.Items.Add("Connection started");
                connectButton.IsEnabled = false;
                sendButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _connection.InvokeAsync("SendMessage", 
                    userTextBox.Text, messageTextBox.Text);
            }
            catch (Exception ex)
            {                
                messagesList.Items.Add(ex.Message);                
            }
        }

#region snippet_ConnectWithRetryAsync
        public static async Task<bool> ConnectWithRetryAsync(HubConnection connection, CancellationToken token)
        {
            // Keep trying to until we can start or the token is canceled.
            while (true)
            {
                try
                {
                    await connection.StartAsync(token);
                    Debug.Assert(connection.State == HubConnectionState.Connected);
                    return true;
                }
                catch when (token.IsCancellationRequested)
                {
                    return false;
                }
                catch
                {
                    // Failed to connect, trying again in 5000 ms.
                    Debug.Assert(connection.State == HubConnectionState.Disconnected);
                    await Task.Delay(5000, token);
                }
            }
        }
#endregion
    }
}
#endif