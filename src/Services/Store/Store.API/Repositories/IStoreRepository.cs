using Store.API.Dtos;
using Store.API.Entities;

namespace Store.API.Repositories
{
    public interface IStoreRepository
    {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItemById(string id);
        Task<Item> CreateItem(ItemDto itemDto);
    }
}
