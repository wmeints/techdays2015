using Microsoft.Framework.ConfigurationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyMoney.Indexer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Configuration config = new Configuration();
            config.AddJsonFile("config.json");

            var indexerClient = new IndexClient(config.Get("elasticsearch:url"));
            var indexName = config.Get("elasticsearch:index");
            var typeName = config.Get("elasticsearch:type");

            var receiver = new MessageReceiver(config,
                "https://mymoney.servicebus.windows.net/",
                "mutations");

            Console.WriteLine("Listening for events. Press Ctrl+C to exit.");

            while (true)
            {
                var task = receiver.ReceiveAsync();
                task.ConfigureAwait(false);
                

                var processTask = task.ContinueWith(previousTask =>
                {
                    Console.WriteLine("[{0}] Received mutation.",DateTime.Now);
                    indexerClient.WriteAsync(indexName, typeName, previousTask.Result );
                });

                processTask.Wait();
            }
        }
    }
}
