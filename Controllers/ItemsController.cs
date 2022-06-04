using Microsoft.AspNetCore.Mvc;
using Catalog.Entities;
using Catalog.Dto;

namespace Catalog.Controllers{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepositories _repository;
        private readonly ILogger<ItemsController> _logger;
        
        public ItemsController(ILogger<ItemsController> logger, IItemRepositories repository){
            this._repository = repository;
           //repository = _InMemItemRepositories;
           this._logger = logger;
           
        }
        // Get/items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = _repository.GetItems().Select(i => i.AsDto()    
            );
            return items;
        }
        // GET / items / items / {id}
        [HttpGet("item/{id}")]
        public ActionResult<ItemDto> GetItem(Guid id){
            var item  = _repository.GetItem(id).AsDto();
            if(item is null){
                return NotFound();
            }
                return item;
        }
        // POST / items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto){
                Item item = new(){
                    Id = Guid.NewGuid(),
                    Name = itemDto.Name,
                    Price = itemDto.Price,
                    CreatedDate = DateTimeOffset.UtcNow
                };
                _repository.CreateIteam(item);
                // GET / items / items / {id} gi 
                return CreatedAtAction(nameof(GetItem),new {
                    id = item.Id,
                },item.AsDto()) ;
        } 
        // PUT / Items /{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id,UpdateItemDto itemDto){
                var existingItem = _repository.GetItem(id);
                if (existingItem is null){
                    return NotFound();
                }
                Item UpdateItem = existingItem with {
                    Name = itemDto.Name,
                    Price = itemDto.Price
                };
                _repository.UpdateItem(UpdateItem);
                return NoContent();
        }
        // Delete / items / {id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id){
                _repository.DeleteItem(id);
                return NoContent();
        }
    }
}