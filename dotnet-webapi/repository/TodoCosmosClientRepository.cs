using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;

namespace dotnet_webapi
{
    public class TodoCosmosClientRepository : IAsyncTodoRepository
    {
        private Container todoItemsContainer;
        private readonly ILogger<TodoCosmosClientRepository> logger;
        private CosmosClient client;
        public TodoCosmosClientRepository(ILogger<TodoCosmosClientRepository> _logger)
        {
            logger = _logger;
            //TODO: Parametrize the endpoint, key, region
            client = new CosmosClient("https://cosmos-azconf-demo.documents.azure.com:443/",
                                                                "",
                                                                    new CosmosClientOptions
                                                                    {
                                                                        ApplicationRegion = Regions.SoutheastAsia
                                                                    });
            var database = client.GetDatabase("ToDoList");
            todoItemsContainer = database.GetContainer("Items");
        }
        public async Task AddTodo(TodoModel item)
        {
            await todoItemsContainer.CreateItemAsync<TodoModel>(item);
            logger.LogInformation($"Writing data to region : {client.ClientOptions.ApplicationRegion}");
        }

        public async Task<bool> DeleteTodo(string id)
        {
            await todoItemsContainer.DeleteItemAsync<TodoModel>(id, new PartitionKey(id));
            logger.LogInformation($"Deleting data from region : {client.ClientOptions.ApplicationRegion}");
            return true;
        }

        public async Task<List<TodoModel>> GetTodos()
        {
            var sqlQueryText = "SELECT * FROM c";
            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
            FeedIterator<TodoModel> queryResultSetIterator = this.todoItemsContainer.GetItemQueryIterator<TodoModel>(queryDefinition);
            List<TodoModel> todoItems = new List<TodoModel>();

            while (queryResultSetIterator.HasMoreResults)
            {
                var response = await queryResultSetIterator.ReadNextAsync();
                todoItems.AddRange(response.ToList());
            }
            logger.LogInformation($"Reading data from region : {client.ClientOptions.ApplicationRegion}");
            return todoItems;
        }
    }
}
