using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskScheduler
{
    static class Program
    {
        static void Main(string[] args)
        {
            var bag = new ConcurrentBag<string>();
            var client = new AsyncOperationClient();
            var serializer = new ResponseSerializer();

            Console.WriteLine("Starting...");

            Task.WaitAll(Requests.Select(request =>
            {
                return client.ExecuteAsync(request).ContinueWith(response =>
                {
                    var content = serializer.Serialize(response.Result);
                    bag.Add(content);                    
                });
            }).ToArray());

            foreach (var item in bag)
            {
                Console.WriteLine(item);
            }
        
            Console.ReadKey();
        }

        private static IEnumerable<ClientRequest> Requests
        {
            get 
            { 
                yield return new ClientRequest { Data = "Request Data!!!" };
                yield return new ClientRequest { Data = "Another Request Data!!!" };
                yield return new ClientRequest { Data = "Yet Another Request Data!!!" }; 
            }
        }
    }
}
