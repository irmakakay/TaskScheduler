namespace TaskScheduler
{
    public class ResponseSerializer
    {
        public string Serialize(ClientResponse response)
        {
            return response.Message;
        }
    }
}