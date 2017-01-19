public async Task ProcessMessagesAsync()
{
    CloudQueue queue = _queueClient.GetQueueReference(fixitQueueName);
    await queue.CreateIfNotExistsAsync();
    while (true)
    {
        CloudQueueMessage message = await queue.GetMessageAsync();
        if (message == null)
        {
            break;
        }
        FixItTask fixit = JsonConvert.DeserializeObject<FixItTask>(message.AsString);
        await _repository.CreateAsync(fixit);
        await queue.DeleteMessageAsync(message);
    }
}