# Techdays 2015 demo code
This repository contains the techdays 2015 code.

## Deployment
Please be aware, you will need an Azure subscription to deploy this application.
I used the following setup on Azure to run the application.

### Search API
The search API is used to talk to the elastic search server and contains
all the code that is needed to run search queries and perform auto-complete.
To deploy the code use the following commands:

```
cd MyMoney.Search
dnu restore
docker build -t mymoney/search .
docker run -d -p 4000:4000 --name=search mymoney/search
```

Additionally you need to run elasticsearch on Docker using the following command:

```
docker run -d -p 9200:9200 -p 9300:9300 elasticsearch elasticsearch -Des.cluster.name=mymoney
```

After you started the elasticsearch container, make sure that you POST the right mappings
to the elasticsearch engine. To create the correct mapping perform a POST request on
http://<es-container-ip>:9200/mutations with the following content:

```
{
    "mappings": {
        "mutation": {
            "properties": {
                "category": {
                    "type": "string",
                    "index": "not_analyzed"
                },
                "description": {
                    "type": "string",
                    "index": "analyzed"
                },
                "amount": {
                    "type": "double",
                    "index": "not_analyzed"
                },
                "year": {
                    "type": "integer",
                    "index": "not_analyzed"
                },
                "month": {
                    "type": "integer",
                    "index": "not_analyzed"
                }
            }
        }
    }
}
```

### Budgets API
The Budgets API is used to store most of the domain data for the mymoney application.
When the user posts a new mutation in the application, the mutation will be send
to the azure service bus for indexing. For this part to work you need to create
a new namespace on azure service bus.

After you have created the new namespace, copy the URL over to the config.json
file and make sure that you enter the name of the shared access key and the
value of the shared access key in the config.json file.

The budgets API needs a mongodb container to be running. To start the container
run the following command:

```
docker run -d -p 27017:27017 --name=mongodb mongo
```

To run the budgets API use the following commands:

```
cd MyMoney.Budgets
dnu restore
docker build -t mymoney/budgets .
docker run -d -t -p 3000:3000 --link mongodb:mongodb --name=budgets mymoney/budgets
```

### Indexer
The indexer is used to read messages from the service bus and send received
mutations to the elasticsearch server. The indexer uses the previously configured
azure service bus namespace. Copy the name and value of the shared access key
and paste them in the config.json file of the indexer.

To deploy the indexer use the following commands:

```
cd MyMoney.Indexer
dnu restore
docker build -t mymoney/indexer .
docker run -d -t --name=indexer mymoney/indexer
```

### Frontend
The final piece, the frontend, is used to provide users with access to their budget.
This part requires the following commands to deploy:

```
cd MyMoney.Frontend
dnu restore
docker build -t mymoney/frontend .
docker run -d -t -p 80:5001 --name=frontend mymoney/frontend
```
