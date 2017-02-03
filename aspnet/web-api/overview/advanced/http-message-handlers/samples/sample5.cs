var config = new HttpSelfHostConfiguration("http://localhost");
config.MessageHandlers.Add(new MessageHandler1());
config.MessageHandlers.Add(new MessageHandler2());