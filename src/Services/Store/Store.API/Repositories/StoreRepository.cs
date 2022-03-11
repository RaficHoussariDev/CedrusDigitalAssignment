using MongoDB.Driver;
using Store.API.Data;
using Store.API.Dtos;
using Store.API.Entities;

namespace Store.API.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IStoreContext _context;

        public StoreRepository(IStoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _context.Items.Find(p => true).ToListAsync();
        }

        public async Task<Item> GetItemById(string id)
        {
            return await _context.Items.Find(p => p.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Item> CreateItem(ItemDto itemDto)
        {
            Item item = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Name = itemDto.Name,
                Description = itemDto.Description,
                Quantity = itemDto.Quantity,
                Price = itemDto.Price,
                IsAvailable = true
            };

            await _context.Items.InsertOneAsync(item);
            return item;
        }
    }
}
