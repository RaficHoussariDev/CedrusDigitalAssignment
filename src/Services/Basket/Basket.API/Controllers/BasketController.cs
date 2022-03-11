using Basket.API.Entitites;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController: ControllerBase
    {
        private readonly IBasketRepository _repo;
        private readonly ILogger<BasketController> _logger;

        public BasketController(IBasketRepository repo, ILogger<BasketController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        [HttpGet("{username}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCard), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCard>> GetBasket(string username)
        {
            var basket = await _repo.GetBasket(username);

            return Ok(basket ?? new ShoppingCard(username));
        }

        [HttpPost("{username}")]
        [ProducesResponseType(typeof(ShoppingCard), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCard>> AddBasketItem(string username, [FromBody] ShoppingCardItem item)
        {
            var updatedBasket = await _repo.UpdateBasket(username, item);

            return Ok(updatedBasket);
        }

        [HttpDelete("{username}/{itemId}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string username, string itemId)
        {
            var basket = await _repo.GetBasket(username);

            if (basket == null)
            {
                _logger.LogError($"Basket with username {username} not found");
                return NotFound();
            }

            if(_repo.GetItem(basket, itemId) == null)
            {
                _logger.LogError($"Item with id {itemId} not found in basket with username {username}");
                return NotFound();
            }

            await _repo.DeleteBasket(username);

            return Ok();
        }

        [HttpDelete("{username}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string username)
        {
            await _repo.DeleteBasket(username);

            return Ok();
        }
    }
}
