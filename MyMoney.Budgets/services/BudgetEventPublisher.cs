using System;
using MyMoney.Budgets.Models;
using Microsoft.Framework.ConfigurationModel;
using RabbitMQ.Client;
using Newtonsoft.Json;

namespace MyMoney.Budgets.Services
{
    public class BudgetEventPublisher : IBudgetEventPublisher, IDisposable
    {
        private IConnection _connection;
        private IModel _channel;

        public BudgetEventPublisher(IConfiguration configuration)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.Uri = configuration.Get("servicebus:connectionString");

            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
			
			_channel.ExchangeDeclare("mymoney","direct",true);
        }

        public void PublishMutation(Category category, Mutation mutation)
        {
            var messageBody = new
            {
                category = category.Name,
                amount = mutation.Amount,
                year = mutation.Year,
                month = mutation.Month,
                description = mutation.Description
            };
			
			byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(
				JsonConvert.SerializeObject(messageBody));
			
			_channel.BasicPublish("mymoney","mymoney.mutations",null, messageBodyBytes);
        }

        public void Dispose()
        {
            if (_channel != null)
            {
                _channel.Close();
                _channel = null;
            }

            if (_connection != null)
            {
                _connection.Close();
                _connection = null;
            }
        }
    }
}