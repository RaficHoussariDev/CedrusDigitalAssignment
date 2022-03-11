using MongoDB.Driver;
using Store.API.Entities;

namespace Store.API.Data
{
    public class StoreContext: IStoreContext
    {
        public StoreContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            Items = database.GetCollection<Item>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            //StoreContextSeed.SeedData(Items);
        }
        public IMongoCollection<Item> Items { get; }
    }
}
