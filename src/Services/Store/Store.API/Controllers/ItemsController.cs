using Microsoft.AspNetCore.Mvc;
using Store.API.Dtos;
using Store.API.Entities;
using Store.API.Repositories;
using System.Net;

namespace Store.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemsController: ControllerBase
    {
        private readonly IStoreRepository _repo;
        private readonly ILogger<ItemsController> _logger;

        public ItemsController(IStoreRepository repo, ILogger<ItemsController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Item>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items = await _repo.GetItems();

            return Ok(items);
        }

        [HttpGet("{id:length(24)}", Name = "GetItem")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Item), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Item>> GetItem(string id)
        {
            var item = await _repo.GetItemById(id);

            if (item == null)
            {
                _logger.LogError($"Item with id {id} not found");
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Item), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Item>> CreateItem([FromBody] ItemDto itemDto)
        {
            var item = await _repo.CreateItem(itemDto);

            return CreatedAtRoute("GetProduct", new { id = item.Id }, item);
        }
    }
}
