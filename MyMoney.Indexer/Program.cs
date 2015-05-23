using Microsoft.Framework.ConfigurationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Framework.Logging;

namespace MyMoney.Indexer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddConsole();

            ILogger logger = loggerFactory.CreateLogger("Program");

            Configuration config = new Configuration();
            config.AddJsonFile("config.json");

            var indexerClient = new IndexClient(config.Get("elasticsearch:url"));
            var indexName = config.Get("elasticsearch:index");
            var typeName = config.Get("elasticsearch:type");

            var receiver = new MessageReceiver(config,
                config.Get("servicebus:url"), "mutations");

            Console.WriteLine("Listening for events. Press Ctrl+C to exit.");

            while (true)
            {
                try
                {
                    var task = receiver.ReceiveAsync();
                    task.ConfigureAwait(false);

                    var processTask = task.ContinueWith(previousTask =>
                    {
                        if (previousTask.Exception != null)
                        {
                            logger.LogError("Failed to receive mutation", previousTask.Exception);
                        }

                        logger.LogInformation("Received mutation.");
                        indexerClient.WriteAsync(indexName, typeName, previousTask.Result);
                    });

                    processTask.Wait();
                }
                catch (Exception ex)
                {
                    logger.LogError("Failed to process mutation", ex);
                }
            }
        }
    }
}
