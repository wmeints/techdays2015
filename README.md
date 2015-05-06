# Techdays 2015 demo code
This repository contains the techdays 2015 code.

## Compiling
You need the following tools to compile and run the application:

- .NET framework 4.5.2
- ASP.NET MVC 5.x
- ASP.NET Web API 2.2
- Visual Studio 2013 update 4
- Azure SDK 2.6

## Deployment
Please be aware, you will need an Azure subscription to deploy this application.
I used the following setup on Azure to run the application

- Azure API app: MyMoney.Budgets
- Azure API app: MyMoney.Search
- Azure website: MyMoney.Frontend
- Azure SQL: MyMoney_Budgets
- Azure VM: ElasticSearch docker container

## Scaling
To scale the elasticsearch cluster you will need multiple VMs with docker installed.
Please follow the instructions on the wiki to setup docker-machine and swarm to work with
azure.


