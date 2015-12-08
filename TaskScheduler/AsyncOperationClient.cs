using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public class AsyncOperationClient
    {
        public async Task<ClientResponse> ExecuteAsync(ClientRequest request)
        {
            return await Execute(request);
        }

        private Task<ClientResponse> Execute(ClientRequest request)
        {
            return Task.Run(() => ExecuteInternal(request));
        }

        private static ClientResponse ExecuteInternal(ClientRequest request)
        {
            Thread.Sleep(5000);

            return new ClientResponse { Message = string.Join("", request.Data.Reverse()) };
        }

    }
}