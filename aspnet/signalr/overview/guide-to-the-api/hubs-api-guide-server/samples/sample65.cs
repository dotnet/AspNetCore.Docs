try
{
    await myHub.Invoke("Send", "<script>");
}
catch(HubException ex)
{
    Console.WriteLine(ex.Message);
}
