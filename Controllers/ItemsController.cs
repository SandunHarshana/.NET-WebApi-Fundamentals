using Microsoft.AspNetCore.Mvc;
using Catalog.Repository;
using Catalog.Entities;
using Catalog.Dtos;

namespace Catalog.Controller
{
    [ApiController]
    [Route("items")]
    public class ItemsController: ControllerBase
    {
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> getItems(Guid id)
        {
            var item = repository.GetItem(id);
            if(item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }
    }
}