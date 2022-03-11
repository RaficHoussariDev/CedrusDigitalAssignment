using MongoDB.Driver;
using Store.API.Entities;

namespace Store.API.Data
{
    public interface IStoreContext
    {
        IMongoCollection<Item> Items { get; }
    }
}
